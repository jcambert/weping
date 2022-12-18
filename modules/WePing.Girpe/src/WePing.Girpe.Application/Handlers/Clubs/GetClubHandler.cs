using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using WePing.SmartPing.Spid;
using GIRPE_DTO = WePing.Girpe.Clubs.Dto;
using SP_CLUB_DTO = WePing.SmartPing.Domain.Clubs.Dto;
using SP_DETAIL_DTO = WePing.SmartPing.Domain.ClubDetails.Dto;
namespace WePing.Girpe.Handlers.Clubs;


public class GetClubHandler : BaseHandler<GetClubQuery, GetClubResponse>
{
    public GetClubHandler():base(null)
    {

    }
    public GetClubHandler(IAbpLazyServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    protected IRepository<Club, Guid> Repository => LazyServiceProvider.LazyGetRequiredService<IRepository<Club, Guid>>();
    protected ISpidAppService Spid=>LazyServiceProvider.LazyGetRequiredService<ISpidAppService>();  
    public override async Task<GetClubResponse> Handle(GetClubQuery request, CancellationToken cancellationToken)
    {
        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();

        var mappedRequest=ObjectMapper.Map <GetClubQuery,Club>(request);
        //var pred=mappedRequest.GetPredicate();
        queryable = queryable.Filter(mappedRequest);
        //Prepare a query   
        //var query = from club in queryable where club.Numero == request.Numero select new { club };
        var query = from club in queryable select new { club };
        //Execute the query and get the book with author
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
        GIRPE_DTO.ClubDto clubDto;
        bool from_db = queryResult!=null;
        if (queryResult == null)
        {
            //Club not exist in database
            //Retrieve it from SPID 
            clubDto = await GetClubFromSpid(request.Numero);
            if (clubDto == null)
                //Club didn't exist on SPID
                throw new EntityNotFoundException(typeof(Club), request.Numero);
            clubDto = await GetClubDetailFromSpid(clubDto);
            //while club didn't exist in DB, insert it!
            var result = await Repository.InsertAsync(ObjectMapper.Map<GIRPE_DTO.ClubDto, Club>(clubDto));
       
            //
            clubDto = ObjectMapper.Map<Club,GIRPE_DTO.ClubDto>(result);
        }
        else
            clubDto = ObjectMapper.Map<Club, GIRPE_DTO.ClubDto>(queryResult.club);
        return new GetClubResponse(clubDto) { FromDatabase=from_db};
    }
    protected async Task<GIRPE_DTO.ClubDto> GetClubFromSpid(string numero)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.Clubs.Queries.IGetClubQuery>();
        query.Numero = numero;
        var club = await Spid.GetClub(query);

        var clubDto = ObjectMapper.Map<SP_CLUB_DTO.ClubDto, GIRPE_DTO.ClubDto>(club);
        return clubDto;
    }
    protected async Task<GIRPE_DTO.ClubDto> GetClubDetailFromSpid(GIRPE_DTO.ClubDto dto)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.ClubDetails.Queries.IGetClubDetailQuery>();
        query.Club = dto.Numero;
        var club = await Spid.GetClubDetail(query);

        var clubDto = ObjectMapper.Map<SP_DETAIL_DTO.ClubDetailDto, GIRPE_DTO.ClubDto>(club, dto);

        return clubDto;
    }
}
