using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.DependencyInjection;

namespace WePing.Girpe.Joueurs.Queries.Impl;
[Dependency(ServiceLifetime.Transient),ExposeServices(typeof(IUpdateJoueurQuery))]
public class UpdateJoueurQuery : IUpdateJoueurQuery
{
    public string Licence { get ; set; }
    public Guid Id { get; set; }
    public UpdateJoueurFromSpidOption DetailOptions { get; set; } = UpdateJoueurFromSpidOption.All;
}
