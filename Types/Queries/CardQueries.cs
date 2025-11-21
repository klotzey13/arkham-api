using Arkham.API.Data;
using Arkham.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arkham.API.Types.Queries;

[QueryType]
public class CardQueries
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Card> GetCards(ArkhamDbContext context) => context.Cards;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Card> GetCardByCode(ArkhamDbContext context, string code) =>
        context.Cards.Where(c => c.Code == code);

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Card> GetCardsByFaction(ArkhamDbContext context, string factionCode) =>
        context.Cards.Where(c => c.Faction!.Code == factionCode);

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Card> GetCardsByPack(ArkhamDbContext context, string packCode) =>
        context.Cards.Where(c => c.Pack!.Code == packCode);

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Card> GetInvestigators(ArkhamDbContext context) =>
        context.Cards.Where(c => c.Type!.Code == "investigator");

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Card> GetCardsByType(ArkhamDbContext context, string typeCode) =>
        context.Cards.Where(c => c.Type!.Code == typeCode);
}
