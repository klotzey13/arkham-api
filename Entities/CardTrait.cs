namespace Arkham.API.Entities;

public class CardTrait
{
    public int CardId { get; set; }
    public Card Card { get; set; } = null!;

    public int TraitId { get; set; }
    public Trait Trait { get; set; } = null!;
}
