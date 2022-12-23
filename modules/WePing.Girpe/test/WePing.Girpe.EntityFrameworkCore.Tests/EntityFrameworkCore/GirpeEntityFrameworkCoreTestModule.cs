using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Sqlite.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp;
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
    SqliteConnection sqliteConnection;
    bool inMemory = true;
    string source = "";
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        
        try
        {
            var configuration = context.Services.GetConfiguration();
            var mode = configuration["db_test:mode"];
            inMemory = mode == "inmemory";
            source = configuration[$"db_test:ConnectionStrings:{mode}"];
            var connstring = $"Data Source={source}";
            sqliteConnection = CreateDatabaseAndGetConnection(connstring);
        }
        catch {
            sqliteConnection = CreateDatabaseAndGetConnection();
        }

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
  
    public override async Task OnApplicationShutdownAsync(ApplicationShutdownContext context)
    {
        await base.OnApplicationShutdownAsync(context);
        
        await sqliteConnection.CloseAsync();
       /* if (inMemory) return;
        try
        {
            FileInfo fi = new FileInfo(source);
            fi.Delete();
        }
        catch { }*/
    }
}
