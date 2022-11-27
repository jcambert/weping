using Mediator;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IGetJoueurDetailSpidClaQuery : ISpidRequestQuery<GetJoueurDetailSpidClaResponse>
{
    /// <summary>
    /// In this case must be Numero du club
    /// </summary>
    string Licence { get; set; }
}

public sealed record GetJoueurDetailSpidClaResponse(JoueurDetailSpidCla Joueur): Response;