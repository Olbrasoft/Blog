using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Olbrasoft.Blog.Business;
using Olbrasoft.Blog.Business.Services;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Blog.Data.EntityFrameworkCore;
using Olbrasoft.Blog.Data.EntityFrameworkCore.QueryHandlers.CategoryQueryHandlers;
using Olbrasoft.Blog.Data.MappingRegisters;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Paging.DataTables;
using Olbrasoft.Dispatching.DependencyInjection.Microsoft;
using Olbrasoft.Mapping.Mapster.DependencyInjection.Microsoft;
using Olbrasoft.Text.Transformation.Markdown;

namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("BlogDbConnectionString")));

            services.AddScoped<DbContext, BlogDbContext>();

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

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddMapping(typeof(PostToPostEditDtoRegister).Assembly);

            services.AddMarkdownTransformation();

            AddBusiness(services);

            services.AddDispatching(typeof(CategoriesQuery).Assembly, typeof(CategoriesQueryHandler).Assembly);
        }

        private static void AddBusiness(IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IDataTableBuilder, DataTableBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
}