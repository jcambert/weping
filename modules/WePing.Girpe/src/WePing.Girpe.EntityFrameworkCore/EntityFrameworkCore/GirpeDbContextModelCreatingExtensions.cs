using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using WePing.Girpe.Domain;

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
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(GirpeDbProperties.DbTablePrefix + "Questions", GirpeDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
