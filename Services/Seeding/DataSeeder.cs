using System.Text.Json;
using Arkham.API.Data;
using Arkham.API.Entities;
using Arkham.API.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Arkham.API.Services.Seeding;

public class DataSeeder
{
    private readonly ArkhamDbContext _context;
    private readonly ILogger<DataSeeder> _logger;
    private readonly string _jsonFilePath;

    // Lookup dictionaries for FK resolution
    private Dictionary<string, int> _packLookup = new();
    private Dictionary<string, int> _factionLookup = new();
    private Dictionary<string, int> _typeLookup = new();
    private Dictionary<string, int> _subTypeLookup = new();
    private Dictionary<string, int> _traitLookup = new();

    public DataSeeder(ArkhamDbContext context, ILogger<DataSeeder> logger, IWebHostEnvironment env)
    {
        _context = context;
        _logger = logger;
        _jsonFilePath = System.IO.Path.Combine(env.ContentRootPath, "Setup", "cards_en.json");
    }

    public async Task SeedAsync()
    {
        if (await _context.Cards.AnyAsync())
        {
            _logger.LogInformation("Database already seeded. Skipping.");
            return;
        }

        _logger.LogInformation("Starting database seeding...");

        var jsonContent = await File.ReadAllTextAsync(_jsonFilePath);
        var cardDtos = JsonSerializer.Deserialize<List<CardDto>>(jsonContent);

        if (cardDtos == null || cardDtos.Count == 0)
        {
            _logger.LogWarning("No cards found in JSON file.");
            return;
        }

        _logger.LogInformation("Loaded {Count} cards from JSON", cardDtos.Count);

        // Seed lookup tables first (order matters for FK dependencies)
        await SeedPacks(cardDtos);
        await SeedFactions(cardDtos);
        await SeedCardTypes(cardDtos);
        await SeedSubTypes(cardDtos);
        await SeedTraits(cardDtos);

        // Seed cards with FK references
        await SeedCards(cardDtos);

        // Seed card relationships
        await SeedCardTraits(cardDtos);
        await SeedDeckOptions(cardDtos);
        await SeedDeckRequirements(cardDtos);

        _logger.LogInformation("Database seeding completed!");
    }

    private async Task SeedPacks(List<CardDto> cardDtos)
    {
        var packs = cardDtos
            .Select(c => new { c.PackCode, c.PackName })
            .Distinct()
            .Select(p => new Pack { Code = p.PackCode, Name = p.PackName })
            .ToList();

        _context.Packs.AddRange(packs);
        await _context.SaveChangesAsync();

        _packLookup = await _context.Packs.ToDictionaryAsync(p => p.Code, p => p.Id);
        _logger.LogInformation("Seeded {Count} packs", packs.Count);
    }

    private async Task SeedFactions(List<CardDto> cardDtos)
    {
        var primaryFactions = cardDtos
            .Select(c => new { Code = c.FactionCode, Name = c.FactionName })
            .Distinct();

        var secondaryFactions = cardDtos
            .Where(c => !string.IsNullOrEmpty(c.Faction2Code))
            .Select(c => new { Code = c.Faction2Code!, Name = c.Faction2Name! })
            .Distinct();

        var factions = primaryFactions
            .Concat(secondaryFactions)
            .DistinctBy(f => f.Code)
            .Select(f => new Faction { Code = f.Code, Name = f.Name })
            .ToList();

        _context.Factions.AddRange(factions);
        await _context.SaveChangesAsync();

        _factionLookup = await _context.Factions.ToDictionaryAsync(f => f.Code, f => f.Id);
        _logger.LogInformation("Seeded {Count} factions", factions.Count);
    }

    private async Task SeedCardTypes(List<CardDto> cardDtos)
    {
        var cardTypes = cardDtos
            .Select(c => new { c.TypeCode, c.TypeName })
            .Distinct()
            .Select(t => new CardType { Code = t.TypeCode, Name = t.TypeName })
            .ToList();

        _context.CardTypes.AddRange(cardTypes);
        await _context.SaveChangesAsync();

        _typeLookup = await _context.CardTypes.ToDictionaryAsync(t => t.Code, t => t.Id);
        _logger.LogInformation("Seeded {Count} card types", cardTypes.Count);
    }

    private async Task SeedSubTypes(List<CardDto> cardDtos)
    {
        var subTypes = cardDtos
            .Where(c => !string.IsNullOrEmpty(c.SubtypeCode))
            .Select(c => new { c.SubtypeCode, c.SubtypeName })
            .Distinct()
            .Select(s => new SubType { Code = s.SubtypeCode!, Name = s.SubtypeName! })
            .ToList();

        _context.SubTypes.AddRange(subTypes);
        await _context.SaveChangesAsync();

        _subTypeLookup = await _context.SubTypes.ToDictionaryAsync(s => s.Code, s => s.Id);
        _logger.LogInformation("Seeded {Count} sub types", subTypes.Count);
    }

    private async Task SeedTraits(List<CardDto> cardDtos)
    {
        var traits = cardDtos
            .Where(c => !string.IsNullOrEmpty(c.Traits))
            .SelectMany(c => c.Traits!.Split('.', StringSplitOptions.RemoveEmptyEntries))
            .Select(t => t.Trim())
            .Where(t => !string.IsNullOrEmpty(t))
            .Distinct()
            .Select(t => new Trait { Name = t })
            .ToList();

        _context.Traits.AddRange(traits);
        await _context.SaveChangesAsync();

        _traitLookup = await _context.Traits.ToDictionaryAsync(t => t.Name, t => t.Id);
        _logger.LogInformation("Seeded {Count} traits", traits.Count);
    }

    private async Task SeedCards(List<CardDto> cardDtos)
    {
        var cards = cardDtos
            .Select(dto => new Card
            {
                Code = dto.Code,
                Name = dto.Name,
                RealName = dto.RealName,
                SubName = dto.Subname,
                Text = dto.Text,
                RealText = dto.RealText,
                Quantity = dto.Quantity,
                SkillWillpower = dto.SkillWillpower,
                SkillIntellect = dto.SkillIntellect,
                SkillCombat = dto.SkillCombat,
                SkillAgility = dto.SkillAgility,
                SkillWild = dto.SkillWild,
                Health = dto.Health,
                HealthPerInvestigator = dto.HealthPerInvestigator,
                Sanity = dto.Sanity,
                DeckLimit = dto.DeckLimit,
                Slot = dto.Slot,
                RealSlot = dto.RealSlot,
                Flavor = dto.Flavor,
                Illustrator = dto.Illustrator,
                IsUnique = dto.IsUnique,
                Permanent = dto.Permanent,
                DoubleSided = dto.DoubleSided,
                BackText = dto.BackText,
                BackFlavor = dto.BackFlavor,
                OctgnId = dto.OctgnId,
                Url = dto.Url,
                ImageSrc = dto.ImageSrc,
                BackImageSrc = dto.BackImageSrc,
                Cost = dto.Cost,
                Xp = dto.Xp,
                Position = dto.Position,
                Exceptional = dto.Exceptional,
                Myriad = dto.Myriad,
                DeckSize = dto.DeckRequirements?.Size,

                // FK lookups
                PackId = _packLookup[dto.PackCode],
                TypeId = _typeLookup[dto.TypeCode],
                FactionId = _factionLookup[dto.FactionCode],
                Faction2Id = !string.IsNullOrEmpty(dto.Faction2Code)
                    ? _factionLookup[dto.Faction2Code]
                    : null,
                SubTypeId = !string.IsNullOrEmpty(dto.SubtypeCode)
                    ? _subTypeLookup[dto.SubtypeCode]
                    : null,
            })
            .ToList();

        _context.Cards.AddRange(cards);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Seeded {Count} cards", cards.Count);
    }

    private async Task SeedCardTraits(List<CardDto> cardDtos)
    {
        var cardLookup = await _context.Cards.ToDictionaryAsync(c => c.Code, c => c.Id);
        var cardTraits = new List<CardTrait>();

        foreach (var dto in cardDtos.Where(c => !string.IsNullOrEmpty(c.Traits)))
        {
            var traitNames = dto.Traits!.Split('.', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .Where(t => !string.IsNullOrEmpty(t));

            foreach (var traitName in traitNames)
            {
                if (
                    _traitLookup.TryGetValue(traitName, out var traitId)
                    && cardLookup.TryGetValue(dto.Code, out var cardId)
                )
                {
                    cardTraits.Add(new CardTrait { CardId = cardId, TraitId = traitId });
                }
            }
        }

        _context.CardTraits.AddRange(cardTraits);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Seeded {Count} card-trait relationships", cardTraits.Count);
    }

    private async Task SeedDeckOptions(List<CardDto> cardDtos)
    {
        var cardLookup = await _context.Cards.ToDictionaryAsync(c => c.Code, c => c.Id);
        var deckOptions = new List<DeckOption>();

        foreach (var dto in cardDtos.Where(c => c.DeckOptions != null && c.DeckOptions.Count > 0))
        {
            if (!cardLookup.TryGetValue(dto.Code, out var cardId))
                continue;

            foreach (var optionDto in dto.DeckOptions!)
            {
                deckOptions.Add(
                    new DeckOption
                    {
                        CardId = cardId,
                        LevelMin = optionDto.Level?.Min,
                        LevelMax = optionDto.Level?.Max,
                        Limit = optionDto.Limit,
                        Not = optionDto.Not,
                    }
                );
            }
        }

        _context.DeckOptions.AddRange(deckOptions);
        await _context.SaveChangesAsync();

        // Second pass: create faction/trait relationships
        var allDeckOptions = await _context.DeckOptions.ToListAsync();
        var deckOptionsByCard = allDeckOptions
            .GroupBy(d => d.CardId)
            .ToDictionary(g => g.Key, g => g.ToList());

        var deckOptionFactions = new List<DeckOptionFaction>();
        var deckOptionTraits = new List<DeckOptionTrait>();

        foreach (var dto in cardDtos.Where(c => c.DeckOptions != null && c.DeckOptions.Count > 0))
        {
            if (!cardLookup.TryGetValue(dto.Code, out var cardId))
                continue;
            if (!deckOptionsByCard.TryGetValue(cardId, out var cardDeckOptions))
                continue;

            for (int i = 0; i < dto.DeckOptions!.Count && i < cardDeckOptions.Count; i++)
            {
                var optionDto = dto.DeckOptions[i];
                var deckOption = cardDeckOptions[i];

                if (optionDto.Faction != null)
                {
                    foreach (var factionCode in optionDto.Faction)
                    {
                        if (_factionLookup.TryGetValue(factionCode, out var factionId))
                        {
                            deckOptionFactions.Add(
                                new DeckOptionFaction
                                {
                                    DeckOptionId = deckOption.Id,
                                    FactionId = factionId,
                                }
                            );
                        }
                    }
                }

                if (optionDto.Trait != null)
                {
                    foreach (var traitName in optionDto.Trait)
                    {
                        if (_traitLookup.TryGetValue(traitName, out var traitId))
                        {
                            deckOptionTraits.Add(
                                new DeckOptionTrait
                                {
                                    DeckOptionId = deckOption.Id,
                                    TraitId = traitId,
                                }
                            );
                        }
                    }
                }
            }
        }

        _context.DeckOptionFactions.AddRange(deckOptionFactions);
        _context.DeckOptionTraits.AddRange(deckOptionTraits);
        await _context.SaveChangesAsync();
        _logger.LogInformation("Seeded {Count} deck options", deckOptions.Count);
    }

    private async Task SeedDeckRequirements(List<CardDto> cardDtos)
    {
        var cardLookup = await _context.Cards.ToDictionaryAsync(c => c.Code, c => c.Id);
        var deckRequirements = new List<DeckRequirement>();

        foreach (var dto in cardDtos.Where(c => c.DeckRequirements != null))
        {
            if (!cardLookup.TryGetValue(dto.Code, out var cardId))
                continue;
            deckRequirements.Add(new DeckRequirement { CardId = cardId });
        }

        _context.DeckRequirements.AddRange(deckRequirements);
        await _context.SaveChangesAsync();

        var deckReqLookup = await _context.DeckRequirements.ToDictionaryAsync(
            d => d.CardId,
            d => d.Id
        );
        var randoms = new List<DeckRequirementRandom>();

        foreach (var dto in cardDtos.Where(c => c.DeckRequirements?.Random != null))
        {
            if (!cardLookup.TryGetValue(dto.Code, out var cardId))
                continue;
            if (!deckReqLookup.TryGetValue(cardId, out var deckReqId))
                continue;

            foreach (var randomDto in dto.DeckRequirements!.Random!)
            {
                if (
                    !string.IsNullOrEmpty(randomDto.Target)
                    && !string.IsNullOrEmpty(randomDto.Value)
                )
                {
                    randoms.Add(
                        new DeckRequirementRandom
                        {
                            DeckRequirementId = deckReqId,
                            Target = randomDto.Target,
                            Value = randomDto.Value,
                        }
                    );
                }
            }
        }

        _context.DeckRequirementRandoms.AddRange(randoms);
        await _context.SaveChangesAsync();

        // Seed card choices
        foreach (var dto in cardDtos.Where(c => c.DeckRequirements?.Card != null))
        {
            if (!cardLookup.TryGetValue(dto.Code, out var cardId))
                continue;
            if (!deckReqLookup.TryGetValue(cardId, out var deckReqId))
                continue;

            foreach (var cardChoiceEntry in dto.DeckRequirements!.Card!)
            {
                var choice = new DeckRequirementCardChoice { DeckRequirementId = deckReqId };
                _context.DeckRequirementCardChoices.Add(choice);
                await _context.SaveChangesAsync();

                var cards = cardChoiceEntry
                    .Value.Values.Select(code => new DeckRequirementCard
                    {
                        DeckRequirementCardChoiceId = choice.Id,
                        CardCode = code,
                    })
                    .ToList();

                _context.DeckRequirementCards.AddRange(cards);
            }
        }

        await _context.SaveChangesAsync();
        _logger.LogInformation("Seeded {Count} deck requirements", deckRequirements.Count);
    }
}
