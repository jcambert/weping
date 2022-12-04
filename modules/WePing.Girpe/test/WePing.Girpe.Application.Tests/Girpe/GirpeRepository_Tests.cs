using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using Xunit;
using WeUtilities;
using System.Linq;

using NSubstitute;

namespace WePing.Girpe.Girpe;

public class GirpeRepository_Tests : GirpeApplicationTestBase
{
    [Fact]
    public async Task QueryableFilterTest()
    {
        var clubs = new Club[] {
            new Club()
            {
                Nom="45678",
                Number=45678
            },
            new Club()
            {
                Nom="12345",
                Number=12345
            }

        };
        var queryable = clubs.AsQueryable();


        var query = GetRequiredService<IBrowseClubQuery>();
        query.Number = 45678;

        var fakeRepo = Substitute.For<IRepository<Club>>();
        fakeRepo.GetQueryableAsync().Returns(queryable);

        var queryable0 = (await fakeRepo.GetQueryableAsync()).Filter<Club, int>(x => x.Number, FilterOperator.EQ, query.Number);
        fakeRepo.ToListAsync().Returns(queryable0.ToList());
        var res0 = await fakeRepo.ToListAsync();
        Assert.True(res0.Count == 1);
        Assert.True(res0.First().Number == query.Number);

        var queryable1 = (await fakeRepo.GetQueryableAsync()).Filter<Club, int>(x => x.Number, FilterOperator.NEQ, query.Number);
        fakeRepo.ToListAsync().Returns(queryable1.ToList());
        var res1 = await fakeRepo.ToListAsync();
        Assert.True(res1.Count > 0);
        Assert.True(res1.First().Number== clubs[1].Number);

        var queryable2 = (await fakeRepo.GetQueryableAsync()).Filter<Club, int>(x => x.Number, FilterOperator.LT, query.Number);
        fakeRepo.ToListAsync().Returns(queryable2.ToList());
        var res2 = await fakeRepo.ToListAsync();
        Assert.True(res2.Count > 0);
        Assert.True(res2.First().Number == clubs[1].Number);
    }

    [Fact]
    public async Task Toto()
    {
        var clubs = new Club[] {
            new Club()
            {
                Nom="45678",
                Number=45678,
                CodePostalSalle="90500"
            },
            new Club()
            {
                Nom="12345",
                Number=12345
            }

        };
        var queryable = clubs.AsQueryable();

        var query = GetRequiredService<IBrowseClubQuery>();
        query.Number = 45678;
        query.Dep = "90";

        var fakeRepo = Substitute.For<IRepository<Club>>();
        fakeRepo.GetQueryableAsync().Returns(queryable);

        var queryable0 = (await fakeRepo.GetQueryableAsync()).Filter(query);
      
        fakeRepo.ToListAsync().Returns(queryable0.ToList());
        var res0 = await fakeRepo.ToListAsync();
        Assert.True(res0.Count == 1);
        Assert.True(res0.First().Number == query.Number);
    }
}
