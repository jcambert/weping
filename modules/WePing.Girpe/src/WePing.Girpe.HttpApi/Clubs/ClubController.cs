﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using WePing.Girpe.Clubs.Dto;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Samples;
using WePing.SmartPing;
namespace WePing.Girpe.Clubs;

[Area(SmartPingRemoteServiceConsts.ModuleName)]
[RemoteService(Name = SmartPingRemoteServiceConsts.RemoteServiceName)]
[Route("api/girpe/club")]

public class ClubController : GirpeController, IClubAppService
{
    public ClubController(IClubAppService service)
    {
        Service=service;
    }

    public IClubAppService Service { get; init; }

    [HttpGet]
    [Route("all")]
    public Task<BrowseClubResponse> GetAllAsync([FromQuery] IBrowseClubQuery query) =>Service.GetAllAsync(query);


    [HttpGet]
    public Task<GetClubResponse> GetAsync([FromQuery] IGetClubQuery query)=>Service.GetAsync(query);

    

}
/*
public static class TaskExtensions
{
    public static Task<TTO> As<TFROM,TTO>(this Task<TFROM> from)
    {
        return default(Task<TTO>);
    }
}*/
