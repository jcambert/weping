using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;

namespace WePing.Girpe.Clubs;

public interface IClubAppService :IApplicationService
    
{
    Task<List<ClubDto>> GetAllAsync();

    Task<ClubDto> GetAsync(IGetClubQuery query);

    
}
