using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using WePing.Girpe.Domain;
using WePing.Girpe.Joueurs;

namespace WePing.Girpe.EntityFrameworkCore;

[ConnectionStringName(GirpeDbProperties.ConnectionStringName)]
public interface IGirpeDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
    DbSet<Club> Clubs { get; set; }
    DbSet<Joueur> Joueurs { get; set; }
    
}
