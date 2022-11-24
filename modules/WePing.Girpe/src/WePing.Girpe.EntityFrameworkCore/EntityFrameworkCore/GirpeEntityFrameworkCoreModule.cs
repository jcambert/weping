using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace WePing.Girpe.EntityFrameworkCore;

[DependsOn(
    typeof(GirpeDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class GirpeEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<GirpeDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities:true);
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
