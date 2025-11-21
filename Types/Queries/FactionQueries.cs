using Arkham.API.Data;
using Arkham.API.Entities;

namespace Arkham.API.Types.Queries;

[QueryType]
public class FactionQueries
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Faction> GetFactions(ArkhamDbContext context) => context.Factions;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Faction> GetFactionByCode(ArkhamDbContext context, string code) =>
        context.Factions.Where(f => f.Code == code);
}
