using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseLightInject(services => services.RegisterFrom<CompositionRoot>())
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        //Singularity now error
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //  Host.CreateDefaultBuilder(args)
        //      .ConfigureWebHostDefaults(webBuilder =>
        //      {
        //          webBuilder.UseStartup<Startup>();
        //      }).UseSingularity();
    }
}