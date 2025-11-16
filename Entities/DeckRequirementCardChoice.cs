
namespace Arkham.API.Entities;

public class DeckRequirementCardChoice
{
    public int Id { get; set; }
    public int DeckRequirementId { get; set; }
    public DeckRequirement? DeckRequirement { get; set; }
    public ICollection<DeckRequirementCard> Cards { get; set; } = new List<DeckRequirementCard>();
}
