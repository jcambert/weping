using AutoMapper;
using Volo.Abp.AutoMapper;

namespace WePing.PointCalculator;

public class PointCalculatorApplicationAutoMapperProfile : Profile
{
    public PointCalculatorApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BaremeDto, Bareme>().ReverseMap();
    }
}
