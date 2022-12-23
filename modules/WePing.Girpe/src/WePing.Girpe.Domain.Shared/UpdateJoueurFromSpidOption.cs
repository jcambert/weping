using System;

namespace WePing.Girpe;

[Flags]
public enum UpdateJoueurFromSpidOption
{
    None = 0,
    Spid = 1,
    Cla = 2,
    SpidCla = 4,
    Club=8,
    DetailsOnly=1+2+4,
    All = 1 + 2 + 4+8,

}
