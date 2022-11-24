using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace WePing.Data;

/* This is used if database provider does't define
 * IWePingDbSchemaMigrator implementation.
 */
public class NullWePingDbSchemaMigrator : IWePingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
