using Mediator;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Domain.Divisions.Queries;
using WePing.SmartPing.Spid.Handlers.Epreuves;

namespace WePing.SmartPing.Spid.Handlers.Divisions;

public class DivisionValidator : IPipelineBehavior<BrowseDivisionQuery, BrowseDivisionResponse>
{
    public IConfiguration Configuration { get; init; }
    public List<AvailableEpreuves> AvailableEpreuves { get; init; }

    public DivisionValidator(IConfiguration configuration)
    {
        Configuration = configuration;
        AvailableEpreuves = Configuration.GetSection("AvailableEpreuves").Get<List<AvailableEpreuves>>();
    }
    public ValueTask<BrowseDivisionResponse> Handle(BrowseDivisionQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<BrowseDivisionQuery, BrowseDivisionResponse> next)
    {
        if (request is null || (AvailableEpreuves != null && AvailableEpreuves.Count > 0 && !AvailableEpreuves.Select(x => x.Type).Any(x => x == request.Type)))
            throw new ArgumentException("Invalid Epreuve Type");
        return next(request, cancellationToken);
    }
}
