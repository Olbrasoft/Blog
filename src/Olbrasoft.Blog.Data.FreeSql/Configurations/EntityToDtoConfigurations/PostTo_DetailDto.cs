using MediatR.Cqrs.FreeSql;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityToDtoConfigurations;
public class PostTo_DetailDto : IEntityToDtoConfiguration<Post, PostDetailDto>
{
    public Expression<Func<Post, PostDetailDto>> Configure()
    {
        return p => new PostDetailDto { Creator = $"{p.Creator.FirstName} {p.Creator.LastName}", CategoryName = p.Category.Name };
    }
}
