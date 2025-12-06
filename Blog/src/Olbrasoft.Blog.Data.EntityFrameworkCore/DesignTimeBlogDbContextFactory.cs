using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore;

/// <summary>
/// Factory class for creating the design-time instance of the BlogDbContext.
/// </summary>
public class DesignTimeBlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
{
    /// <summary>
    /// Creates a new instance of the BlogDbContext for design-time tools.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>The created BlogDbContext instance.</returns>
    public BlogDbContext CreateDbContext(string[] args)
    {
        // Get environment
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        // Build config
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        var connectionString = config.GetConnectionString("BlogDbConnectionString");

        // Create DB context with connection from your AppSettings
        var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>()
            .UseSqlServer(connectionString);

        return new BlogDbContext(optionsBuilder.Options);
    }
}