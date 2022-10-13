using FreeSql;
using IGeekFan.AspNetCore.Identity.FreeSql;
using Localization.AspNetCore.TagHelpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Business.Services;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Blog.Data.EntityFrameworkCore;
using Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;
using Olbrasoft.Blog.Data.FreeSql;
using Olbrasoft.Blog.Data.FreeSql.Tests;
using Olbrasoft.Blog.Data.MappingRegisters;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Cqrs;
using Olbrasoft.Data.Paging.DataTables;
using Olbrasoft.Dispatching;
using Olbrasoft.Extensions.DependencyInjection;
using Olbrasoft.Mapping.Mapster.DependencyInjection.Microsoft;
using Olbrasoft.Text.Transformation.Markdown;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Olbrasoft.Blog.AspNetCore.Mvc;

public class Startup
{
    static IFreeSql fsql;

    public void UseFreeSql(IServiceCollection services)
    {

        fsql = new FreeSql.FreeSqlBuilder()
       .UseConnectionString(FreeSql.DataType.SqlServer, ConnectionString)
       .UseAutoSyncStructure(false) //automatically synchronize the entity structure to the database
       .Build();

        fsql.CodeFirst.ApplyConfigurationsFromAssembly(typeof(BlogFreeSqlDbContext).Assembly);

        services.AddSingleton(fsql);
                
        services.AddFreeDbContext<BlogFreeSqlDbContext>(o => 
        {
            o.UseFreeSql(fsql);
        });

        services.AddTransient<IDbSetProvider>( p=>p.GetRequiredService<BlogFreeSqlDbContext>());
        services.AddTransient<IDataSelector, DbSelector>();

        services.AddIdentity<BlogUser, BlogRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.SignIn.RequireConfirmedEmail = false;

        }).AddFreeSqlStores<BlogFreeSqlDbContext>();


        services.AddDispatching(cfg =>
        {
            cfg.AsScopped();
            cfg.Use<ExcutorDispatcher>();
        }
       , typeof(CategoriesQuery).Assembly, typeof(BlogFreeSqlDbContext).Assembly);
    }


    public void UseEntityFramework(IServiceCollection services)
    {
        services.AddDbContext<BlogDbContext>(options =>
        {
            options.UseSqlServer(
                ConnectionString);
        }, ServiceLifetime.Scoped);

        services.AddIdentity<BlogUser, BlogRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.SignIn.RequireConfirmedEmail = false;

        }).AddEntityFrameworkStores<BlogDbContext>();

        services.AddDispatching(cfg =>
        {
            cfg.AsScopped();
            cfg.Use<ExcutorDispatcher>();
        }
       ,typeof(CategoriesQuery).Assembly, typeof(BlogDbContext).Assembly);

    }


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public string ConnectionString
    {
        get { return Configuration.GetConnectionString("BlogDbConnectionString"); }
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        services.AddControllersWithViews()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

        services.AddSingleton<SharedLocalizer>();

        services.Configure<LocalizeTagHelperOptions>(options =>
        {
            options.TrimWhitespace = false;
        });

        services.AddRazorPages().AddRazorRuntimeCompilation();


        services.AddRazorPages();

        services.AddDatabaseDeveloperPageExceptionFilter();
         
        
        UseFreeSql(services);

        services.AddTextTransformationMarkdown();
        
        services.AddMapping(typeof(PostToPostEditDtoRegister).Assembly);


        services.AddScoped<IQueryProcessor, QueryProcessor>();
        services.AddScoped<ICommandExecutor, CommandExecutor>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IDataTableOptionBuilder, DataTableOptionBuilder>();


        //Next registration is in CompositionRoot.cs
    }

    //public void ConfigureContainer(ContainerBuilder registry)
    //{
    //    registry.SetupMvc();

    //    //Setup some logger
    //    registry.ConfigureSettings(s =>
    //    {
    //        s.With(Loggers.ConsoleLogger);
    //    });

    //    registry.Register<ICategoryService, CategoryService>(c => c.With(Lifetimes.PerScope));
    //    registry.Register<ITagService, TagService>(c => c.With(Lifetimes.PerScope));
    //    registry.Register<IPostService, PostService>(c => c.With(Lifetimes.PerScope));
    //    registry.Register<IDataTableOptionBuilder, DataTableOptionBuilder> (c => c.With(Lifetimes.PerScope));
    //    registry.Register<ICommentService, CommentService>(c => c.With(Lifetimes.PerScope));
    //}

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en"),
            new CultureInfo("cs"),
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en"),
            // Formatting numbers, dates, etc.
            SupportedCultures = supportedCultures,
            // UI strings that we have localized.
            SupportedUICultures = supportedCultures
        });

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapAreaControllerRoute("AreaAdministrationRoute", "Administration", "Administration/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapRazorPages();
        });
    }
}