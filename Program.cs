using Arkham.API.Data;
using Arkham.API.Services;
using Arkham.API.Services.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with pooling (required for HotChocolate's RegisterDbContextFactory)
builder.Services.AddPooledDbContextFactory<ArkhamDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ArkhamDb"))
);

// Also register scoped DbContext for DataSeeder
builder.Services.AddScoped<ArkhamDbContext>(sp =>
    sp.GetRequiredService<IDbContextFactory<ArkhamDbContext>>().CreateDbContext());

// Register DataSeeder
builder.Services.AddScoped<DataSeeder>();

builder
    .Services.AddGraphQLServer()
    .AddTypes()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContextFactory<ArkhamDbContext>()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = builder.Environment.IsDevelopment());

var app = builder.Build();

// Seed database on startup (development only)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedAsync();
}

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
