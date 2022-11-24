using System.Threading.Tasks;

namespace WePing.Data;

public interface IWePingDbSchemaMigrator
{
    Task MigrateAsync();
}
