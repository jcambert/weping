using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace WePing.PointCalculator;

public class BaremeDto:EntityDto<Guid>
{
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Ecart { get; set; }

    [Required]
    public double VictoireNormale { get; set; }

    [Required]
    public double VictoireAnormale { get; set; }

    [Required]
    public double DefaiteNormale { get; set; }

    [Required]
    public double DefaiteAnormale { get; set; }
}
