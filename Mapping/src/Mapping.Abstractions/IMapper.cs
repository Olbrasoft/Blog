namespace Olbrasoft.Mapping;

public interface IMapper : IProjector
{
    /// <summary>
    /// Execute a mapping from the source object to a new destination object.
    /// The source type is inferred from the source object.
    /// </summary>
    /// <typeparam name="TDestination">Destination type to create</typeparam>
    /// <param name="source">Source object to map from</param>
    /// <returns>Mapped destination object</returns>
    TDestination MapTo<TDestination>(object source);

    /// <summary>
    /// Execute a mapping from the source object to the existing destination object.
    /// </summary>
    /// <typeparam name="TSource">Source type to use</typeparam>
    /// <typeparam name="TDestination">Destination type</typeparam>
    /// <param name="source">Source object to map from</param>
    /// <param name="destination">Destination object to map into</param>
    /// <returns>The mapped destination object, same instance as the <paramref name="destination"/> object</returns>
    TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
}