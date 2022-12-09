// See https://aka.ms/new-console-template for more information
using AutoMapper;
using GeneratorsConsole;
using GeneratorsData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        {
            services.AddLogging();
            services.AddAutoMapper(typeof(AutoMapProfile));
            services.AddSingleton<Main>();
        })
    .Build();

var main = host.Services.GetRequiredService<Main>();
await main.ExecuteAsync();
public class Main
{
    private readonly ILogger<Main> _logger;
    private readonly IMapper _mapper;

    public Main(ILogger<Main> logger,IMapper mapper)
    {
        this._logger = logger;
        this._mapper = mapper;
    }
    public async Task ExecuteAsync(CancellationToken stoppingToken = default)
    {
        _logger.LogInformation("Start Test");
        var query = new GetQuery() { Identifiant = "6789"/*, Name = "Name 6789", Number = 1*/ };

        List<Dto> queries = new List<Dto>() {
                new Dto() { Identifiant = "6789", Name = "Name 6789" },
                new Dto() { Identifiant = "12345", Name = "Name 12345" },
            };

        var dtoMapped=_mapper.Map<Dto>(query);

        _logger.LogInformation($"query.Identifiant:{query.Identifiant} - dtoMapped.Identifiant:{dtoMapped.Identifiant}");
        
        var queryable = queries.AsQueryable();
        queryable =queryable.Filter(dtoMapped);
        _logger.LogInformation(queryable?.FirstOrDefault()?.Name ?? "NOTHING");
        _logger.LogInformation("Test Is End");
     }
}

/// <summary>
/// toto
/// </summary>
/*
public static class MapQueryToPredicateExtensions
{
    public static Expression<Func<TTarget, bool>> GetPredicate<TTarget>(this GetQuery queryDto)
        where TTarget : Dto
    {
        return x => (string.IsNullOrEmpty(x.Identifiant) ? true : x.Identifiant == queryDto.Identifiant) && (true);
    }
    public static IQueryable<TTarget> Where<TTarget>(this IQueryable<TTarget> queryable, GetQuery queryDto)
        where TTarget : Dto
    {
        return queryable.Where(GetPredicate<TTarget>(queryDto));
    }
}*/