using MediatR;
using Moq;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Queries;
using Olbrasoft.Paging;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Business.Services
{
    public class CategoryServiceTest
    {
        [Fact]
        public void Instance_Implement_Interface_ICategoryService()
        {
            //Arrange
            var type = typeof(ICategoryService);

            //Act
            var service = CreateServiceAsync();

            //Assert
            Assert.IsAssignableFrom(type, service);
        }

        private static CategoryService CreateServiceAsync()
        {
            IResultWithTotalCount<CategoryDto> pagedResult = new ResultWithTotalCount<CategoryDto>
            {
                Result = new[] { new CategoryDto() },
                TotalCount = 0
            };

            var taskResult = Task.FromResult(pagedResult);
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<CategoryExistsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));

            mediatorMock.Setup(m => m.Send(It.IsAny<CategoriesPagedQuery>(), It.IsAny<CancellationToken>()))
                .Returns(taskResult);

            mediatorMock.Setup(m => m.Send(It.IsAny<CategoryQuery>(), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult(new CategoryDto()));

            return new CategoryService(mediatorMock.Object);
        }

        [Fact]
        public async Task ExistAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.ExistsAsync("");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CategoriesAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.CategoriesAsync(new PageInfo());

            //Assert
            Assert.IsAssignableFrom<IResultWithTotalCount<CategoryDto>>(result);
        }

        [Fact]
        public async Task ExistsAsyncEmptyAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.ExistsAsync();

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Fact]
        public async Task ExistsTestAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.ExistsAsync(0, "");

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Fact]
        public async Task SaveAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.SaveAsync(1, "", "", 1);

            //Assert
            Assert.IsAssignableFrom<bool>(result);
        }

        [Fact]
        public async Task CategoryAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.CategoryAsync(0);

            //Assert
            Assert.IsAssignableFrom<CategoryDto>(result);
        }
    }
}