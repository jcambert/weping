using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace WePing.PointCalculator;

public class Bareme: Entity<Guid>
{
    [Column("ecart")]
    public int Ecart { get; set; }
    [Column("vn")]
    public double VictoireNormale { get; set; }
    [Column("va")]
    public double VictoireAnormale { get; set; }
    [Column("dn")]
    public double DefaiteNormale { get; set; }

    [Column("da")]
    public double DefaiteAnormale { get; set; }
}
