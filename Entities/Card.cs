
using System.ComponentModel.DataAnnotations;

namespace Arkham.API.Entities;

public class Card
{
    [Key]
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public string? RealName { get; set; }
    public string? SubName { get; set; }
    public string? Text { get; set; }
    public string? RealText { get; set; }
    public int Quantity { get; set; }
    public int? SkillWillpower { get; set; }
    public int? SkillIntellect { get; set; }
    public int? SkillCombat { get; set; }
    public int? SkillAgility { get; set; }
    public int? SkillWild { get; set; }
    public int? Health { get; set; }
    public bool HealthPerInvestigator { get; set; }
    public int? Sanity { get; set; }
    public int? DeckLimit { get; set; }
    public string? Slot { get; set; }
    public string? RealSlot { get; set; }
    public ICollection<Trait> Traits { get; set; } = new List<Trait>();
    public ICollection<DeckOption> DeckOptions { get; set; } = new List<DeckOption>();
    public string? Flavor { get; set; }
    public string? Illustrator { get; set; }
    public bool IsUnique { get; set; }
    public bool Permanent { get; set; }
    public bool DoubleSided { get; set; }
    public string? BackText { get; set; }
    public string? BackFlavor { get; set; }
    public string? OctgnId { get; set; }
    public string? Url { get; set; }
    public string? ImageSrc { get; set; }
    public string? BackImageSrc { get; set; }
    public int? Cost { get; set; }
    public int? Xp { get; set; }
    public int Position { get; set; }
    public bool Exceptional { get; set; }
    public bool Myriad { get; set; }
    public int? DeckSize { get; set; }
    public DeckRequirement? DeckRequirement { get; set; }

    public int PackId { get; set; }
    public Pack? Pack { get; set; }

    public int TypeId { get; set; }
    public CardType? Type { get; set; }

    public int FactionId { get; set; }
    public Faction? Faction { get; set; }

    public int? SubTypeId { get; set; }
    public SubType? SubType { get; set; }
}
