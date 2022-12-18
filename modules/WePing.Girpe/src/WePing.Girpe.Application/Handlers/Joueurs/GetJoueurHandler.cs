using System;
using System.Linq;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;
using WePing.SmartPing.Domain.Joueurs.Dto;

namespace WePing.Girpe.Handlers.Joueurs;

public class GetJoueurHandler : BaseHandler<GetJoueurQuery, GetJoueurResponse>
{
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
    
    //protected IGetClubQuery GetClubQuery => LazyServiceProvider.LazyGetRequiredService<IGetClubQuery>();

    public GetJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<GetJoueurResponse> Handle(GetJoueurQuery request, CancellationToken cancellationToken)
    {
        // Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();

        var mappedRequest = ObjectMapper.Map<GetJoueurQuery, Joueur>(request);
        queryable = queryable.Filter(mappedRequest);

        ////Prepare a query to join books and authors
        //var query = from joueur in queryable where joueur.Licence == request.Licence select new { joueur };
        var query = from joueur in queryable select new { joueur };

        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        JoueurDto joueurDto;
        bool from_db = queryResult != null;
        if (queryResult == null)
        {

            //Club not exist in database
            //Retrieve it from SPID 
            joueurDto = await GetJoueurFromSpid(request.Licence);
            //Joueur didn't exist on SPID
            if (joueurDto == null)
                throw new EntityNotFoundException(typeof(Joueur), request.Licence);
            if (request.RetrieveClub)
            {
                var clubQuery=ObjectMapper.Map<JoueurDto, GetClubQuery>(joueurDto);
                //var clubQuery = GetClubQuery;
                //clubQuery.Numero = joueurDto.NumeroClub;
                var resp = await Mediator.Send(clubQuery);
                joueurDto.ClubId = resp.Club.Id;
            }

            //while joueur didn't exist in DB, insert it!
            var result = await Repository.InsertAsync(ObjectMapper.Map<JoueurDto, Joueur>(joueurDto),true,cancellationToken);


            joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(result);
        }
        else
            joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(queryResult.joueur);

        return new GetJoueurResponse(joueurDto) { FromDatabase = from_db };
    }

    protected async Task<JoueurDto> GetJoueurFromSpid(string licence)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.Joueurs.Queries.IGetJoueurDetailSpidClaQuery>();
        query.Licence = licence;
        var joueur = await Spid.GetJoueurDetail(query);

        var joueurDto = ObjectMapper.Map<JoueurDetailSpidClaDto, JoueurDto>(joueur);
        return joueurDto;
    }
    protected async Task<ClubDto> GetClub(string numero)
    {
        var club_query = LazyServiceProvider.LazyGetRequiredService<IGetClubQuery>();
        club_query.Numero = numero;
        var resp = await Mediator.Send(club_query);
        return resp.Club;
    }
}
