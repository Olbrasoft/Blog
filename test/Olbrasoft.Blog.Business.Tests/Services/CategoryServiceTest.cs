using Moq;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Data.Paging;
using Olbrasoft.Dispatching.Common;
using System.Collections.Generic;
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
            IPagedResult<CategoryOfUserDto> pagedResult = new PagedResult<CategoryOfUserDto>(new[] { new CategoryOfUserDto() });

            var taskResult = Task.FromResult(pagedResult);
            var mediatorMock = new Mock<IDispatcher>();
            mediatorMock.Setup(m => m.DispatchAsync(It.IsAny<CategoryExistsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(true));

            mediatorMock.Setup(m => m.DispatchAsync(It.IsAny<CategoriesByUserIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(taskResult);

            mediatorMock.Setup(m => m.DispatchAsync(It.IsAny<CategoryQuery>(), It.IsAny<CancellationToken>()))
              .Returns(Task.FromResult(new CategoryOfUserDto()));

            return new CategoryService(mediatorMock.Object);
        }

        [Fact]
        public async Task ExistAsync()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.ExistsAsync(0, "");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CategoriesAsync_Returns_IEnumerable_Of_CategorySmallDto()
        {
            //Arrange
            var service = CreateServiceAsync();

            //Act
            var result = await service.CategoriesAsync();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<CategorySmallDto>>(result);
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
            Assert.IsAssignableFrom<CategoryOfUserDto>(result);
        }
    }
}