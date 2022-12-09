using Microsoft.AspNetCore.Authorization;

namespace WePing.Girpe.Samples;

public class SampleAppService : GirpeAppService, ISampleAppService
{
    public SampleAppService(IMediator mediator) : base(mediator)
    {
    }

    public Task<SampleDto> GetAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }

    [Authorize]
    public Task<SampleDto> GetAuthorizedAsync()
    {
        return Task.FromResult(
            new SampleDto
            {
                Value = 42
            }
        );
    }
}
