using Mediator;
using WePing.SmartPing.Domain.Joueurs.Domain;
using WePing.SmartPing.Spid;

namespace WePing.SmartPing.Domain.Joueurs.Queries;

public interface IGetJoueurDetailSpidQuery : ISpidRequestQuery<GetJoueurDetailSpidResponse>
{
    string Licence { get; set; }

}

public sealed record GetJoueurDetailSpidResponse(JoueurDetailSpid Joueur): Response;