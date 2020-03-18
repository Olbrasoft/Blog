using System.Collections.Generic;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities
{
    public class PostTest
    {
        [Fact]
        public void Instance_Inherit_From_CreationInfo()
        {
            //Arrange
            var type = typeof(CreationInfo);

            //Act
            var post = new Post();

            //Assert
            Assert.IsAssignableFrom(type, post);
        }

        [Fact]
        public void Instance_Have_Comments()
        {
            //Arrange
            var post = new Post();

            //Act
            var comments = post.Comments;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Comment>>(comments);
        }

        [Fact]
        public void Instance_Have_Category()
        {
            //Arrange
            var post = new Post { Category = new Category() };

            //Act
            var category = post.Category;

            //Assert
            Assert.IsAssignableFrom<Category>(category);
        }

        [Fact]
        public void Instance_Have_ToTags()
        {
            //Arrange
            var post = new Post();

            //Act
            var toTags = post.ToTags;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<PostToTag>>(toTags);
        }

        [Fact]
        public void Instance_Have_Title()
        {
            //Arrange
            var post = new Post();

            //Act
            var title = post.Title;

            //Assert
            Assert.IsAssignableFrom<string>(title);
        }

        [Fact]
        public void Instance_Have_Content()
        {
            //Arrange
            var post = new Post();

            //Act
            var content = post.Content;

            //Assert
            Assert.IsAssignableFrom<string>(content);
        }
    }
}