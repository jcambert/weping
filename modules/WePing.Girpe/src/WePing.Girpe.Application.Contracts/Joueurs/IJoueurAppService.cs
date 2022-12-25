using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Joueurs;

public interface IJoueurAppService:IApplicationService
{
    Task<BrowseJoueurResponse> GetForClub(IBrowseJoueurQuery query);

    Task<GetJoueurResponse> GetByLicence(IGetJoueurQuery query);

    Task<UpdateJoueurResponse> Update(IUpdateJoueurQuery query);
}
