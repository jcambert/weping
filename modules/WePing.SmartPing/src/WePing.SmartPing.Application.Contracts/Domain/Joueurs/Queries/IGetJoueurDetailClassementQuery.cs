using Mediator;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IGetJoueurDetailClassementQuery : ISpidRequestQuery<GetJoueurDetailClassementResponse>
{
    string Licence { get; set; }

}

public sealed record GetJoueurDetailClassementResponse(JoueurDetailClassement Joueur):Response;