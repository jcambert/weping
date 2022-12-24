using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace WePing.PointCalculator.EntityFrameworkCore;

[ConnectionStringName(PointCalculatorDbProperties.ConnectionStringName)]
public class PointCalculatorDbContext : AbpDbContext<PointCalculatorDbContext>, IPointCalculatorDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Bareme> Baremes { get; set; }
    public PointCalculatorDbContext(DbContextOptions<PointCalculatorDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePointCalculator();
    }
}
