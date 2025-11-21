using Arkham.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arkham.API.Data;

public class ArkhamDbContext : DbContext
{
    public ArkhamDbContext(DbContextOptions<ArkhamDbContext> options)
        : base(options) { }

    public DbSet<Card> Cards { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<DeckOption> DeckOptions { get; set; }
    public DbSet<DeckRequirement> DeckRequirements { get; set; }
    public DbSet<DeckRequirementCard> DeckRequirementCards { get; set; }
    public DbSet<DeckRequirementCardChoice> DeckRequirementCardChoices { get; set; }
    public DbSet<DeckRequirementRandom> DeckRequirementRandoms { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<Pack> Packs { get; set; }
    public DbSet<SubType> SubTypes { get; set; }
    public DbSet<Trait> Traits { get; set; }
    public DbSet<CardTrait> CardTraits { get; set; }
    public DbSet<DeckOptionFaction> DeckOptionFactions { get; set; }
    public DbSet<DeckOptionTrait> DeckOptionTraits { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Card>()
            .HasOne(c => c.Faction)
            .WithMany(f => f.Cards)
            .HasForeignKey(c => c.FactionId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Card>()
            .HasOne(c => c.Faction2)
            .WithMany()
            .HasForeignKey(c => c.Faction2Id)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<Card>()
            .HasOne(c => c.DeckRequirement)
            .WithOne(dr => dr.Card)
            .HasForeignKey<DeckRequirement>(dr => dr.CardId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CardTrait>().HasKey(ct => new { ct.CardId, ct.TraitId });

        modelBuilder
            .Entity<Card>()
            .HasMany(c => c.Traits)
            .WithMany(t => t.Cards)
            .UsingEntity<CardTrait>();

        modelBuilder
            .Entity<DeckOptionFaction>()
            .HasKey(dof => new { dof.DeckOptionId, dof.FactionId });

        modelBuilder
            .Entity<DeckOption>()
            .HasMany(d => d.Factions)
            .WithMany(f => f.DeckOptions)
            .UsingEntity<DeckOptionFaction>();

        modelBuilder.Entity<DeckOptionTrait>().HasKey(dot => new { dot.DeckOptionId, dot.TraitId });

        modelBuilder
            .Entity<DeckOption>()
            .HasMany(d => d.Traits)
            .WithMany(t => t.DeckOptions)
            .UsingEntity<DeckOptionTrait>();
    }
}
