using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arkham.API.Models.DTOs;

public class CardDto
{
    [JsonPropertyName("pack_code")]
    public string PackCode { get; set; } = string.Empty;

    [JsonPropertyName("pack_name")]
    public string PackName { get; set; } = string.Empty;

    [JsonPropertyName("type_code")]
    public string TypeCode { get; set; } = string.Empty;

    [JsonPropertyName("type_name")]
    public string TypeName { get; set; } = string.Empty;

    [JsonPropertyName("subtype_code")]
    public string? SubtypeCode { get; set; }

    [JsonPropertyName("subtype_name")]
    public string? SubtypeName { get; set; }

    [JsonPropertyName("faction_code")]
    public string FactionCode { get; set; } = string.Empty;

    [JsonPropertyName("faction_name")]
    public string FactionName { get; set; } = string.Empty;

    [JsonPropertyName("faction2_code")]
    public string? Faction2Code { get; set; }

    [JsonPropertyName("faction2_name")]
    public string? Faction2Name { get; set; }

    [JsonPropertyName("position")]
    public int Position { get; set; }

    [JsonPropertyName("exceptional")]
    public bool Exceptional { get; set; }

    [JsonPropertyName("myriad")]
    public bool Myriad { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("real_name")]
    public string? RealName { get; set; }

    [JsonPropertyName("subname")]
    public string? Subname { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("real_text")]
    public string? RealText { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("skill_willpower")]
    public int? SkillWillpower { get; set; }

    [JsonPropertyName("skill_intellect")]
    public int? SkillIntellect { get; set; }

    [JsonPropertyName("skill_combat")]
    public int? SkillCombat { get; set; }

    [JsonPropertyName("skill_agility")]
    public int? SkillAgility { get; set; }

    [JsonPropertyName("skill_wild")]
    public int? SkillWild { get; set; }

    [JsonPropertyName("health")]
    public int? Health { get; set; }

    [JsonPropertyName("health_per_investigator")]
    public bool HealthPerInvestigator { get; set; }

    [JsonPropertyName("sanity")]
    public int? Sanity { get; set; }

    [JsonPropertyName("deck_limit")]
    public int? DeckLimit { get; set; }

    [JsonPropertyName("slot")]
    public string? Slot { get; set; }

    [JsonPropertyName("real_slot")]
    public string? RealSlot { get; set; }

    [JsonPropertyName("traits")]
    public string? Traits { get; set; }

    [JsonPropertyName("real_traits")]
    public string? RealTraits { get; set; }

    [JsonPropertyName("deck_requirements")]
    public DeckRequirementDto? DeckRequirements { get; set; }

    [JsonPropertyName("deck_options")]
    public List<DeckOptionDto>? DeckOptions { get; set; }

    [JsonPropertyName("flavor")]
    public string? Flavor { get; set; }

    [JsonPropertyName("illustrator")]
    public string? Illustrator { get; set; }

    [JsonPropertyName("is_unique")]
    public bool IsUnique { get; set; }

    [JsonPropertyName("permanent")]
    public bool Permanent { get; set; }

    [JsonPropertyName("double_sided")]
    public bool DoubleSided { get; set; }

    [JsonPropertyName("back_text")]
    public string? BackText { get; set; }

    [JsonPropertyName("back_flavor")]
    public string? BackFlavor { get; set; }

    [JsonPropertyName("octgn_id")]
    public string? OctgnId { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("imagesrc")]
    public string? ImageSrc { get; set; }

    [JsonPropertyName("backimagesrc")]
    public string? BackImageSrc { get; set; }

    [JsonPropertyName("cost")]
    public int? Cost { get; set; }

    [JsonPropertyName("xp")]
    public int? Xp { get; set; }

    [JsonPropertyName("duplicated_by")]
    public List<string>? DuplicatedBy { get; set; }

    [JsonPropertyName("alternated_by")]
    public List<string>? AlternatedBy { get; set; }

    [JsonPropertyName("alternate_of_code")]
    public string? AlternateOfCode { get; set; }

    [JsonPropertyName("alternate_of_name")]
    public string? AlternateOfName { get; set; }

    [JsonPropertyName("duplicate_of_code")]
    public string? DuplicateOfCode { get; set; }

    [JsonPropertyName("duplicate_of_name")]
    public string? DuplicateOfName { get; set; }

    [JsonPropertyName("linked_to_code")]
    public string? LinkedToCode { get; set; }

    [JsonPropertyName("linked_to_name")]
    public string? LinkedToName { get; set; }

    [JsonPropertyName("bonded_to")]
    public string? BondedTo { get; set; }

    [JsonPropertyName("bonded_cards")]
    public List<object>? BondedCards { get; set; }

    [JsonPropertyName("bonded_count")]
    public int? BondedCount { get; set; }

    [JsonPropertyName("enemy_damage")]
    public int? EnemyDamage { get; set; }

    [JsonPropertyName("enemy_horror")]
    public int? EnemyHorror { get; set; }

    [JsonPropertyName("enemy_fight")]
    public int? EnemyFight { get; set; }

    [JsonPropertyName("enemy_evade")]
    public int? EnemyEvade { get; set; }

    [JsonPropertyName("victory")]
    public int? Victory { get; set; }

    [JsonPropertyName("vengeance")]
    public int? Vengeance { get; set; }

    [JsonPropertyName("clues")]
    public int? Clues { get; set; }

    [JsonPropertyName("clues_fixed")]
    public bool? CluesFixed { get; set; }

    [JsonPropertyName("shroud")]
    public int? Shroud { get; set; }

    [JsonPropertyName("doom")]
    public int? Doom { get; set; }

    [JsonPropertyName("stage")]
    public int? Stage { get; set; }

    [JsonPropertyName("encounter_code")]
    public string? EncounterCode { get; set; }

    [JsonPropertyName("encounter_name")]
    public string? EncounterName { get; set; }

    [JsonPropertyName("encounter_position")]
    public int? EncounterPosition { get; set; }

    [JsonPropertyName("spoiler")]
    public int? Spoiler { get; set; }

    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("restrictions")]
    public JsonElement? Restrictions { get; set; }

    [JsonPropertyName("exile")]
    public bool? Exile { get; set; }

    [JsonPropertyName("tags")]
    public string? Tags { get; set; }

    [JsonPropertyName("customization_text")]
    public string? CustomizationText { get; set; }

    [JsonPropertyName("customization_change")]
    public string? CustomizationChange { get; set; }

    [JsonPropertyName("customization_options")]
    public List<object>? CustomizationOptions { get; set; }

    [JsonPropertyName("errata_date")]
    public ErrataDateDto? ErrataDate { get; set; }

    [JsonPropertyName("back_name")]
    public string? BackName { get; set; }

    [JsonPropertyName("base_level")]
    public int? BaseLevel { get; set; }
}

public class ErrataDateDto
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("timezone_type")]
    public int? TimezoneType { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }
}
