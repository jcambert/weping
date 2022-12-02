using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using Xunit;
using WeUtilities;
namespace WePing.Girpe.Girpe;

public class GirpeRepository_Tests : GirpeApplicationTestBase
{
    [Fact]
    public async Task QueryableFilterTest()
    {
        var repo = GetRequiredService<IRepository<Club>>();
        var queryable = await repo.GetQueryableAsync();

        var query = GetRequiredService<IBrowseClubQuery>();
        query.Numero = "12345";
        query.Number = 45678;
        queryable = queryable.Filter<Club,int>(x => x.Number,FilterOperator.EQ, query.Number);

        var i = 1;
    }
}
