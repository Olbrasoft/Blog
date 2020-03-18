using Xunit;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class CategoryDtoTest
    {
        [Fact]
        public void Have_Name()
        {
            //Arrange
            var dto = new CategoryDto();

            //Act
            var name = dto.Name;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        [Fact]
        public void Have_Id()
        {
            //Arrange
            var dto = new CategoryDto();

            //Act
            var id = dto.Id;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }

        [Fact]
        public void Have_PostCount()
        {
            //Arrange
            var dto = new CategoryDto();

            //Act
            var count = dto.PostCount;

            //Assert
            Assert.IsAssignableFrom<int>(count);
        }

        [Fact]
        public void Have_Tooltip()
        {
            //Arrange
            var dto = new CategoryDto();

            //Act
            var tip = dto.Tooltip;

            //Assert
            Assert.IsAssignableFrom<string>(tip);
        }
    }
}