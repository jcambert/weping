using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Services;

public class JoueurAppService : GirpeAppService,IJoueurAppService
{

    public JoueurAppService(IMediator mediator):base(mediator){}

    public async Task<GetJoueurResponse> GetByLicence(IGetJoueurQuery query)
   => await Mediator.Send(query);

    /*

    public async Task<List<JoueurDto>> GetForClub(Guid clubId)
    {
        Check.NotNull(clubId, nameof(clubId));

        // Get the IQueryable<Joueur> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query 
        var query = from joueurs in queryable

                    where joueurs.ClubId == clubId
                    select joueurs;

        //Execute the query 
        var queryResult = await AsyncExecuter.ToListAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Joueur), clubId);
        }

        List<JoueurDto> result = ObjectMapper.Map<List<Joueur>, List<JoueurDto>>(queryResult);

        return result;
    }*/

    public async Task<BrowseJoueurResponse> GetForClub(IBrowseJoueurQuery query)
        => await Mediator.Send(query);
}
