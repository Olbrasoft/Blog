﻿using IGeekFan.AspNetCore.Identity.FreeSql;
using Localization.AspNetCore.TagHelpers;
using Microsoft.AspNetCore.Mvc.Razor;
using Olbrasoft.Blog.Business.Services;
using Olbrasoft.Blog.Data.FreeSql;
using Olbrasoft.Blog.Data.MappingRegisters;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Mapping.Mapster.DependencyInjection.Microsoft;
using Olbrasoft.Text.Transformation.Markdown;
namespace Olbrasoft.Blog.AspNetCore.Mvc;

public static class WebApplicationBuilderExtensions
{
    static IFreeSql? _fsql;

    public static void BuildServices(this WebApplicationBuilder builder)
    {
        if (builder is not null)
        {
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            builder.Services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";

            });

            builder.Services.AddControllersWithViews()
                           .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                           .AddDataAnnotationsLocalization();

            builder.Services.Configure<LocalizeTagHelperOptions>(options =>
            {
                options.TrimWhitespace = false;
            });


            var identityBuilder = builder.Services.AddIdentity<BlogUser, BlogRole>(options =>
              {
                  options.Password.RequiredLength = 3;
                  options.Password.RequiredUniqueChars = 0;
                  options.Password.RequireLowercase = false;
                  options.Password.RequireUppercase = false;
                  options.Password.RequireDigit = false;
                  options.Password.RequireNonAlphanumeric = false;
                  options.SignIn.RequireConfirmedEmail = false;

              });

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var connectionString = builder.Configuration.GetConnectionString("BlogDbConnectionString");

            //EntityFramework
            //identityBuilder.AddEntityFrameworkStores<BlogDbContext>();

            //builder.Services.AddDbContext<BlogDbContext>(options =>
            //{
            //    options.UseSqlServer(
            //        connectionString);
            //    // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            //}, ServiceLifetime.Scoped);


            builder.Services.AddMediatR(cfg =>
            {

                cfg.Lifetime = ServiceLifetime.Scoped;
                cfg.RegisterServicesFromAssemblies(typeof(CategoriesQuery).Assembly, typeof(BlogFreeSqlDbContext).Assembly);

            });


            ///FreeSql
            _fsql = new FreeSql.FreeSqlBuilder()
           .UseConnectionString(FreeSql.DataType.SqlServer, connectionString)
           .UseAutoSyncStructure(false) //automatically synchronize the entity structure to the database
           .Build();

            _fsql.SetDbContextOptions(o => o.EnableCascadeSave = true);

            builder.Services.AddSingleton(_fsql);

            builder.Services.AddFreeDbContext<BlogFreeSqlDbContext>(o =>
             {
                 o.UseFreeSql(_fsql);
             });

            identityBuilder.AddFreeSqlStores<BlogFreeSqlDbContext>();

            // builder.Services.AddProjectionConfigurations(typeof(BlogFreeSqlDbContext).Assembly);


            builder.Services.AddScoped<IQueryProcessor, QueryProcessor>();
            builder.Services.AddScoped<ICommandExecutor, CommandExecutor>();


            builder.Services.AddTextTransformationMarkdown();

            builder.Services.AddMapping(typeof(PostToPostEditDtoRegister).Assembly);

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<IPostService, PostService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IDataTableOptionBuilder, DataTableOptionBuilder>();
        }
        else
        {
            throw new ArgumentNullException(nameof(builder));
        }

    }
}