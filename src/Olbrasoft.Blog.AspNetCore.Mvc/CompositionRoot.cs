using LightInject;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Business.Services;
using Olbrasoft.Blog.Data.EntityFrameworkCore;
using Olbrasoft.Data.Paging.DataTables;

namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry registry)
        {
            registry.RegisterScoped<ICategoryService, CategoryService>();
            registry.RegisterScoped<ITagService, TagService>();
            registry.RegisterScoped<IPostService, PostService>();
            registry.RegisterScoped<ICommentService, CommentService>();
            registry.RegisterScoped<IDataTableOptionBuilder, DataTableOptionBuilder>();
            registry.RegisterScoped<DbContext, BlogDbContext>();
        }
    }
}