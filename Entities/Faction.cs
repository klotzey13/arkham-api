namespace Arkham.API.Entities;

public class Faction
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public ICollection<Card> Cards { get; set; } = new List<Card>();
    public ICollection<DeckOption> DeckOptions { get; set; } = new List<DeckOption>();
}
