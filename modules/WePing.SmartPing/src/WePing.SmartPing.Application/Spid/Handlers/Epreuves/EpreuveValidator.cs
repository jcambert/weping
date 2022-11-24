using Mediator;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Domain.Epreuves.Queries;
using WePing.SmartPing.Spid.Handlers.Organismes;

namespace WePing.SmartPing.Spid.Handlers.Epreuves;

public class EpreuveValidator : IPipelineBehavior<BrowseEpreuveQuery, BrowseEpreuveResponse>
{
    public IConfiguration Configuration { get; init; }
    public List<AvailableEpreuves> AvailableEpreuves { get; init; }

    public EpreuveValidator(IConfiguration configuration)
	{
        Configuration = configuration;
        AvailableEpreuves = Configuration.GetSection("AvailableEpreuves").Get<List<AvailableEpreuves>>();
    }

    public ValueTask<BrowseEpreuveResponse> Handle(BrowseEpreuveQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<BrowseEpreuveQuery, BrowseEpreuveResponse> next)
    {
        if (request is null || (AvailableEpreuves != null && AvailableEpreuves.Count > 0 && !AvailableEpreuves.Select(x => x.Type).Any(x => x == request.Type)))
            throw new ArgumentException("Invalid Epreuve Type");
        return next(request, cancellationToken);
    }
}

public class AvailableEpreuves
{
    public string Type { get; set; }
    public string Libelle { get; set; }
}