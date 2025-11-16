using Arkham.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Arkham.API.Data;

public class ArkhamDbContextFactory : IDesignTimeDbContextFactory<ArkhamDbContext>
{
    public ArkhamDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true);

        var configuration = configurationBuilder.Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ArkhamDbContext>().UseNpgsql(
            configuration.GetConnectionString("ArkhamDb")
        );

        return new ArkhamDbContext(dbContextOptionsBuilder.Options);
    }
}
