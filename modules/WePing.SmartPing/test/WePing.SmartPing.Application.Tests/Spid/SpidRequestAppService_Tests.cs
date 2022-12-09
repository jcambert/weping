using System;
using System.Linq;
using System.Threading.Tasks;
using WePing.SmartPing.Domain.ClubDetails.Queries;
using WePing.SmartPing.Domain.Clubs.Queries;
using WePing.SmartPing.Domain.Divisions.Queries;
using WePing.SmartPing.Domain.Epreuves.Queries;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Organismes.Queries;
using WePing.SmartPing.Spid.Handlers.Joueurs;
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

    [Theory]
    [InlineData("02900041")]
    public async Task GetClubQueryTest(params string[] args)
    {
        var query = GetRequiredService<IGetClubQuery>();
        Assert.NotNull(query);
        query.Numero=args[0];

        var club = await _appService.GetClub(query);
        Assert.NotNull(club);
        Assert.True(club.Numero == query.Numero);
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

        Task act() => _appService.GetEpreuves(query);
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

    [Theory]
    [InlineData("02900041")]
    public async Task BrowseJoueurClassementQueryTest(params string[] args)
    {
        var query = GetRequiredService<IBrowseJoueurClassementQuery>();
        Assert.NotNull(query);
        query.Club = args[0];

        var joueurs = await _appService.GetJoueursClassement(query);
        Assert.NotNull(joueurs);
        Assert.True(joueurs.Count > 0);
        Assert.True(joueurs.First().NumeroClub == args[0]);
    }

    [Fact]
    public async Task BrowseJoueurClassementQueryValidationExceptionTest()
    {
        var query = GetRequiredService<IBrowseJoueurClassementQuery>();
        Assert.NotNull(query);

        Task act() => _appService.GetJoueursClassement(query);
        await Assert.ThrowsAsync<ArgumentException>(act);

    }

    [Theory]
    [InlineData("905821")]
    public async Task BrowseJoueurDetailClassementQueryTest(params string[] args)
    {
        var query = GetRequiredService<IGetJoueurDetailClassementQuery>();
        Assert.NotNull(query);
        query.Licence    = args[0];

        var joueur = await _appService.GetJoueurDetail(query);
        Assert.NotNull(joueur);
        Assert.True(joueur.Licence == args[0]);
    }

    [Fact]
    public async Task BrowseJoueurDetailClassementQueryValidationExceptionTest()
    {
        var query = GetRequiredService<IGetJoueurDetailClassementQuery>();
        Assert.NotNull(query);

        Task act() => _appService.GetJoueurDetail(query);
        await Assert.ThrowsAsync<ArgumentException>(act);

    }

    [Theory]
    [InlineData("905821")]
    public async Task GetJoueurDetailSpidQueryTest(params string[] args)
    {
        var query = GetRequiredService<IGetJoueurDetailSpidQuery>();
        Assert.NotNull(query);
        query.Licence = args[0];

        var joueur = await _appService.GetJoueurDetail(query);
        Assert.NotNull(joueur);
        Assert.True(joueur.Licence == args[0]);
    }

    [Fact]
    public async Task GetJoueurDetailSpidQueryValidationExceptionTest()
    {
        var query = GetRequiredService<IGetJoueurDetailSpidQuery>();
        Assert.NotNull(query);

        Task act() => _appService.GetJoueurDetail(query);
        await Assert.ThrowsAsync<ArgumentException>(act);

    }

    [Theory]
    [InlineData("905821")]
    public async Task GetJoueurDetailSpidClaQueryTest(params string[] args)
    {
        var query = GetRequiredService<IGetJoueurDetailSpidClaQuery>();
        Assert.NotNull(query);
        query.Licence = args[0];

        var joueur = await _appService.GetJoueurDetail(query);
        Assert.NotNull(joueur);
        Assert.True(joueur.Licence == args[0]);
    }

    [Theory]
    [InlineData("02900041")]
    public async Task BrowseJoueurDetailSpidClaQueryTest(params string[] args)
    {
        var query = GetRequiredService<IBrowseJoueurDetailSpidClaQuery>();
        Assert.NotNull(query);
        query.Club = args[0];

        var query_url = GetRequiredService<IGetQuery>();
        Assert.NotNull(query_url);
        query_url.Query = query;
        query_url.EndPoint = BrowseJoueurDetailSpidClaHandler.API_ENDPOINT;
        var url_=await _appService.GetQuery(query_url);
        Assert.False(string.IsNullOrEmpty(url_));

       
        var joueur = await _appService.GetJoueursDetail(query);
        Assert.NotNull(joueur);
        Assert.True(joueur.Count>0);
    }



    [Theory]
    [InlineData("02900041")]
    public async Task BrowseJoueurSpidQueryTest(params string[] args )
    {
        var query = GetRequiredService<IBrowseJoueurSpidQuery>();
        Assert.NotNull(query);
        query.Club = args[0];

        var joueurs = await _appService.GetJoueursSpid(query);
        Assert.NotNull(joueurs);
        Assert.True(joueurs.Count > 0);
        Assert.True(joueurs.First().NumeroClub == args[0]);
    }



    [Fact]
    public async Task BrowseJoueurSpidQueryValidationExceptionTest()
    {
        var query = GetRequiredService<IBrowseJoueurSpidQuery>();
        Assert.NotNull(query);
        query.Valid = "1233211";

        Task act() => _appService.GetJoueursSpid(query);
        await Assert.ThrowsAsync<ArgumentException>(act);

    }

}
