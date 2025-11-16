namespace Arkham.API.Entities;

public class DeckOption
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public Card? Card { get; set; }

    public int? LevelMin { get; set; }
    public int? LevelMax { get; set; }
    public int? Limit { get; set; }
    public bool? Not { get; set; }

    public ICollection<Faction> Factions { get; set; } = new List<Faction>();
    public ICollection<Trait> Traits { get; set; } = new List<Trait>();
}
