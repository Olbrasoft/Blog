using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Olbrasoft.Blog.AspNetCore.Mvc;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //    Host.CreateDefaultBuilder(args)
    //    .UseLightInject(services => services.RegisterFrom<CompositionRoot>())
    //    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var b = Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();

          });


        //Registration Grace
       // b.ConfigureContainer<IInjectionScope>(registry =>
       //{
       //    registry.SetupMvc();
       //    registry.AddDispatching(typeof(CategoriesQuery).Assembly, typeof(CategoriesQueryHandler).Assembly);
       //});


        //b.ConfigureContainer<IInjectionScope>(registry =>
        //{
        //    registry.SetupMvc();

        //    registry.AddDispatching(typeof(CategoriesQuery).Assembly, typeof(CategoriesQueryHandler).Assembly);

        //    ////Setup some logger
        //    //registry.ConfigureSettings(s =>
        //    //{
        //    //    s.With(Loggers.ConsoleLogger);
        //    //});

        //    //registry.Configure(p => p.Export<CategoryService>().As<ICategoryService>().Lifestyle.SingletonPerScope());
        //    //registry.Configure(p => p.Export<TagService>().As<ITagService>().Lifestyle.SingletonPerScope()); //.Register<ITagService, TagService>(c => c.With(Lifetimes.PerScope));
        //    //registry.Configure(p => p.Export<PostService>().As<IPostService>().Lifestyle.SingletonPerScope()); //Register<IPostService, PostService>(c => c.With(Lifetimes.PerScope));
        //    //registry.Configure(p => p.Export<DataTableOptionBuilder>().As<IDataTableOptionBuilder>().Lifestyle.SingletonPerScope());  //.Register<IDataTableOptionBuilder, DataTableOptionBuilder>(c => c.With(Lifetimes.PerScope));
        //    //registry.Configure(p => p.Export<CommentService>().As<ICommentService>().Lifestyle.SingletonPerScope()); //.Register<ICommentService, CommentService>(c => c.With(Lifetimes.PerScope));

        //});


        return b;
    }

}