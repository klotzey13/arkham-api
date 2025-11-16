namespace Arkham.API.Entities;

public class DeckOptionTrait
{
    public int DeckOptionId { get; set; }
    public DeckOption DeckOption { get; set; } = null!;

    public int TraitId { get; set; }
    public Trait Trait { get; set; } = null!;
}
