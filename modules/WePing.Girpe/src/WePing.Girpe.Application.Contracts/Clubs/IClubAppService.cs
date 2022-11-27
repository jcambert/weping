﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;

namespace WePing.Girpe.Clubs;

public interface IClubAppService :IApplicationService
    
{
    Task<BrowseClubResponse> GetAllAsync(IBrowseClubQuery query);

    Task<GetClubResponse> GetAsync(IGetClubQuery query);

    
}