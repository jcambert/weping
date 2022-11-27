using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Dto;
using WePing.Girpe.Joueurs.Queries;
using Xunit;

namespace WePing.Girpe.Girpe;

public class GirpeAppService_Tests: GirpeApplicationTestBase
{
    private readonly IJoueurAppService _joueurService;
    private readonly IClubAppService _clubService;

    public GirpeAppService_Tests()
    {
        _joueurService = GetRequiredService<IJoueurAppService>();
        _clubService = GetRequiredService<IClubAppService>();
    }

    [Theory]
    [InlineData("905821")]
    public async Task GetJoueurForLicence(params string[] args)
    {
        var query = GetRequiredService<IGetJoueurQuery>();
        Assert.NotNull(query);
        query.Licence = args[0];

        var joueur_response=await _joueurService.GetByLicence(query);
        Assert.NotNull(joueur_response.Joueur);
        Assert.True(joueur_response.Joueur.Licence == args[0]);
        Assert.False(joueur_response.FromDatabase);

        var joueur1_response=await _joueurService.GetByLicence(query);
        Assert.NotNull(joueur1_response.Joueur);
        Assert.True(joueur1_response.Joueur.Licence == args[0]);
        Assert.True(joueur1_response.FromDatabase);
    }


    [Theory]
    [InlineData("02900041")]
    public async Task BrowseJoueurForClubTest(params string[] args)
    {
        var query1 = GetRequiredService<IGetClubQuery>();
        query1.Numero = args[0];
        var response = await _clubService.GetAsync(query1);
        Assert.NotNull(response.Club);
        Assert.True(response.Club.Numero == args[0]);

        var club1 = await _clubService.GetAsync(query1);

        var query2 = GetRequiredService<IBrowseJoueurQuery>();
        query2.ClubId = response.Club.Id;
        query2.ClubNumero = args[0];
        List<JoueurDto> joueurs = (await _joueurService.GetForClub(query2)).Joueurs;
        Assert.NotNull(joueurs);
        Assert.True(joueurs.Count > 0);

    }

    [Theory]
    [InlineData("90")]
    public async Task BrowseAllClub(params string[] args)
    {
        var query = GetRequiredService<IBrowseClubQuery>();
        query.Dep = args[0];
        var res=await _clubService.GetAllAsync(query);
        Assert.NotNull(res.Clubs);
        Assert.True(res.Clubs.Count > 0);
        Assert.False(res.FromDatabase);

         res = await _clubService.GetAllAsync(query);
        Assert.NotNull(res.Clubs);
        Assert.True(res.Clubs.Count > 0);
        Assert.True(res.FromDatabase);
    }
}
