namespace Arkham.API.Entities;

public class DeckOptionFaction
{
    public int DeckOptionId { get; set; }
    public DeckOption DeckOption { get; set; } = null!;

    public int FactionId { get; set; }
    public Faction Faction { get; set; } = null!;
}
