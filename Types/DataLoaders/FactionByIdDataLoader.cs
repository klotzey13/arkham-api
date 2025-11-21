using Arkham.API.Data;
using Arkham.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arkham.API.Types.DataLoaders;

public class FactionByIdDataLoader : BatchDataLoader<int, Faction>
{
    private readonly IDbContextFactory<ArkhamDbContext> _contextFactory;

    public FactionByIdDataLoader(
        IDbContextFactory<ArkhamDbContext> contextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null
    )
        : base(batchScheduler, options ?? new DataLoaderOptions())
    {
        _contextFactory = contextFactory;
    }

    protected override async Task<IReadOnlyDictionary<int, Faction>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken
    )
    {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);

        return await context
            .Factions.Where(f => keys.Contains(f.Id))
            .ToDictionaryAsync(f => f.Id, cancellationToken);
    }
}
