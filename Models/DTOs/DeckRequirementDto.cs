using System.Text.Json.Serialization;

namespace Arkham.API.Models.DTOs;

public class DeckRequirementDto
{
    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("card")]
    public Dictionary<string, Dictionary<string, string>>? Card { get; set; }

    [JsonPropertyName("random")]
    public List<DeckRequirementRandomDto>? Random { get; set; }
}

public class DeckRequirementRandomDto
{
    [JsonPropertyName("target")]
    public string? Target { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
