using MediatR;
using System.Threading;
using WePing.Girpe.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Dto;
using WePing.SmartPing.Domain.Joueurs.Queries;
using WePing.SmartPing.Domain.Parties.Queries;

namespace WePing.Girpe.Services;

public class UpdateJoueurFromSpidDomainService : GirpeDomainService
{
    public UpdateClubForJoueurDomainService UpdateClubService => GetRequiredService<UpdateClubForJoueurDomainService>();
    IGetJoueurDetailSpidQuery DetailSpidQuery => GetRequiredService<IGetJoueurDetailSpidQuery>();
    IGetJoueurDetailClassementQuery DetailClaQuery => GetRequiredService<IGetJoueurDetailClassementQuery>();
    IGetJoueurDetailSpidClaQuery DetailSpidClaQuery => GetRequiredService<IGetJoueurDetailSpidClaQuery>();
    IBrowsePartiesSpidQuery PartiesSpidQuery=>GetRequiredService<IBrowsePartiesSpidQuery>();
    public async Task Update(JoueurDto joueur, UpdateJoueurFromSpidOption options = UpdateJoueurFromSpidOption.All, CancellationToken cancellationToken=default)
    {
        if (joueur == null || string.IsNullOrEmpty(joueur.Licence))
        {
            return;
        }
        await PopulateJoueurDetail(joueur, options,cancellationToken);
    }
    protected async Task PopulateJoueurDetail(JoueurDto joueur, UpdateJoueurFromSpidOption options,CancellationToken cancellationToken)
    {
        

        if ((options & UpdateJoueurFromSpidOption.Spid )== UpdateJoueurFromSpidOption.Spid)
        {
            var query1 = DetailSpidQuery;
            query1.Licence = joueur.Licence;
            var joueur_detail_response1 = await Spid.GetJoueurDetail(query1);
            ObjectMapper.Map<JoueurDetailSpidDto, JoueurDto>(joueur_detail_response1, joueur);

        }
        if ((options & UpdateJoueurFromSpidOption.Cla) == UpdateJoueurFromSpidOption.Cla)
        {
            var query2 = DetailClaQuery;
            query2.Licence = joueur.Licence;
            var joueur_detail_response2 = await Spid.GetJoueurDetail(query2);
            ObjectMapper.Map<JoueurDetailClassementDto, JoueurDto>(joueur_detail_response2, joueur);
        }

        if ((options  & UpdateJoueurFromSpidOption.SpidCla )== UpdateJoueurFromSpidOption.SpidCla)
        {
            var query3 = DetailSpidClaQuery;
            query3.Licence = joueur.Licence;
            var joueur_detail_response3 = await Spid.GetJoueurDetail(query3);
            ObjectMapper.Map<JoueurDetailSpidClaDto, JoueurDto>(joueur_detail_response3, joueur);
        }
        if ((options & UpdateJoueurFromSpidOption.Club) == UpdateJoueurFromSpidOption.Club)
        {
            var club = await UpdateClubService.Update(joueur, cancellationToken);
        }

        if ((options & UpdateJoueurFromSpidOption.PartiesSpid) == UpdateJoueurFromSpidOption.PartiesSpid)
        {
            var query = PartiesSpidQuery;
            query.NumLic= joueur.Licence;
            var parties_response = await Spid.BrowseJoueurParties(query);
            joueur.PartiesSpid= parties_response;
        }
    }
}
