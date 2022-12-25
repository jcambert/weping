using System;

namespace WePing.Girpe;

[Flags]
public enum UpdateJoueurFromSpidOption
{
    None = 0,
    Spid = 1,
    Cla = 1<<1,
    SpidCla = 1<<2,
    Club=1<<3,
    PartiesSpid=1<<4,
    DetailsOnly=Spid|Cla|SpidCla,
    All =  ~0,

}
