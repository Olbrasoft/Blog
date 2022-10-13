using Moq;
using Olbrasoft.Data.Cqrs;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Business.Services
{
    public class TagServiceTest
    {
        [Fact]
        public void Instance_Inherit_From_Service()
        {
            //Arrange
            var type = typeof(Service);

            //Act
            var ser = CreateService();

            //Assert
            Assert.IsAssignableFrom(type, ser);
        }

        [Fact]
        public void Instance_Implement_ITagService()
        {
            //Arrange
            var type = typeof(ITagService);

            //Act
            var ser = CreateService();

            //Assert
            Assert.IsAssignableFrom(type, ser);
        }

        private static TagService CreateService()
        {
            var processorMock = new Mock<IQueryProcessor>();

            return new TagService(processorMock.Object, new Mock<ICommandExecutor>().Object );
        }

        [Fact]
        public async Task SaveAsync()
        {
            //Arrange
            var ser = CreateService();

            //Act
            var result = await ser.SaveAsync(0, "", 0);

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }
    }
}