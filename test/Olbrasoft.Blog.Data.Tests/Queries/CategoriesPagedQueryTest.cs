using MediatR;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries
{
    public class CategoriesPagedQueryTest
    {
        [Fact]
        public void Instance_Implement_Interface_IRequest_Of()
        {
            //Arrange
            var type = typeof(IRequest<IResultWithTotalCount<CategoryDto>>);

            //Act
            var query = new CategoriesPagedQuery();

            //Assert
            Assert.IsAssignableFrom(type, query);
        }

        [Fact]
        public void Have_Paging()
        {
            //Arrange
            var query = new CategoriesPagedQuery();

            //Act
            var paging = query.Paging;

            //Assert
            Assert.IsAssignableFrom<IPageInfo>(paging);
        }


    }
}
