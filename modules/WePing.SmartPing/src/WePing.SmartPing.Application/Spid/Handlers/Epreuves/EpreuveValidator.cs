using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.DependencyInjection;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Domain.Epreuves.Queries;

namespace WePing.SmartPing.Spid.Handlers.Epreuves;

[Dependency(ServiceLifetime.Transient), ExposeServices(typeof(IPipelineBehavior<BrowseEpreuveQuery, BrowseEpreuveResponse>))]
public class EpreuveValidator : IPipelineBehavior<BrowseEpreuveQuery, BrowseEpreuveResponse>
{
    public IConfiguration Configuration { get; init; }
    public List<AvailableEpreuves> AvailableEpreuves { get; init; }

    public EpreuveValidator(IConfiguration configuration)
	{
        Configuration = configuration;
        AvailableEpreuves = Configuration.GetSection("AvailableEpreuves").Get<List<AvailableEpreuves>>();
    }

    public Task<BrowseEpreuveResponse> Handle(BrowseEpreuveQuery request, RequestHandlerDelegate<BrowseEpreuveResponse> next, CancellationToken cancellationToken)
    {
        if (request is null || (AvailableEpreuves != null && AvailableEpreuves.Count > 0 && !AvailableEpreuves.Select(x => x.Type).Any(x => x == request.Type)))
            throw new ArgumentException("Invalid Epreuve Type");
        return next();
       // return next(request, cancellationToken);
        //throw new NotImplementedException();
    }
}

public class AvailableEpreuves
{
    public string Type { get; set; }
    public string Libelle { get; set; }
}