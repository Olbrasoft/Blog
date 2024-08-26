using Microsoft.AspNetCore.Localization;
using Olbrasoft.Blog.AspNetCore.Mvc;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.BuildServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("cs"), };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    // Formatting numbers, dates, etc.
    SupportedCultures = supportedCultures,
    // UI strings that we have localized.
    SupportedUICultures = supportedCultures
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapAreaControllerRoute("AreaAdministrationRoute", "Administration", "Administration/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "images",
    pattern: "Images/{postId}/{imageFileNameAndExtension}",
    defaults: new { controller = "Home", action = "GetDefaultImages" });

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
