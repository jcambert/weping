using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using WePing.SmartPing.Domain.ClubDetails.Dto;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using GIRPE_DOMAIN = WePing.Girpe.Domain;
using SP_DTO = WePing.SmartPing.Domain.Clubs.Dto;
using SP_QUERY = WePing.SmartPing.Domain.Clubs.Queries;

namespace WePing.Girpe.Handlers.Clubs;

public class BrowseClubHandler : BaseHandler<BrowseClubQuery, BrowseClubResponse>
{
    protected IRepository<GIRPE_DOMAIN.Club, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<GIRPE_DOMAIN.Club, Guid>>();
    //  protected ISpidAppService Spid => LazyServiceProvider.LazyGetRequiredService<ISpidAppService>();
    public BrowseClubHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<BrowseClubResponse> Handle(BrowseClubQuery request, CancellationToken cancellationToken)
    {

        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();
        //queryable=queryable.Filter(x=>x.Numero,request.Numero);
        // var zz = queryable.ToList();
        if (!string.IsNullOrEmpty(request.Numero))
            queryable = queryable.Where(x => x.Numero == request.Numero);
        if (!string.IsNullOrEmpty(request.Code))
            queryable = queryable.Where(x => x.CodePostalSalle == request.Code);
        if (!string.IsNullOrEmpty(request.Dep))
            queryable = queryable.Where(x => x.CodePostalSalle.Substring(0, 2) == request.Dep);
        if (!string.IsNullOrEmpty(request.Ville))
            queryable = queryable.Where(x => x.VilleSalle == request.Ville);

       // var query = queryable;
        //var jj = query.ToList();
        //Execute the query and get the book with author
        var clubs = await AsyncExecuter.ToListAsync(queryable);
        bool fromdb = clubs.Count > 0;
        if (clubs.Count == 0)
        {
            //No club into Database->Trying from Spid
            clubs = await GetClubsFromSpid(ObjectMapper.Map<BrowseClubQuery, SP_QUERY.BrowseClubsQuery>(request));
            if (clubs.Count > 0)
            {
                await PopulateClubDetail(clubs);
                //while club didn't exist in DB, insert it!
               // var entities = ObjectMapper.Map<List<ClubDto>, List<GIRPE_DOMAIN.Club>>(clubsDto);
                await Repository.InsertManyAsync(clubs, true, cancellationToken);


                //return new BrowseClubResponse(ObjectMapper.Map<List<GIRPE_DOMAIN.Club>, List<ClubDto>>(entities)) { FromDatabase = false };
            }
            /*else
            {
                return new BrowseClubResponse(new()) { FromDatabase = false };
            }*/
        }
        //return new BrowseClubResponse(ObjectMapper.Map<List<GIRPE_DOMAIN.Club>, List<ClubDto>>(queryResult)) { FromDatabase = true };
        return new BrowseClubResponse(clubs) { FromDatabase = fromdb };

    }

    protected async Task<List<Club>> GetClubsFromSpid(SP_QUERY.BrowseClubsQuery query)
    {
        var clubs = await Spid.GetClubs(query);

        return ObjectMapper.Map<List<SP_DTO.ClubDto>, List<Club>>(clubs);
    }

    protected async Task PopulateClubDetail(List<Club> clubs)
    {
        var query = GetRequiredService<IGetClubDetailQuery>();
        foreach (var club in clubs)
        {
            query.Club = club.Numero;
            var club_detail_response = await Spid.GetClubDetail(query);
            ObjectMapper.Map<ClubDetailDto, Club>(club_detail_response, club);

        }
    }
}
