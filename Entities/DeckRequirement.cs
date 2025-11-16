
namespace Arkham.API.Entities;

public class DeckRequirement
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public Card? Card { get; set; }
    
    public ICollection<DeckRequirementCardChoice> CardChoices { get; set; } = new List<DeckRequirementCardChoice>();
    public ICollection<DeckRequirementRandom> Randoms { get; set; } = new List<DeckRequirementRandom>();
}
