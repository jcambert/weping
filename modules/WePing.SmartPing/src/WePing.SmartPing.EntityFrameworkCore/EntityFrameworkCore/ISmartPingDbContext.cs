using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace WePing.SmartPing.EntityFrameworkCore;

[ConnectionStringName(SmartPingDbProperties.ConnectionStringName)]
public interface ISmartPingDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
