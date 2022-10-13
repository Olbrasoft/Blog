using Mapster;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.MappingRegisters;

public class PostToPostEditDtoRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostEditDto>().Map(
            dest => dest.TagIds, src => src.ToTags.Select(p => p.ToId));
    }
}