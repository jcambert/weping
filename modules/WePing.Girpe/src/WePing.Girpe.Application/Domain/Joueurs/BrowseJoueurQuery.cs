using System;
using WePing.Girpe.Joueurs.Queries;

namespace WePing.Girpe.Domain.Joueurs;

public class BrowseJoueurQuery : IBrowseJoueurQuery
{
    public Guid ClubId { get; set; }
    public string ClubNumero { get; set; }
}
