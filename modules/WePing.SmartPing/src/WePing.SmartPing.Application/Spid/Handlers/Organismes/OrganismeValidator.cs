using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Domain.Organismes.Queries;

namespace WePing.SmartPing.Spid.Handlers.Organismes;

public class OrganismeValidator : IPipelineBehavior<BrowseOrganismeQuery, BrowseOrganismeResponse>
{

    public IConfiguration Configuration { get; init; }
    public List<AvailableOrganismes> AvailableOrganismes { get;  }
    public OrganismeValidator(IConfiguration configuration)
    {
        Configuration = configuration;
        AvailableOrganismes = Configuration.GetSection("AvailableOrganismes").Get<List<AvailableOrganismes>>();

    }
   
    public ValueTask<BrowseOrganismeResponse> Handle(BrowseOrganismeQuery request, CancellationToken cancellationToken, MessageHandlerDelegate<BrowseOrganismeQuery, BrowseOrganismeResponse> next)
    {
        
        if(request is null || (AvailableOrganismes!=null && AvailableOrganismes.Count>0 && !AvailableOrganismes.Select(x => x.Code).Any(x => x == request.Type)))
            throw new ArgumentException("Invalid Organisme Type");
        return next(request, cancellationToken);
    }
}

//public sealed record AvailableOrganismes(string Code,string Libelle);

public class AvailableOrganismes
{
    public string Code { get; set; }
    public string  Libelle { get; set; }
}
