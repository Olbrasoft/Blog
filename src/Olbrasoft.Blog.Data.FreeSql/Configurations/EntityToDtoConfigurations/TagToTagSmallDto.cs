using Olbrasoft.Data.Cqrs.FreeSql;
using System.Linq.Expressions;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityToDtoConfigurations;
public class TagToTagSmallDto : IEntityToDtoConfigure<Tag, TagSmallDto>
{
    public Expression<Func<Tag, TagSmallDto>> Configure()
    {
        return t => new TagSmallDto { Id = t.Id, Label = t.Label };
    }
}
