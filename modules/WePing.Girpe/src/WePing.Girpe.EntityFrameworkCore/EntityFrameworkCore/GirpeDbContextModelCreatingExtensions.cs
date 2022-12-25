using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using WePing.Girpe.Domain;
using WePing.Girpe.Joueurs;

namespace WePing.Girpe.EntityFrameworkCore;

public static class GirpeDbContextModelCreatingExtensions
{
    public static void ConfigureGirpe(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Club>(b =>
        {
            b.ToTable(GirpeDbProperties.DbTablePrefix + "Club", GirpeDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
        builder.Entity<Joueur>(b =>
        {
            b.ToTable(GirpeDbProperties.DbTablePrefix + "Joueur", GirpeDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
        builder.Entity<PartieSpid>(b =>
        {
            b.ToTable(GirpeDbProperties.DbTablePrefix + "PartiesSpid", GirpeDbProperties.DbSchema);

            b.ConfigureByConvention();

            b.HasKey(x => new { x.JoueurId, x.Date,x.NomPrenomAdversaire});
        });
    }
}
