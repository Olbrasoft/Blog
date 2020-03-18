using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    class InMemoryDbContextFactory
    {
        public BlogDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                            .Options;
            var dbContext = new BlogDbContext(options);

            return dbContext;
        }

    }
}
