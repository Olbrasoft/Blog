namespace Olbrasoft.Blog.Data.Queries.TagQueries;

/// <summary>
/// Represents a query to retrieve a tag by its ID and user ID.
/// </summary>
public class TagByIdAndUserIdQuery : ByIdQuery<TagSmallDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TagByIdAndUserIdQuery"/> class.
    /// </summary>
    /// <param name="processor">The query processor.</param>
    public TagByIdAndUserIdQuery(IQueryProcessor processor) : base(processor)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TagByIdAndUserIdQuery"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public TagByIdAndUserIdQuery(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Gets or sets the user ID.
    /// </summary>
    public int UserId { get; set; }
}
