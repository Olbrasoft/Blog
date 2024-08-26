using Mapster;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.MappingRegisters;

public class PostToPostEditDtoRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostEditDto>().Map(
            dest => dest.Tags, src => src.Tags.Select(t=> new TagSmallDto { Id = t.Id, Label= t.Label }));
        
        config.NewConfig<Post, PostEditDto>().Map(dest=> dest.DefaultImageNameAndExtension, src => src.Image);
    }
}