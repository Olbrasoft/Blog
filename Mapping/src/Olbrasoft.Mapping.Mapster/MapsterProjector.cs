namespace Olbrasoft.Mapping.Mapster;

public class MapsterProjector : IProjector
{
    private readonly TypeAdapterConfig _config;

    public MapsterProjector(TypeAdapterConfig config)
    {
        _config = config;
    }

    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source) => source.ProjectToType<TDestination>(_config);
}