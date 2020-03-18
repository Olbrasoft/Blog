using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Business.Services
{
    public class ServiceTest
    {
        [Fact]
        public void Is_Asbstract()
        {
            //Arrange
            var type = typeof(Service);

            //Act
            var ressult = type.IsAbstract;

            //Assert
            Assert.True(ressult);
        }

    }
}
