using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using WeUtilities;
using Xunit;
using Xunit.Abstractions;

namespace WePing.PointCalculator;

public class Calculator_Tests : PointCalculatorApplicationTestBase
{
    private readonly ITestOutputHelper _output;
    private readonly IBaremeAppService _service;
    public Calculator_Tests(ITestOutputHelper output)
    {
        _output = output;
        _service = GetRequiredService<IBaremeAppService>();
    }


    [Fact]
    public async Task CreateBareme()
    {
        var bareme = await _service.CreateAsync(new() { Ecart = 24, VictoireNormale = 6, DefaiteNormale = -5, VictoireAnormale = 6, DefaiteAnormale = -5 });
        Assert.NotNull(bareme);
        Assert.True(bareme.Id.IsSet());

        var bareme1 = await _service.GetAsync(bareme.Id);
        Assert.NotNull(bareme1);
        Assert.True(bareme.Id == bareme1.Id);
        Assert.True(bareme1.Ecart == 24);
    }

    [Theory]
    [InlineData("600", "800", "true", "17")]
    [InlineData("600", "800", "false", "-1")]
    public async Task CalculatePoints(params string[] args)
    {
        BaremesExtensions.Service = GetRequiredService<IRepository<Bareme, Guid>>();
        (24, 6.0, -5.0, 6.0, -5.0).Add();
        (49, 5.5, -4.5, 7.0, -6.0).Add();
        (99, 5.0, -4.0, 8.0, -7.0).Add();
        (149, 4.0, -3.0, 10.0, -8.0).Add();
        (199, 3.0, -2.0, 13.0, -10.0).Add();
        (299, 2.0, -1.0, 17.0, -12.5).Add();
        (399, 1.0, -0.5, 22.0, -16.0).Add();
        (499, 0.5, 0.0, 28.0, -20.0).Add();
        await (int.MaxValue, 0.0, 0.0, 40.0, -29.09).Add().Done();


        ICalculateurPoints calculateur = GetRequiredService<ICalculateurPoints>();
        double mePoints = double.Parse(args[0]);
        double advPoints = double.Parse(args[1]);
        bool victoire = bool.Parse(args[2]);
        double expected = double.Parse(args[3]);
        var resultat = await calculateur.CalculateAsync(mePoints, advPoints, victoire);
        Assert.True(resultat == expected);
    }

    [Theory]
    [InlineData("600", "800", "true", "17")]
    public async Task CalculatePointsThrown(params string[] args)
    {
        BaremesExtensions.Service = GetRequiredService<IRepository<Bareme, Guid>>();
        (24, 6.0, -5.0, 6.0, -5.0).Add();
        (49, 5.5, -4.5, 7.0, -6.0).Add();
        (99, 5.0, -4.0, 8.0, -7.0).Add();
        await (149, 4.0, -3.0, 10.0, -8.0).Add().Done();
        //(199, 3.0, -2.0, 13.0, -10.0).Add();
        //(299, 2.0, -1.0, 17.0, -12.5).Add();
        //(399, 1.0, -0.5, 22.0, -16.0).Add();
        //(499, 0.5, 0.0, 28.0, -20.0).Add();
        //await (int.MaxValue, 0.0, 0.0, 40.0, -29.09).Add().Done();


        ICalculateurPoints calculateur = GetRequiredService<ICalculateurPoints>();
        double mePoints = double.Parse(args[0]);
        double advPoints = double.Parse(args[1]);
        bool victoire = bool.Parse(args[2]);
        double expected = double.Parse(args[3]);
        try
        {

        var resultat = await calculateur.CalculateAsync(mePoints, advPoints, victoire);
        Assert.True(resultat == expected);
        }catch(CalculatorException e)
        {
            _output.WriteLine(e.Message);
        }
    }
}

internal static class BaremesExtensions
{
    internal static List<Bareme> _baremes = new List<Bareme>();
    internal static IRepository<Bareme, Guid> Service { get; set; }

    internal static (int, double, double, double, double) Add(this (int, double, double, double, double) data)
    {
        Bareme b = new()
        {
            Ecart = data.Item1,
            VictoireNormale = data.Item2,
            DefaiteNormale = data.Item3,
            VictoireAnormale = data.Item4,
            DefaiteAnormale = data.Item5,
        };
        _baremes.Add(b);
        return data;
    }

    internal static async Task Done(this (int, double, double, double, double) data)
        => await Service.InsertManyAsync(_baremes);
}