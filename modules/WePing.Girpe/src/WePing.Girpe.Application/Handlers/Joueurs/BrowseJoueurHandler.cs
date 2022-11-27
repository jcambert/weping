﻿using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Domain;
using WePing.Girpe.Domain.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;
using WePing.SmartPing.Domain.Joueurs.Dto;

namespace WePing.Girpe.Handlers.Joueurs;

public class BrowseJoueurHandler : BaseHandler<BrowseJoueurQuery, BrowseJoueurResponse>
{
    protected IRepository<Joueur, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Joueur, Guid>>();

    protected SmartPing.Spid.ISpidAppService Spid => LazyServiceProvider.LazyGetRequiredService<SmartPing.Spid.ISpidAppService>();

    public BrowseJoueurHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async ValueTask<BrowseJoueurResponse> Handle(BrowseJoueurQuery request, CancellationToken cancellationToken)
    {
        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join books and authors
        var query = from joueur in queryable where joueur.ClubId == request.ClubId select joueur;

        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.ToListAsync(query);

        List<JoueurDto> joueursDto = new();
        if (queryResult == null ||queryResult.Count==0)
        {
            //Joueurs not exist in database
            //Retrieve it from SPID 
             joueursDto = await GetJoueursClassementFromSpid(request.ClubNumero);
            if (joueursDto.Count > 0)
            {

            //while club didn't exist in DB, insert it!
            }
        }

        return new BrowseJoueurResponse( joueursDto);
    }
    protected async Task<List<JoueurDto>> GetJoueursClassementFromSpid(string numeroClub)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.Joueurs.Queries.IBrowseJoueurClassementQuery>();
        query.Club = numeroClub;

        var joueurs = await Spid.GetJoueursClassement(query);

        var res=ObjectMapper.Map<List<JoueurClassementDto>, List<JoueurDto>>(joueurs);
        return res;
    }

}
