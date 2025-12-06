using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Olbrasoft.Mapping.Mapster.DependencyInjection.Microsoft;

public static class ServiceCollectionExtensions
{
    public static void AddMapping(this IServiceCollection services, params Assembly[] assemblies)
    {
        var config = new TypeAdapterConfig();

        if (assemblies.Length > 0) config.Scan(assemblies);

        services.AddSingleton(config);

        services.AddScoped<global::MapsterMapper.IMapper, ServiceMapper>();

        services.AddScoped<IProjector, MapsterProjector>();

        services.AddScoped<IMapper, MapsterMapper>();
    }
}