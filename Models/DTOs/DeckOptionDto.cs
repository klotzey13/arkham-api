using System.Text.Json.Serialization;

namespace Arkham.API.Models.DTOs;

public class DeckOptionDto
{
    [JsonPropertyName("faction")]
    public List<string>? Faction { get; set; }

    [JsonPropertyName("level")]
    public LevelRangeDto? Level { get; set; }

    [JsonPropertyName("trait")]
    public List<string>? Trait { get; set; }

    [JsonPropertyName("uses")]
    public List<string>? Uses { get; set; }

    [JsonPropertyName("text")]
    public List<string>? Text { get; set; }

    [JsonPropertyName("tag")]
    public List<string>? Tag { get; set; }

    [JsonPropertyName("type")]
    public List<string>? Type { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("not")]
    public bool? Not { get; set; }

    [JsonPropertyName("atleast")]
    public AtLeastDto? AtLeast { get; set; }
}

public class LevelRangeDto
{
    [JsonPropertyName("min")]
    public int Min { get; set; }

    [JsonPropertyName("max")]
    public int Max { get; set; }
}

public class AtLeastDto
{
    [JsonPropertyName("factions")]
    public int? Factions { get; set; }

    [JsonPropertyName("min")]
    public int? Min { get; set; }
}
