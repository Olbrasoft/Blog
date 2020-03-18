using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Blog.Data.Entities.Identity;
using ServiceStack.Testing;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public class BlogDbContextTest
    {
        [Fact]
        public void Inherit_From_IdentityDbContext()
        {
            var type = typeof(IdentityDbContext<BlogUser, BlogRole, int, BlogUserClaim, BlogUserToRole, BlogUserLogin, BlogRoleClaim, BlogUserToken>);

            var ctx = BlogDbContext();

            Assert.IsAssignableFrom(type, ctx);
        }

        private static BlogDbContext BlogDbContext()
        {
            
            var ctx = new BlogDbContext(new DbContextOptions<BlogDbContext>());
            return ctx;
        }


        [Fact]
        public void Have_Posts()
        {
            //Arrange
            var ctx = BlogDbContext();

            //Act
            var posts = ctx.Posts;

            //Assert
            Assert.IsAssignableFrom<DbSet<Post>>(posts);

        }

        [Fact]
        public void Have_Categories()
        {
            //Arrange
            var ctx = BlogDbContext();

            //Act
            var categories = ctx.Categories;

            //Assert
            Assert.IsAssignableFrom<DbSet<Category>>(categories);
        }

        [Fact]
        public void Have_Comments()
        {
            //Arrange
            var ctx = BlogDbContext();

            //Act
            var comments = ctx.Comments;

            //Assert
            Assert.IsAssignableFrom<DbSet<Comment>>(comments);
        }

        [Fact]
        public void Have_Tags()
        {
            //Arrange
            var ctx = BlogDbContext();

            //Act
            var tags = ctx.Tags;

            //Assert
            Assert.IsAssignableFrom<DbSet<Tag>>(tags);
        }

        [Fact]
        public void Have_DefaultRoles()
        {
            //Arrange
            var type = typeof(IEnumerable<BlogRole>);

            //Act
            var roles = BlogDbContext().DefaultRoles;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<BlogRole>>(roles);
        }

        [Fact]
        public void Instance_Implement_Interface_ISet()
        {
            //Arrange
            var type = typeof(IHaveSet);

            //Act
            var ctx = BlogDbContext();

            //Assert
            Assert.IsAssignableFrom(type, ctx);
        }
    }
}
