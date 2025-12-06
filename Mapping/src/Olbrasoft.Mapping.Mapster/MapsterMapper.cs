namespace Olbrasoft.Mapping.Mapster;

public class MapsterMapper : IMapper
{
    private readonly global::MapsterMapper.IMapper _mapper;

    public MapsterMapper(global::MapsterMapper.IMapper mapper) => _mapper = mapper;

    public TDestination MapTo<TDestination>(object source) => _mapper.Map<TDestination>(source);

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => _mapper.Map(source, destination);
    
    public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source) => source.ProjectToType<TDestination>(_mapper.Config);
}