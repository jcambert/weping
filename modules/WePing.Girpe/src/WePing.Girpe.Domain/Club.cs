﻿using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace WePing.Girpe.Domain;

public class Club:Entity<Guid>
{
    #region info @see Smartping.ClubDto
    public string Identifiant { get; set; }

    public string Numero { get; set; }

    public int Number { get; set; }

    public string Nom { get; set; }

    public string Validation { get; set; }
    #endregion

    #region Detail @see SmartPing.ClubDetail

    public string NomSalle { get; set; }

    public string AdresseSalle1 { get; set; }

    public string AdresseSalle2 { get; set; }

    public string AdresseSalle3 { get; set; }

    public string CodePostalSalle { get; set; }

    public string VilleSalle { get; set; }

    public string Web { get; set; }

    public string NomCorrespondant { get; set; }

    public string PrenomCorrespondant { get; set; }

    public string MailCorrespondant { get; set; }

    public string TelephoneCorrespondant { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    #endregion

    #region Joueurs
    public virtual List<Joueur> Joueurs { get;  set; } = new();
    #endregion
}
