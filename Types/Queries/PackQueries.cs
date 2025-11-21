using Arkham.API.Data;
using Arkham.API.Entities;

namespace Arkham.API.Types.Queries;

[QueryType]
public class PackQueries
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Pack> GetPacks(ArkhamDbContext context) => context.Packs;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Pack> GetPackByCode(ArkhamDbContext context, string code) =>
        context.Packs.Where(p => p.Code == code);
}
