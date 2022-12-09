using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.SmartPing.Spid;
using GIRPE_DOMAIN = WePing.Girpe.Domain;
using SP_DTO = WePing.SmartPing.Domain.Clubs.Dto;
using SP_QUERY = WePing.SmartPing.Domain.Clubs.Queries;

namespace WePing.Girpe.Handlers.Clubs;

public class BrowseClubHandler : BaseHandler<BrowseClubQuery, BrowseClubResponse>
{
    protected IRepository<GIRPE_DOMAIN.Club, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<GIRPE_DOMAIN.Club, Guid>>();
    protected ISpidAppService Spid => LazyServiceProvider.LazyGetRequiredService<ISpidAppService>();
    public BrowseClubHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<BrowseClubResponse> Handle(BrowseClubQuery request, CancellationToken cancellationToken)
    {

        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();
        //queryable=queryable.Filter(x=>x.Numero,request.Numero);

        if (!string.IsNullOrEmpty(request.Numero))
            queryable = queryable.Where(x => x.Numero == request.Numero);
        if (!string.IsNullOrEmpty(request.Code))
            queryable = queryable.Where(x => x.CodePostalSalle == request.Code);
        if (!string.IsNullOrEmpty(request.Dep))
            queryable = queryable.Where(x => x.CodePostalSalle.Substring(0,3) == request.Dep);
        if (!string.IsNullOrEmpty(request.Ville))
            queryable = queryable.Where(x => x.VilleSalle == request.Ville);

        var query = queryable;
        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.ToListAsync(query);
        if (queryResult.Count == 0 )
        {
            //No club into Database->Trying from Spid
            var clubsDto = await GetClubFromSpid(ObjectMapper.Map<BrowseClubQuery, SP_QUERY.BrowseClubsQuery > (request));
            if (clubsDto.Count>0)
            {
                //while club didn't exist in DB, insert it!
                var entities = ObjectMapper.Map<List<ClubDto>, List<GIRPE_DOMAIN.Club>>(clubsDto);
                await Repository.InsertManyAsync(entities,true);
                

                return new BrowseClubResponse(ObjectMapper.Map<List<GIRPE_DOMAIN.Club>, List<ClubDto>>(entities)) { FromDatabase = false };
            }
            else
            {
                return new BrowseClubResponse(new()) { FromDatabase = false };
            }
        }
            return new BrowseClubResponse(ObjectMapper.Map<List<GIRPE_DOMAIN.Club>, List<ClubDto>>(queryResult)) { FromDatabase = true };

        
    }

    protected async Task<List<ClubDto>> GetClubFromSpid(SP_QUERY.BrowseClubsQuery query)    {
        var clubs = await Spid.GetClubs(query);
        return ObjectMapper.Map<List<SP_DTO.ClubDto>, List<ClubDto>>(clubs);
    }
}
