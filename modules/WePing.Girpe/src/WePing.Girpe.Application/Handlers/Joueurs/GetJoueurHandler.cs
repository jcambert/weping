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
using WePing.Girpe.Services;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.Girpe.Handlers.Joueurs;

public class GetJoueurHandler : BaseHandler<GetJoueurQuery, GetJoueurResponse>
{
    protected IRepository<Joueur, Guid> Repository=> GetRequiredService<IRepository<Joueur, Guid>>();
    protected UpdateJoueurFromSpidDomainService UpdateJoueurService=>GetRequiredService<UpdateJoueurFromSpidDomainService>();    
 
    public GetJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<GetJoueurResponse> Handle(GetJoueurQuery request, CancellationToken cancellationToken)
    {
        // Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();

        var mappedRequest = ObjectMapper.Map<GetJoueurQuery, Joueur>(request);
        queryable = queryable.Filter(mappedRequest);

        ////Prepare a query 
        var query = from joueur in queryable select joueur;

        //Execute the query r
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        JoueurDto joueurDto;
        bool from_db = queryResult != null;
        if (queryResult == null)
        {

            //Club not exist in database
            //Retrieve it from SPID 
            joueurDto = await GetJoueurFromSpid(request.Licence);
            //Joueur didn't exist on SPID
            if (joueurDto == null || string.IsNullOrEmpty(joueurDto.Licence))
                throw new EntityNotFoundException(typeof(Joueur), request.Licence);
            if (request.ForceLoadClubIfNotSet)
            {
                var clubQuery = ObjectMapper.Map<JoueurDto, GetClubQuery>(joueurDto);
                
                var resp = await Mediator.Send(clubQuery);
                joueurDto.ClubId = resp.Club.Id;
            }

            await PopulateJoueurDetail(joueurDto,request.DetailOptions,cancellationToken);
            //while joueur didn't exist in DB, insert it!
            var result = await Repository.InsertAsync(ObjectMapper.Map<JoueurDto, Joueur>(joueurDto), true, cancellationToken);


            joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(result);
        }
        else
            joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(queryResult);

        return new GetJoueurResponse(joueurDto) { FromDatabase = from_db };
    }



    protected async Task<JoueurDto> GetJoueurFromSpid(string licence)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<IGetJoueurDetailSpidClaQuery>();
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

    protected async Task PopulateJoueurDetail(JoueurDto joueur,UpdateJoueurFromSpidOption options, CancellationToken cancellationToken)
    =>await UpdateJoueurService.Update(joueur,options,cancellationToken);
        
      
}
