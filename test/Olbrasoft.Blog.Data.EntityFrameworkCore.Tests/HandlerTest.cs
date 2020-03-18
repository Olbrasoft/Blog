using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore
{
    public class HandlerTest
    {
        [Fact]
        public void IsAbstract()
        {
            //Arrange
            var type = typeof(Handler<,>);

            //Act
            var isAbstract = type.IsAbstract;

            //Assert
            Assert.True(isAbstract);
        }

        [Fact]
        public void Implement_Interface_IRequsetHandler()
        {
            //Arrange
            var type = typeof(Handler<,>);

            //Act
            var result = type.GetInterfaces().FirstOrDefault();

            //Assert
            Assert.Contains("IRequestHandler", result.Name);
        }
    }
}
