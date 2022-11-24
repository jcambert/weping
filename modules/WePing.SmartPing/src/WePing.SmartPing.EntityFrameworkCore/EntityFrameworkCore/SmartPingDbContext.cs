using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace WePing.SmartPing.EntityFrameworkCore;

[ConnectionStringName(SmartPingDbProperties.ConnectionStringName)]
public class SmartPingDbContext : AbpDbContext<SmartPingDbContext>, ISmartPingDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public SmartPingDbContext(DbContextOptions<SmartPingDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSmartPing();
    }
}
