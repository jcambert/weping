using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
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
    public Task<List<ClubDto>> GetAllAsync()=>Service.GetAllAsync();

    [HttpGet]
    public Task<ClubDto> GetAsync(Guid id)=>Service.GetAsync(id);

    [HttpGet]
    [Route("bynumber")]
    public Task<ClubDto> GetByNumero(string numero)=>Service.GetByNumero(numero);

    /* [HttpPost]
     public Task<ClubDto> CreateAsync(CreateUpdateClubDto input)=>Service.CreateAsync(input);

     [HttpDelete]
     public Task DeleteAsync(Guid id)=>Service.DeleteAsync(id);

     [HttpGet("{id}")]
     public Task<ClubDto> GetAsync(Guid id)=>Service.GetAsync(id);
     [HttpGet]
     public Task<PagedResultDto<ClubDto>> GetListAsync([FromQuery]PagedAndSortedResultRequestDto input)=>Service.GetListAsync(input);
     [HttpPut]
     public Task<ClubDto> UpdateAsync(Guid id, CreateUpdateClubDto input)=>Service.UpdateAsync(id,input);*/
}
