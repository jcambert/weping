using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;
using WePing.Girpe.Clubs;
using WePing.Girpe.Clubs.Queries;
using WePing.Girpe.Joueurs;
using WePing.Girpe.Joueurs.Queries;
using WeUtilities;
using Xunit;

namespace WePing.Girpe.Girpe;

public class GirpeAppService_Tests : GirpeApplicationTestBase
{
    private readonly IJoueurAppService _joueurService;
    private readonly IClubAppService _clubService;
    private readonly IObjectMapper _mapper;
    public GirpeAppService_Tests()
    {
        _joueurService = GetRequiredService<IJoueurAppService>();
        _clubService = GetRequiredService<IClubAppService>();
        _mapper = GetRequiredService<IObjectMapper>();
    }

    

    [Theory]
    [InlineData("905821", "false")]
    [InlineData("905821", "true")]
    public async Task GetJoueurForLicence(params string[] args)
    {
        bool retrieveClub = bool.Parse(args[1]);

        var query = GetRequiredService<IGetJoueurQuery>();
        Assert.NotNull(query);
        query.Licence = args[0];
        query.ForceLoadClubIfNotSet = retrieveClub;

        for (int i = 1; i < 3; i++)
        {

            var joueur_response = await _joueurService.GetByLicence(query);
            Assert.NotNull(joueur_response.Joueur);
            Assert.True(joueur_response.Joueur.Licence == query.Licence);


            GetClubResponse club_response=new (new());


            if (retrieveClub)
            {

                var queryClub = GetRequiredService<IGetClubQuery>();
                queryClub.Id = joueur_response.Joueur.ClubId;
                club_response = await _clubService.GetAsync(queryClub);
                Assert.NotNull(club_response.Club);
                Assert.True(queryClub.Id == joueur_response.Joueur.ClubId);
            }
            else
            {
                Assert.True(joueur_response.Joueur.ClubId == Guid.Empty);

            }

            if (i % 2 == 0)
            {

                Assert.True(joueur_response.FromDatabase);
                if (retrieveClub)
                    Assert.True(club_response.FromDatabase);
            }
            else
            {
                Assert.False(joueur_response.FromDatabase);
                if (retrieveClub)
                    Assert.True(club_response.FromDatabase);
            }
        }


    }

    [Theory]
    [InlineData("905821")]
    public async Task UpdateClubForjoueur(params string[] args)
    {
        var query=GetRequiredService<IUpdateClubForJoueurQuery>();
        query.Licence = args[0];
        var update_response= await _clubService.UpdateForJoueur(query);
        Assert.NotNull(update_response.Club);
        Assert.True(update_response.Club.Id!=Guid.Empty);

        var query1 = GetRequiredService<IGetJoueurQuery>();
        query1.Licence = args[0];
        var joueur_response=await _joueurService.GetByLicence(query1);
        Assert.True(update_response.Club.Id == joueur_response.Joueur.ClubId);
    }


    [Theory]
    [InlineData("02900041","905821")]
    public async Task BrowseJoueurForClubTest(params string[] args)
    {
        var query1 = GetRequiredService<IGetClubQuery>();
        query1.Numero = args[0];
        var response = await _clubService.GetAsync(query1);
        Assert.NotNull(response.Club);
        Assert.True(response.Club.Numero == args[0]);

        var club1 = await _clubService.GetAsync(query1);

        var query2 = GetRequiredService<IBrowseJoueurQuery>();
       // query2.ClubId = response.Club.Id;
        query2.ClubNumero = args[0];
        query2.ForceLoadClubIfNotSet = true;
        var joueurs = (await _joueurService.GetForClub(query2)).Joueurs;
        Assert.NotNull(joueurs);
        Assert.True(joueurs.Count > 0);

        var query3=GetRequiredService<IGetJoueurQuery>();
        query3.Licence = args[1];
        
        var joueur_response=await _joueurService.GetByLicence(query3);
        Assert.NotNull(joueur_response);
        Assert.True(joueur_response.FromDatabase);
        Assert.True(joueur_response.Joueur.Licence== args[1]);
        Assert.True(joueur_response.Joueur.ClubId == response.Club.Id);

    }

    [Theory]
    [InlineData("90")]
    public async Task BrowseAllClub(params string[] args)
    {
        var query = GetRequiredService<IBrowseClubQuery>();
        query.Dep = args[0];
        var res = await _clubService.GetAllAsync(query);
        Assert.NotNull(res.Clubs);
        Assert.True(res.Clubs.Count > 0);
        Assert.False(res.FromDatabase);

        res = await _clubService.GetAllAsync(query);
        Assert.NotNull(res.Clubs);
        Assert.True(res.Clubs.Count > 0);
        Assert.True(res.FromDatabase);
    }
    [Theory]
    [InlineData("90")]
    public async Task BrowseAllClubDtoResponseMap(params string[] args)
    {
        var query = GetRequiredService<IBrowseClubQuery>();
        query.Dep = args[0];
        var res = await _clubService.GetAllAsync(query);
        Assert.NotNull(res.Clubs);
        Assert.True(res.Clubs.Count > 0);
        Assert.False(res.FromDatabase);
        var res_dto=_mapper.Map<BrowseClubResponse, BrowseClubResponseDto>(res);
        Assert.True(res.Clubs.First().Numero == res_dto.Clubs.First().Numero);


    }

    [Theory]
    [InlineData("02900041")]
    public async Task GetClub(params string[] args)
    {
        var query = GetRequiredService<IGetClubQuery>();
        query.Numero = args[0];
        var res = await _clubService.GetAsync(query);
        Assert.NotNull(res);
        Assert.True(res.Club.Numero == args[0]);
    }

    [Theory]
    [InlineData("905821","false")]
    public async Task UpdateJoueur(params string[] args)
    {
        bool retrieveClub = bool.Parse(args[1]);

        var joueur_query = GetRequiredService<IGetJoueurQuery>();
        Assert.NotNull(joueur_query);
        joueur_query.Licence = args[0];
        joueur_query.ForceLoadClubIfNotSet = retrieveClub;
        joueur_query.DetailOptions = UpdateJoueurFromSpidOption.None;

        var joueur_response = await _joueurService.GetByLicence(joueur_query);
        Assert.NotNull(joueur_response.Joueur);
        Assert.True(joueur_response.Joueur.Licence == joueur_query.Licence);
        Assert.False(joueur_response.FromDatabase);
        Assert.True(joueur_response.Joueur.AncienClassementGlobal.IsNullOrEmpty());


        var update_query=GetRequiredService<IUpdateJoueurQuery>();
        Assert.NotNull(update_query);
        update_query.Licence = joueur_response.Joueur.Licence;
        
        var update_joueur_response=await _joueurService.Update(update_query);
        Assert.True(update_joueur_response.Joueur.ClubId.IsSet());
        Assert.False(update_joueur_response.Joueur.AncienClassementGlobal.IsNullOrEmpty());
    }
}
