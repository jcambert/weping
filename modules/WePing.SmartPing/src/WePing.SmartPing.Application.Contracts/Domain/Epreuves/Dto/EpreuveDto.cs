﻿using System.Diagnostics;

namespace WePing.SmartPing.Domain.Epreuves.Dto;

[DebuggerDisplay("{Id}-{Libelle}")]
public class EpreuveDto
{
    #region public properties

    public string Id { get; set; }

    public string Organisme { get; set; }

    public string Libelle { get; set; }

    #endregion
}
