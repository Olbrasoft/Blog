using LightInject;
using Olbrasoft.Blog.Business.Services;

namespace Olbrasoft.Blog.AspNetCore.Mvc;

public class CompositionRoot : ICompositionRoot
{
    public void Compose(IServiceRegistry registry)
    {
                   
        registry.RegisterScoped<ICategoryService, CategoryService>();
        registry.RegisterScoped<ITagService, TagService>();
        registry.RegisterScoped<IPostService, PostService>();
        registry.RegisterScoped<ICommentService, CommentService>();
        registry.RegisterScoped<IDataTableOptionBuilder, DataTableOptionBuilder>();
        // registry.RegisterScoped<DbContext, BlogDbContext>();
    }
}