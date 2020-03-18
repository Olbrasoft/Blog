using MediatR;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Queries
{
    public class CategoryExistsQueryTest
    {

        [Fact]
        public void Instance_Implement_Interface_IRequest_Of_True()
        {
            //Arrange
            var type = typeof(IRequest<bool>);

            //Act
            var query = CreateQuery();

            //Assert
            Assert.IsAssignableFrom(type, query);

        }

        [Fact]
        public void Name()
        {
            //Arrange
            var query = CreateQuery();

            //Act
            var name = query.Name;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        private static CategoryExistsQuery CreateQuery()
        {
            return new CategoryExistsQuery { ExceptId = 0 };
        }

        [Fact]
        public void ExceptId()
        {
            //Arrange
            var query = CreateQuery();

            //Act
            var id = query.ExceptId;

            //Assert
            Assert.IsAssignableFrom<int?>(id);
        }
    }
}
