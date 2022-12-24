using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace WePing.PointCalculator.EntityFrameworkCore;

[ConnectionStringName(PointCalculatorDbProperties.ConnectionStringName)]
public interface IPointCalculatorDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Bareme> Baremes { get; set; }
}
