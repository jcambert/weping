
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Handlers.Epreuves;

namespace WePing.SmartPing.Spid.Handlers.Divisions;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IPipelineBehavior<BrowseDivisionQuery, BrowseDivisionResponse>))]
public class DivisionValidator : IPipelineBehavior<BrowseDivisionQuery, BrowseDivisionResponse>
{
    public IConfiguration Configuration { get; init; }
    public List<AvailableEpreuves> AvailableEpreuves { get; init; }

    public DivisionValidator(IConfiguration configuration)
    {
        Configuration = configuration;
        AvailableEpreuves = Configuration.GetSection("AvailableEpreuves").Get<List<AvailableEpreuves>>();
    }

    public Task<BrowseDivisionResponse> Handle(BrowseDivisionQuery request, RequestHandlerDelegate<BrowseDivisionResponse> next, CancellationToken cancellationToken)
    {
        if (request is null || (AvailableEpreuves != null && AvailableEpreuves.Count > 0 && !AvailableEpreuves.Select(x => x.Type).Any(x => x == request.Type)))
            throw new ArgumentException("Invalid Epreuve Type");
        return next();
        //return next(request, cancellationToken);
    }
}
