using MediatR;
using Olbrasoft.Blog.Data.Dtos;
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
            var type = typeof(IRequest<CategoryDto>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsAssignableFrom(type, query);
        }

        private static CategoryQuery CreateQuery()
        {
            return new CategoryQuery();
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
