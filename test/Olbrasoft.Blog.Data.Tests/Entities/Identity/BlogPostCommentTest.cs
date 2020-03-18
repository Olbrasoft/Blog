using Xunit;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogPostCommentTest
    {
        [Fact]
        public void Instance_Have_Text()
        {
            //Arrange
            var comment = new Comment();

            //Act
            var text = comment.Text;

            //Assert
            Assert.IsAssignableFrom<string>(text);

        }

        [Fact]
        public void Instance_Inherit_From_CreationInfo()
        {
            //Arrange
            var type = typeof(CreationInfo);

            //Act
            var comment = new Comment();

            //Assert
            Assert.IsAssignableFrom(type, comment);
        }

        [Fact]
        public void Instance_Have_Post()
        {
            //Arrange
            var comment = new Comment { Post = new Post() };

            //Act
            var post = comment.Post;

            //Assert
            Assert.IsAssignableFrom<Post>(post);

        }
    }
}