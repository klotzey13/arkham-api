
namespace Arkham.API.Entities;

public class DeckRequirementCard
{
    public int Id { get; set; }
    public int DeckRequirementCardChoiceId { get; set; }
    public DeckRequirementCardChoice? DeckRequirementCardChoice { get; set; }
    public required string CardCode { get; set; }
}
