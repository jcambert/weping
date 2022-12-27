using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
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
    //protected ISpidAppService Spid=>LazyServiceProvider.LazyGetRequiredService<ISpidAppService>();  
    public override async Task<GetClubResponse> Handle(GetClubQuery request, CancellationToken cancellationToken)
    {
        //Get the IQueryable<Club> from the repository
        var queryable = await Repository.GetQueryableAsync();

        var mappedRequest=ObjectMapper.Map <GetClubQuery,Club>(request);
        //var pred=mappedRequest.GetPredicate();
        queryable = queryable.Filter(mappedRequest);
        //Prepare a query   
        //var query = from club in queryable where club.Numero == request.Numero select new { club };
        //var query = from club in queryable select new { club };
        //Execute the query and get the book with author
        var club= await AsyncExecuter.FirstOrDefaultAsync(queryable);
        //GIRPE_DTO.ClubDto clubDto;
        bool from_db = club!=null;
        if (club == null)
        {
            //Club not exist in database
            //Retrieve it from SPID 
            club = await GetClubFromSpid(request.Numero);
            if (club == null)
                //Club didn't exist on SPID
                throw new EntityNotFoundException(typeof(Club), request.Numero);
            await GetClubDetailFromSpid(club);
            //while club didn't exist in DB, insert it!
            await Repository.InsertAsync(club);
       
            //
            //clubDto = ObjectMapper.Map<Club,GIRPE_DTO.ClubDto>(result);
        }
        //else
        //    clubDto = ObjectMapper.Map<Club, GIRPE_DTO.ClubDto>(queryResult.club);
        return new GetClubResponse(club) { FromDatabase=from_db};
    }
    protected async Task<Club> GetClubFromSpid(string numero)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.Clubs.Queries.IGetClubQuery>();
        query.Numero = numero;
        var clubSpid = await Spid.GetClub(query);

        var club = ObjectMapper.Map<SP_CLUB_DTO.ClubDto, Club>(clubSpid);
        return club;
    }
    protected async Task GetClubDetailFromSpid(Club club)
    {
        var query = LazyServiceProvider.LazyGetRequiredService<SmartPing.Domain.ClubDetails.Queries.IGetClubDetailQuery>();
        query.Club = club.Numero;
        var clubSpidDetail = await Spid.GetClubDetail(query);

        ObjectMapper.Map<SP_DETAIL_DTO.ClubDetailDto, Club>(clubSpidDetail, club);

    }
}
