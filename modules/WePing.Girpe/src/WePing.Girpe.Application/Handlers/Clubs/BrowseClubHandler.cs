using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain.Clubs.Queries;

namespace WePing.Girpe.Handlers.Clubs;

public class BrowseClubHandler : BaseHandler<BrowseClubQuery, BrowseClubResponse>
{
    public BrowseClubHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override ValueTask<BrowseClubResponse> Handle(BrowseClubQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
