using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace WePing.Girpe.EntityFrameworkCore;

[DependsOn(
    typeof(GirpeTestBaseModule),
    typeof(GirpeEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
public class GirpeEntityFrameworkCoreTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var mode = configuration["db_test:mode"];
        var connstring = configuration[$"db_test:ConnectionStrings:{mode}"];
        var sqliteConnection = CreateDatabaseAndGetConnection(connstring);

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(abpDbContextConfigurationContext =>
            {
                abpDbContextConfigurationContext.DbContextOptions.UseSqlite(sqliteConnection);
            });
        });
    }

    private static SqliteConnection CreateDatabaseAndGetConnection(string connstring= "Data Source=:memory:")
    {
        var connection = new SqliteConnection(connstring);
        connection.Open();

        new GirpeDbContext(
            new DbContextOptionsBuilder<GirpeDbContext>().UseSqlite(connection).Options
        ).GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }
}
