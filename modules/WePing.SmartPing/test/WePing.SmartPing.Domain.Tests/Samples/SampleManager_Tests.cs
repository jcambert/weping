using System.Threading.Tasks;
using Xunit;

namespace WePing.SmartPing.Samples;

public class SampleManager_Tests : SmartPingDomainTestBase
{
    //private readonly SampleManager _sampleManager;

    public SampleManager_Tests()
    {
        //_sampleManager = GetRequiredService<SampleManager>();
    }

    [Fact]
    public async Task Method1Async()
    {
        await Task.FromResult(0);
    }
}
