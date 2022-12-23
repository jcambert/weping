using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;
using WePing.Girpe.Services;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Queries;

namespace WePing.Girpe.Handlers.Joueurs;

public class BrowseJoueurHandler : BaseHandler<BrowseJoueurQuery, BrowseJoueurResponse>
{
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();
    protected IClubAppService ClubService => LazyServiceProvider.LazyGetRequiredService<IClubAppService>();

    protected UpdateJoueurFromSpidDomainService UpdateJoueurService => GetRequiredService<UpdateJoueurFromSpidDomainService>();
    //protected SmartPing.Spid.ISpidAppService Spid => LazyServiceProvider.LazyGetRequiredService<SmartPing.Spid.ISpidAppService>();

    public BrowseJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<BrowseJoueurResponse> Handle(BrowseJoueurQuery request, CancellationToken cancellationToken)
    {
        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();
        var mappedRequest = ObjectMapper.Map<BrowseJoueurQuery, Joueur>(request);


       // var query = queryable;
        var query = from joueurs in queryable select joueurs;
        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.ToListAsync(query);
        bool from_db = queryResult != null;
        List<JoueurDto> joueursDto = new();
        if (queryResult.Count == 0)
        {
            //Joueurs not exist in database
            //Retrieve it from SPID 
            joueursDto = await GetJoueurFromSpid(request.ClubNumero);
            if (joueursDto.Count > 0)
            {
                if (request.ForceLoadClubIfNotSet)
                {
                    var joueurs_without_club = joueursDto.Where(x => x.ClubId == Guid.Empty).ToList();
                    var clubs_not_loaded = joueurs_without_club.Select(x => x.NumeroClub).Distinct().ToList();
                    var clubs_loaded_responses = await LoadClubs(clubs_not_loaded);
                    foreach (var j in joueurs_without_club)
                    {
                        j.ClubId = clubs_loaded_responses.Where(x => x.Item1 == j.NumeroClub).Select(x => x.Item2.Club).FirstOrDefault()?.Id ?? Guid.Empty;
                    }
                }
                await PopulateJoueurDetail(joueursDto,cancellationToken);
                //while club didn't exist in DB, insert it!
                var entities = ObjectMapper.Map<List<JoueurDto>, List<Joueur>>(joueursDto);
                await Repository.InsertManyAsync(entities, true, cancellationToken);
                joueursDto.Clear();
                joueursDto = ObjectMapper.Map<List<Joueur>, List<JoueurDto>>(entities);
            }
        }
        else
            ObjectMapper.Map<List<Joueur>, List<JoueurDto>>(queryResult);

        return new BrowseJoueurResponse(joueursDto) { FromDatabase = from_db };
    }
    protected async Task<List<JoueurDto>> GetJoueurFromSpid(string numeroClub)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<IBrowseJoueurClassementQuery>();
        query.Club = numeroClub;

        var joueurs = await Spid.GetJoueursClassement(query);

        var res = ObjectMapper.Map<List<JoueurClassementDto>, List<JoueurDto>>(joueurs);
        return res;
    }

    protected async Task PopulateJoueurDetail(List<JoueurDto> joueurs, CancellationToken cancellationToken)
    {
        //var query1 = GetRequiredService<IGetJoueurDetailSpidQuery>();
        //var query2 = GetRequiredService<IGetJoueurDetailClassementQuery>();
        foreach (var joueur in joueurs)
        {
            await UpdateJoueurService.Update(joueur,UpdateJoueurFromSpidOption.Spid | UpdateJoueurFromSpidOption.Cla,cancellationToken);
            /*query1.Licence = joueur.Licence;
            var joueur_detail_response1 = await Spid.GetJoueurDetail(query1);
            ObjectMapper.Map<JoueurDetailSpidDto, JoueurDto>(joueur_detail_response1, joueur);

            query2.Licence= joueur.Licence;
            var joueur_detail_response2 = await Spid.GetJoueurDetail(query2);
            ObjectMapper.Map<JoueurDetailClassementDto, JoueurDto>(joueur_detail_response2, joueur);
            */
        }
    }

    protected async Task<List<(string,GetClubResponse)>> LoadClubs(List<string> numeroClubs)
    {
        List<(string, GetClubResponse)> result = new();
        var query = GetRequiredService<IGetClubQuery>();
        foreach (var numero in numeroClubs)
        {
            query.Numero = numero;
            result.Add((numero, await ClubService.GetAsync(query)));
            
        }
        return result;
    }
}

