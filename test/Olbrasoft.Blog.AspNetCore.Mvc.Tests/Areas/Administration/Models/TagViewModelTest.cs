using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models
{
    public class TagViewModelTest
    {
        [Fact]
        public void HaveLabe()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var label = model.Label;

            //Assert
            Assert.IsAssignableFrom<string>(label);
        }

        private static TagViewModel CreateModel()
        {
            return new TagViewModel();
        }

        [Fact]
        public void Label_Display()
        {
            //Arrange
            var property = typeof(TagViewModel).GetProperty(nameof(TagViewModel.Label));

            //Act
            var attribute = (DisplayAttribute)property.GetCustomAttribute(typeof(DisplayAttribute));

            //Assert
            Assert.True(attribute.Name == "Label" && attribute.Prompt == "TagLabel");
        }

        [Fact]
        public void Label_Required()
        {
            //Arrange
            var property = typeof(TagViewModel).GetProperty(nameof(TagViewModel.Label));

            //Act
            var attribute = (RequiredAttribute)property.GetCustomAttribute(typeof(RequiredAttribute));

            //Assert
            Assert.True(attribute.ErrorMessageResourceName == "Validation_Required");
        }

        [Fact]
        public void Name_StringLength()
        {
            //Arrange
            var property = typeof(TagViewModel).GetProperty(nameof(TagViewModel.Label));

            //Act
            var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));

            //Assert
            Assert.True(attribute.MaximumLength == 25 && attribute.ErrorMessageResourceName == "Validation_MaxLength");
        }

        [Fact]
        public void Have_Id()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var id = model.Id;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }

        [Fact]
        public void Have_MaxLength()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var length = model.MaxLength;

            //Assert
            Assert.IsAssignableFrom<int>(length);
        }
    }
}