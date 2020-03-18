using System;
using Microsoft.EntityFrameworkCore.Design;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public class DesignTimeBlogDbContextFactoryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IDesignTimeDbContextFactory_Of_BlogDbContext()
        {
            var type = typeof(IDesignTimeDbContextFactory<BlogDbContext>);

            var factory = new DesignTimeBlogDbContextFactory();

            Assert.IsAssignableFrom(type, factory);
        }

        [Fact]
        public void CreateDbContext_Return_BlogDbContext()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            var factory = new DesignTimeBlogDbContextFactory();

            var ctx = factory.CreateDbContext(args: new []{""});

            Assert.IsAssignableFrom<BlogDbContext>(ctx);

            Assert.NotNull(ctx);
        }
    }
}