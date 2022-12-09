using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class MediatorExtensions
{
    static bool _isMediatorAdded = false;
    public static  IServiceCollection AddMediator(this IServiceCollection services,params Assembly[] assemblies)
    {
        if(_isMediatorAdded) 
            throw new ApplicationException("Mediator can only call once");
        _isMediatorAdded= true;
        var logger=LoggerFactory.Create(config =>
        {
            config.AddConsole();
        }).CreateLogger("MediatorExtensions");

        logger.BeginScope(typeof(MediatorExtensions));

        logger.LogInformation("Try to add Mediator to service collection");
       

        services.AddMediatR(assemblies);

        logger.LogInformation("Mediator added to service collection");
        return services;
    }
}