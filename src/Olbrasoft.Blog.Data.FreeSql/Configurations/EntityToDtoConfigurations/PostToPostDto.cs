using MediatR.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityToDtoConfigurations;
public class PostToPostDto : IEntityToDtoConfigure<Post, PostDto>
{
    public Expression<Func<Post, PostDto>> Configure()
    {
        return p => new PostDto { Creator = p.Creator.FirstName + p.Creator.LastName, CategoryName = p.Category.Name };
    }
}
