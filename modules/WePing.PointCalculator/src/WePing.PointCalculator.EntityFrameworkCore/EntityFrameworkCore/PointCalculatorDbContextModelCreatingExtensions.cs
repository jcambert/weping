using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace WePing.PointCalculator.EntityFrameworkCore;

public static class PointCalculatorDbContextModelCreatingExtensions
{
    public static void ConfigurePointCalculator(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Bareme>(b =>
        {
            b.ToTable(PointCalculatorDbProperties.DbTablePrefix + "Bareme", PointCalculatorDbProperties.DbSchema);
            b.ConfigureByConvention();
        });
        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(PointCalculatorDbProperties.DbTablePrefix + "Questions", PointCalculatorDbProperties.DbSchema);

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
