# .NET Senior Developer Interview Study Guide

This document tracks interview questions and answers as we build the Arkham API project.

---

## Entity Framework Core

### Q: Why do we need a design-time factory (`IDesignTimeDbContextFactory`) for EF Core?

**A:** EF Core tools (like `dotnet ef migrations add`) need to create an instance of your DbContext to analyze your model and generate migrations. This happens at **design-time** (when you're developing), not runtime (when the app is running).

The problem: Your DbContext constructor requires `DbContextOptions<T>`, but the tools aren't running your full application with its dependency injection container. The factory tells the tools "here's how to build a DbContext when you need one."

**Key distinction:**
- **Design-time**: Running EF Core CLI tools during development
- **Runtime**: Your application running and serving requests

**Interview follow-up they might ask:** "What's the alternative?" (Registering DbContext in Program.cs and letting tools use your app's DI)

---

### Q: What happens if we don't have a design-time factory?

**A:** You get this error:
```
Unable to create a 'DbContext' of type 'RuntimeType'. The exception 'Unable to resolve
service for type 'Microsoft.EntityFrameworkCore.DbContextOptions`1[...]' was thrown
while attempting to activate...
```

This happens because the EF tools can't figure out how to provide the required `DbContextOptions` parameter to your DbContext constructor.

---

### Q: Could we avoid using a factory? What are the alternatives?

**A:** Yes, there are two main approaches:

**Option 1: IDesignTimeDbContextFactory** (what we're doing)
- Explicit factory class
- Full control over how DbContext is created at design-time
- Good for learning because everything is explicit

**Option 2: Register in Program.cs with DI**
```csharp
builder.Services.AddDbContext<ArkhamDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ArkhamDb")));
```
- EF tools will use your app's startup configuration
- Cleaner for production
- Less code to maintain

**Trade-off:** Factory is more explicit; DI registration is more conventional in real apps.

---

### Q: How do you remove/delete an EF Core migration?

**A:** It depends on whether the migration has been applied to the database:

**If NOT applied yet:**
```bash
dotnet ef migrations remove
```
- Removes the most recent migration only
- Deletes migration files and reverts the model snapshot
- Run multiple times to remove multiple migrations

**If already applied to database:**
```bash
# First, revert the database to the previous migration
dotnet ef database update PreviousMigrationName

# Or revert all migrations
dotnet ef database update 0

# Then remove the migration files
dotnet ef migrations remove
```

**Interview follow-up:** "What if you delete migration files manually without reverting the database?"
- The database will be out of sync with your migration history
- Future migrations may fail or produce incorrect results
- EF Core tracks applied migrations in `__EFMigrationsHistory` table

**Best practice in early development:** If you're just starting, it's often cleaner to:
1. Drop the database entirely (`dotnet ef database drop`)
2. Delete the Migrations folder
3. Create a fresh initial migration

---

### Q: What's the difference between removing a migration and reverting database changes?

**A:**

**`dotnet ef migrations remove`:**
- Deletes migration **code files** from your project
- Updates the model snapshot
- Does NOT touch the database

**`dotnet ef database update <target>`:**
- Runs the `Down()` methods in migrations to revert database changes
- Updates the `__EFMigrationsHistory` table
- Does NOT delete migration files

**Key point:** Always revert database changes BEFORE removing migration files, or they'll be out of sync.

---

### Q: How do you configure a one-to-one relationship in EF Core?

**A:** One-to-one relationships require explicit configuration because EF Core needs to know which entity has the foreign key.

**Pattern:**
```csharp
modelBuilder.Entity<PrincipalEntity>()
    .HasOne(p => p.DependentNavigation)
    .WithOne(d => d.PrincipalNavigation)
    .HasForeignKey<DependentEntity>(d => d.ForeignKeyProperty);
```

**Example (Card → DeckRequirement):**
```csharp
modelBuilder.Entity<Card>()
    .HasOne(c => c.DeckRequirement)
    .WithOne(dr => dr.Card)
    .HasForeignKey<DeckRequirement>(dr => dr.CardId);
```

**Key components:**
1. **HasOne()** - Principal side has one dependent
2. **WithOne()** - Dependent side references back to principal
3. **HasForeignKey<T>()** - Specifies which entity contains the FK column (REQUIRED!)
4. **IsRequired()** - Whether the relationship is required or optional
5. **OnDelete()** - Cascade delete behavior

**What happens without HasForeignKey?**
- EF Core doesn't know which table should have the FK
- Might create shadow properties with auto-generated names
- Migration might fail or create incorrect schema
- Database structure becomes ambiguous

---

### Q: What's the difference between principal and dependent entities in a relationship?

**A:**

**Principal Entity:**
- The entity being referenced
- Contains the primary key
- In Card ↔ DeckRequirement, **Card** is the principal
- Can exist independently

**Dependent Entity:**
- The entity doing the referencing
- Contains the foreign key
- In Card ↔ DeckRequirement, **DeckRequirement** is the dependent
- Depends on the principal entity

**Example:**
```csharp
public class Card  // Principal
{
    public int Id { get; set; }  // PK
    public DeckRequirement? DeckRequirement { get; set; }
}

public class DeckRequirement  // Dependent
{
    public int Id { get; set; }
    public int CardId { get; set; }  // FK to Card
    public Card? Card { get; set; }
}
```

**Interview tip:** In one-to-many, the "many" side is always the dependent. In one-to-one, you explicitly choose which is dependent using `HasForeignKey<T>()`.

---

### Q: What are the different DeleteBehavior options in EF Core and when would you use each?

**A:**

**DeleteBehavior.Cascade** (most common):
- When principal is deleted, dependents are automatically deleted
- Example: Delete Card → delete its DeckRequirement
- Use when: Dependent can't exist without principal

**DeleteBehavior.Restrict**:
- Prevents deletion of principal if dependents exist
- Throws exception if you try
- Use when: You want to ensure referential integrity manually

**DeleteBehavior.SetNull**:
- When principal is deleted, FK in dependent is set to NULL
- Requires nullable FK
- Use when: Dependent can exist without principal

**DeleteBehavior.NoAction** (or ClientSetNull):
- Database does nothing
- Application must handle orphans
- Use when: You're managing the relationship manually

**Interview follow-up:** "What happens if you have circular cascade paths?" (SQL Server will throw error; you need to use DeleteBehavior.Restrict on one path)

---

### Q: What's the difference between required and optional relationships in EF Core?

**A:**

**Required relationship:**
```csharp
.HasOne(c => c.Pack)
.WithMany(p => p.Cards)
.IsRequired();  // or .IsRequired(true)
```
- Foreign key column is NOT NULL in database
- Navigation property is non-nullable: `public Pack Pack { get; set; }`
- Must be provided when creating entity
- EF Core will enforce this

**Optional relationship:**
```csharp
.HasOne(c => c.DeckRequirement)
.WithOne(dr => dr.Card)
.IsRequired(false);
```
- Foreign key column is NULL in database
- Navigation property is nullable: `public DeckRequirement? DeckRequirement { get; set; }`
- Can be null when creating entity
- More flexible but requires null checks

**Convention:** EF Core infers required/optional from your C# nullable reference types (`?`). Using `.IsRequired()` makes it explicit.

---

## .NET Configuration

### Q: How does configuration work in .NET Core?

**A:** .NET Core uses a **layered configuration system**:

1. **ConfigurationBuilder** - Builds up configuration from multiple sources
2. **Sources are loaded in order** - Later sources override earlier ones
3. **Common sources:**
   - `appsettings.json` - Base configuration
   - `appsettings.{Environment}.json` - Environment-specific overrides
   - Environment variables - Often used in production
   - User secrets - For development secrets
   - Command-line arguments - Highest priority

**Key pattern:**
```csharp
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();
```

**Interview tip:** Explain that later sources override earlier ones, so environment variables can override JSON settings.

---

### Q: Why separate `appsettings.Development.json` from `appsettings.json`?

**A:**

**Different environments need different settings:**
- Development: localhost database, verbose logging, local connection strings
- Production: production database, error-only logging, secure connection strings

**Best practices:**
- `appsettings.json` - Shared defaults that work everywhere
- `appsettings.Development.json` - Local dev overrides (safe to commit)
- `appsettings.Production.json` - Production settings (often not committed)
- User Secrets / Environment Variables - Sensitive data (never committed)

**Security consideration:** Never commit production connection strings or secrets to source control. Use Azure Key Vault, AWS Secrets Manager, or environment variables in production.

**Why `optional: true`?** The Development.json file might not exist in production deployments, and that's okay - the app shouldn't crash just because an optional config file is missing.

---

## C# Language Features

### Q: What are primary constructors (C# 12) and when would you use them?

**A:** Primary constructors allow you to declare constructor parameters directly in the class declaration:

**Traditional:**
```csharp
public class MyService
{
    private readonly ILogger _logger;

    public MyService(ILogger logger)
    {
        _logger = logger;
    }
}
```

**Primary constructor:**
```csharp
public class MyService(ILogger logger)
{
    // 'logger' is available in the entire class
    public void DoWork() => logger.LogInformation("Working");
}
```

**When to use:**
- Simple classes with few dependencies
- When you don't need to validate or transform constructor arguments
- Reduces boilerplate for parameter capture

**When NOT to use:**
- Complex initialization logic needed
- Need to validate parameters
- When the captured parameters aren't obvious (can reduce readability)

**Interview gotcha:** If you write `public class Foo()` with empty parentheses, you're declaring a parameterless primary constructor, which is unusual and likely a mistake.

---

## Next Topics to Cover
- DbContext lifecycle and pooling
- Migration best practices
- LINQ query patterns
- GraphQL schema design
- Docker containerization
- Production deployment strategies
