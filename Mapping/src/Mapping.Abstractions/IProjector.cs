using System.Linq;

namespace Olbrasoft.Mapping;

public interface IProjector
{
    /// <summary>
    /// Project the input queryable.
    /// </summary>
    /// <remarks>Projections</remarks>
    /// <typeparam name="TDestination">Destination type</typeparam>
    /// <param name="source">Queryable source</param>
    /// <returns>Queryable result, use queryable extension methods to project and execute result</returns>
    IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source);
}