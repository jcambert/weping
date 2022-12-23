using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace WePing.EntityFrameworkCore;

[DependsOn(
    typeof(WePingEntityFrameworkCoreModule),
    typeof(WePingTestBaseModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
    )]
public class WePingEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection _sqliteConnection;

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

 

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }

    private static SqliteConnection CreateDatabaseAndGetConnection(string connstring = "Data Source=:memory:")
    {
        var connection = new SqliteConnection(connstring);
        connection.Open();

        var options = new DbContextOptionsBuilder<WePingDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new WePingDbContext(options))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        return connection;
    }
}
