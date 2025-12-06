namespace Olbrasoft.Mapping;

/// <summary>
/// Extension methods for IMapper interface.
/// </summary>
public static class MapperExtensions
{
    /// <summary>
    /// Execute a mapping from the source object to a new destination object.
    /// Alias for MapTo method.
    /// </summary>
    /// <typeparam name="TDestination">Destination type to create</typeparam>
    /// <param name="mapper">The mapper instance</param>
    /// <param name="source">Source object to map from</param>
    /// <returns>Mapped destination object</returns>
    public static TDestination MapSourceToNewDestination<TDestination>(this IMapper mapper, object source)
        => mapper.MapTo<TDestination>(source);

    /// <summary>
    /// Execute a mapping from the source object to the existing destination object.
    /// Alias for Map method.
    /// </summary>
    /// <typeparam name="TSource">Source type to use</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    /// <param name="mapper">The mapper instance</param>
    /// <param name="source">Source object to map from</param>
    /// <param name="destination">Destination object to map into</param>
    /// <returns>The mapped destination object, same instance as the destination object</returns>
    public static TDestination MapSourceToExistingDestination<TSource, TDestination>(
        this IMapper mapper, 
        TSource source, 
        TDestination destination)
        => mapper.Map(source, destination);
}
