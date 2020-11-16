using Moq;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Olbrasoft.Blog.Data.Queries.CategoryQueries;
using Olbrasoft.Dispatching.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries
{
    public class CategoryQueryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IRequest_Of_CategoryDto()
        {
            //Arrange
            var type = typeof(IRequest<CategoryOfUserDto>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsAssignableFrom(type, query);
        }

        private static CategoryQuery CreateQuery()
        {
            var dispatcherMock = new Mock<IDispatcher>();

            return new CategoryQuery(dispatcherMock.Object);
        }

        [Fact]
        public void Have_Id()
        {
            //Arrange
            var query = CreateQuery();

            //Act
            var id = query.Id;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }
    }
}