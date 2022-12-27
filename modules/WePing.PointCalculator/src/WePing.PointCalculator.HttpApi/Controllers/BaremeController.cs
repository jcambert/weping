using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace WePing.PointCalculator.Controllers;

[Area(PointCalculatorRemoteServiceConsts.ModuleName)]
[RemoteService(Name = PointCalculatorRemoteServiceConsts.RemoteServiceName)]
[Route("api/point/bareme")]
public class BaremeController : PointCalculatorController, IBaremeAppService
{
    IBaremeAppService _service=> LazyServiceProvider.LazyGetRequiredService<IBaremeAppService>();

    [HttpPost]
    public Task<BaremeDto> CreateAsync(BaremeDto input)
    => _service.CreateAsync(input);
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    =>_service.DeleteAsync(id);
    [HttpGet("{id}")]
    public Task<BaremeDto> GetAsync(Guid id)
    => _service.GetAsync(id);
    [HttpGet]
    public Task<PagedResultDto<BaremeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    => _service.GetListAsync(input);
    [HttpPut]
    public Task<BaremeDto> UpdateAsync(Guid id, BaremeDto input)
    =>_service.UpdateAsync(id,input);
}
