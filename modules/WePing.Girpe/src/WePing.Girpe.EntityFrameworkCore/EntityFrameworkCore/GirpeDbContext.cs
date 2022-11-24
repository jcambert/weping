﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using WePing.Girpe.Clubs;

namespace WePing.Girpe.EntityFrameworkCore;

[ConnectionStringName(GirpeDbProperties.ConnectionStringName)]
public class GirpeDbContext : AbpDbContext<GirpeDbContext>, IGirpeDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<Club> Clubs { get; set; }
    public GirpeDbContext(DbContextOptions<GirpeDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureGirpe();
    }
}
