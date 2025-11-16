
namespace Arkham.API.Entities;

public class DeckRequirementRandom
{
    public int Id { get; set; }
    public int DeckRequirementId { get; set; }
    public DeckRequirement? DeckRequirement { get; set; }
    public required string Target { get; set; }
    public required string Value { get; set; }
}
