namespace Arkham.API.Entities;

public class CardType
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public ICollection<Card> Cards { get; set; } = new List<Card>();
}
