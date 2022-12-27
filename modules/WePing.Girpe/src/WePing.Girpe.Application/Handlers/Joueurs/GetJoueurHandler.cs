using System;
using System.Linq;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
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
        //var query = from joueur in queryable select joueur;

        //Execute the query r
        var joueur = await AsyncExecuter.FirstOrDefaultAsync(queryable);
        //JoueurDto joueurDto;
        bool from_db = joueur!= null;
        if (joueur == null)
        {

            //Club not exist in database
            //Retrieve it from SPID 
            joueur = await GetJoueurFromSpid(request.Licence);
            //Joueur didn't exist on SPID
            if (joueur == null || string.IsNullOrEmpty(joueur.Licence))
                throw new EntityNotFoundException(typeof(Joueur), request.Licence);
            if (request.ForceLoadClubIfNotSet)
            {
                var clubQuery = ObjectMapper.Map<Joueur, GetClubQuery>(joueur);
                
                var resp = await Mediator.Send(clubQuery);
                joueur.ClubId = resp.Club.Id;
            }

            await PopulateJoueurDetail(joueur,request.DetailOptions,cancellationToken);
            //while joueur didn't exist in DB, insert it!
            await Repository.InsertAsync(joueur, true, cancellationToken);


            //joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(result);
        }
        /*else
            joueurDto = ObjectMapper.Map<Joueur, JoueurDto>(queryResult);*/

        return new GetJoueurResponse(joueur) { FromDatabase = from_db };
    }



    protected async Task<Joueur> GetJoueurFromSpid(string licence)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<IGetJoueurDetailSpidClaQuery>();
        query.Licence = licence;
        var joueurDetail = await Spid.GetJoueurDetail(query);

        var joueur = ObjectMapper.Map<JoueurDetailSpidClaDto, Joueur>(joueurDetail);
        return joueur;
    }
    protected async Task<Club> GetClub(string numero)
    {
        var club_query = LazyServiceProvider.LazyGetRequiredService<IGetClubQuery>();
        club_query.Numero = numero;
        var resp = await Mediator.Send(club_query);
        return resp.Club;
    }

    protected async Task PopulateJoueurDetail(Joueur joueur,UpdateJoueurFromSpidOption options, CancellationToken cancellationToken)
    =>await UpdateJoueurService.Update(joueur,options,cancellationToken);
        
      
}
