using System;
using System.Linq;
using System.Threading.Tasks;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Organismes.Queries;
using Xunit;

namespace WePing.SmartPing.Spid;

public class SpidRequestAppService_Tests : SmartPingApplicationTestBase
{
    private readonly ISpidRequestAppService _requestService;
    private readonly ISpidAppService _appService;

    public SpidRequestAppService_Tests()
	{
        _requestService = GetRequiredService<ISpidRequestAppService>();
        _appService=GetRequiredService<ISpidAppService>();
    }

    [Fact]
    public void QueryDictionaryTest()
    {
        var query=GetRequiredService<IBrowseClubsQuery>();
        Assert.NotNull(query);

        var result=query.ToDictionnary(false);
        Assert.NotNull(result);

        var props_length = query.GetType().GetProperties().Length;
        Assert.Equal(result.Keys.Count, props_length);
    }
    [Fact]
    public async Task GetQueryTest() {
        var query = GetRequiredService<IBrowseClubsQuery>();
        Assert.NotNull(query);
        query.Dep = "90";

        var url=await _requestService.GetQueryAsync(query, "club_liste");
        Assert.NotNull(url);
        Assert.True(url.Length> 0);

        var query1 = GetRequiredService<IGetClubQuery>();
        Assert.NotNull(query1);
        query1.Numero="02900041";

        var url1 = await _requestService.GetQueryAsync(query1, "club_liste");
        Assert.NotNull(url1);
        Assert.True(url1.Length > 0);

    }

    [Fact]
    public async Task GetAsync()
    {
        var query = GetRequiredService<IBrowseClubsQuery>();
        Assert.NotNull(query);
        query.Dep = "90";


        var result = await _requestService.GetAsync(query, "club_liste",default);
        Assert.NotNull(result);
        Assert.True(result.Length > 0);
    }

    [Fact]
    public async Task BrowseClubsQueryTest()
    {
        var query = GetRequiredService<IBrowseClubsQuery>();
        Assert.NotNull(query);
        query.Dep = "90";

        var clubs=await _appService.GetClubs(query);
        Assert.NotNull(clubs);
        Assert.True(clubs.Count>0);
    }

    [Fact]
    public async Task GetClubQueryTest()
    {
        var query = GetRequiredService<IGetClubQuery>();
        Assert.NotNull(query);
        query.Numero="02900041";

        var club = await _appService.GetClub(query);
        Assert.NotNull(club);
    }

    [Fact]
    public async Task GetClubDetailQueryTest()
    {
        var query = GetRequiredService<IGetClubDetailQuery>();
        Assert.NotNull(query);
        query.Club = "029000410";

        var club = await _appService.GetClubDetail(query);
        Assert.NotNull(club);
    }

    [Fact]
    public async Task BrowseOrganismeQueryTest()
    {
        var query = GetRequiredService<IBrowseOrganismeQuery>();
        Assert.NotNull(query);
        query.Type = "Z";

        var organismes = await _appService.GetOrganismes(query);
        Assert.NotNull(organismes);
    }

    [Theory]
    [InlineData("D","I")]
    [InlineData("D","E")]
    public async Task BrowseEpreuveQueryTest(params string[] args)
    {
        var q = GetRequiredService<IBrowseOrganismeQuery>();
        Assert.NotNull(q);
        q.Type = args[0];
        var organismes=await _appService.GetOrganismes(q);
        Assert.NotNull(organismes);
        Assert.True(organismes.Count > 0);

        var d90 = organismes.Where(x => x.Code == "D90").FirstOrDefault() ?? organismes.First();
        var query = GetRequiredService<IBrowseEpreuveQuery>();
        Assert.NotNull(query);
        query.Type = args[1];
        query.Organisme = d90.Id;
        var epreuves = await _appService.GetEpreuves(query);
        Assert.NotNull(epreuves);
        
    }

    [Fact]
    public async Task BrowseEpreuveQueryValidationExceptionTest()
    {
        var query = GetRequiredService<IBrowseEpreuveQuery>();
        Assert.NotNull(query);
        query.Type = "Z";

        //Func<IBrowseEpreuveQuery,Task<List<EpreuveDto>>> fn=(q)=>_appService.GetEpreuves(q);
        Func<Task> act = () => _appService.GetEpreuves(query);
        //var epreuves = await _appService.GetEpreuves(query);
        await Assert.ThrowsAsync<ArgumentException>(act);


    }

    [Theory]
    [InlineData("D", "I")]
    [InlineData("D", "E")]
    public async Task BrowseDivisionQueryTest(params string[] args)
    {
        var q = GetRequiredService<IBrowseOrganismeQuery>();
        Assert.NotNull(q);
        q.Type = args[0];
        var organismes = await _appService.GetOrganismes(q);
        Assert.NotNull(organismes);
        Assert.True(organismes.Count > 0);

        var organisme = organismes.Where(x => x.Code == "D90").FirstOrDefault() ?? organismes.First();
        var query = GetRequiredService<IBrowseEpreuveQuery>();
        Assert.NotNull(query);
        query.Type = args[1];
        query.Organisme = organisme.Id;
        var epreuves = await _appService.GetEpreuves(query);
        Assert.NotNull(epreuves);
        Assert.True(epreuves.Count > 0);

        var epreuve = epreuves.First();

        var query1=GetRequiredService<IBrowseDivisionQuery>();
        Assert.NotNull(query1); 
        query1.Epreuve = epreuve.Id;
        query1.Organisme= organisme.Id;
        query1.Type= args[1];

        var divisions = await _appService.GetDivisions(query1);
        Assert.NotNull(divisions);
    }
}
