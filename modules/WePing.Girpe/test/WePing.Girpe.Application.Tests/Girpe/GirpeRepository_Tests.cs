using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Domain;
using WeUtilities;
using Xunit;

namespace WePing.Girpe.Girpe;

public class GirpeRepository_Tests : GirpeApplicationTestBase
{
    
    readonly IAbpLazyServiceProvider LazyServiceProvider;
    protected Type ObjectMapperContext { get; set; }
    protected IObjectMapper ObjectMapper => LazyServiceProvider.LazyGetService<IObjectMapper>(provider =>
        ObjectMapperContext == null
            ? provider.GetRequiredService<IObjectMapper>()
            : (IObjectMapper)provider.GetRequiredService(typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext)));
    public GirpeRepository_Tests()
    {
        LazyServiceProvider = GetRequiredService< IAbpLazyServiceProvider>  ();
    }
    [Fact]
    public async Task QueryableFilterTest()
    {
        var clubs = new Club[] {
            new Club()
            {
                Numero="45678",
            },
            new Club()
            {
                Numero="12345",
            }

        };
        var queryable = clubs.AsQueryable();


        var query = GetRequiredService<IBrowseClubQuery>();
        query.Numero = "45678";

        var fakeRepo = Substitute.For<IRepository<Club>>();
        fakeRepo.GetQueryableAsync().Returns(queryable);

        var queryable0 = (await fakeRepo.GetQueryableAsync()).Filter<Club, string>(x => x.Numero, FilterOperator.EQ, query.Numero);
        fakeRepo.ToListAsync().Returns(queryable0.ToList());
        var res0 = await fakeRepo.ToListAsync();
        Assert.True(res0.Count == 1);
        Assert.True(res0.First().Numero == query.Numero);

        var queryable1 = (await fakeRepo.GetQueryableAsync()).Filter<Club, string>(x => x.Numero, FilterOperator.NEQ, query.Numero);
        fakeRepo.ToListAsync().Returns(queryable1.ToList());
        var res1 = await fakeRepo.ToListAsync();
        Assert.True(res1.Count > 0);
        Assert.True(res1.First().Numero == clubs[1].Numero);

        var queryable2 = (await fakeRepo.GetQueryableAsync()).Filter<Club, string>(x => x.Numero, FilterOperator.LT, query.Numero);
        fakeRepo.ToListAsync().Returns(queryable2.ToList());
        var res2 = await fakeRepo.ToListAsync();
        Assert.True(res2.Count > 0);
        Assert.True(res2.First().Numero == clubs[0].Numero);
    }
/*
    [Fact]
    public async Task Toto()
    {
        var clubs = new Club[] {
            new Club()
            {
                Nom="45678",
                Numero="45678",
                CodePostalSalle="90500"
            },
            new Club()
            {
                Nom="12345",
                Numero="12345"
            }

        };
        var queryable = clubs.AsQueryable();

        var query = GetRequiredService<IBrowseClubQuery>();
        query.Numero = "45678";
        query.Dep = "90";

        var mappedQuery=ObjectMapper.Map<BrowseClubQuery, Club>((BrowseClubQuery)query);

        var fakeRepo = Substitute.For<IRepository<Club>>();
        fakeRepo.GetQueryableAsync().Returns(queryable);

        var queryable0 = (await fakeRepo.GetQueryableAsync()).Filter(mappedQuery);
      
        fakeRepo.ToListAsync().Returns(queryable0.ToList());
        var res0 = await fakeRepo.ToListAsync();
        Assert.True(res0.Count == 1);
        Assert.True(res0.First().Numero == query.Numero);
    }*/
}
