using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WePing.PointCalculator.EntityFrameworkCore;

[DependsOn(
    typeof(PointCalculatorDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class PointCalculatorEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<PointCalculatorDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
        });
        
    }
}
