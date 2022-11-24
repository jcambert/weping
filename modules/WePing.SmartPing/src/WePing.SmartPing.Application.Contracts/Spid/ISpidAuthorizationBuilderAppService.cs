

namespace WePing.SmartPing.Spid;
public readonly record struct SpidAuthorization(string Tm, string Tmc);
public interface ISpidAuthorizationBuilderAppService : IApplicationService
{
    Task<SpidAuthorization> GetAsync();
}

