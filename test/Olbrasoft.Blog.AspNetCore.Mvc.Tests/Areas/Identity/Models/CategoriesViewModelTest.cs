using Moq;
using Olbrasoft.Blog.AspNetCore.Mvc.Properties;
using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Paging;
using Olbrasoft.Paging.X.PagedList;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using X.PagedList;
using Xunit;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Areas.Identity.Models
{
    public class CategoriesViewModelTest
    {
        [Fact]
        public void Have_Name()
        {
            //Arrange
            CategoriesViewModel model = CreateModel();

            //Act
            var name = model.Name;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        private static CategoriesViewModel CreateModel()
        {
            return new CategoriesViewModel { Categories = new Mock<IPagedList<CategoryDto>>().Object };
        }

        [Fact]
        public void Property_Name_Have_Attribute_Dysplay()
        {
            //Arrange
            var property = typeof(CategoriesViewModel).GetProperty("Name");

            //Act
            var attribute = (DisplayAttribute)property.GetCustomAttribute(typeof(DisplayAttribute));

            //Assert
            Assert.True(attribute.Name == "Name" && attribute.Prompt == "CategoryName");
        }

        [Fact]
        public void Name_Is_Required()
        {
            //Arrange
            var property = typeof(CategoriesViewModel).GetProperty("Name");

            //Act
            var attribute = (RequiredAttribute)property.GetCustomAttribute(typeof(RequiredAttribute));

            //Assert
            Assert.True(attribute.ErrorMessageResourceName == "Validation_Required");
        }

        [Fact]
        public void Name_StringLength()
        {
            //Arrange
            var property = typeof(CategoriesViewModel).GetProperty(nameof(CategoriesViewModel.Name));

            //Act
            var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));

            //Assert
            Assert.True(attribute.MaximumLength == 25 && attribute.ErrorMessageResourceName == "Validation_MaxLength");

        }

        [Fact]
        public void NameMaxLength()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var maxLength = model.NameMaxLength;

            //Assert
            Assert.IsAssignableFrom<int>(maxLength);
        }


        [Fact]
        public void TooltipMaxLength()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var maxLegth = model.TooltipLength;

            //Assert
            Assert.IsAssignableFrom<int>(maxLegth);
        }
               
        [Fact]
        public void Have_DoNotExists()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var doNotExist = model.DoNotExists;

            //Assert
            Assert.IsAssignableFrom<bool>(doNotExist);
        }

        [Fact]
        public void Categories()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var categories = model.Categories;

            //Assert
            Assert.IsAssignableFrom<IPagedList<CategoryDto>>(categories);
        }


        [Fact]
        public void Tooltip()
        {
            //Arrange
            var model = CreateModel();

            //Act
            var tip = model.Tooltip;

            //Assert
            Assert.IsAssignableFrom<string>(tip);
        }


        [Fact]
        public void Tooltip_Display()
        {
            //Arrange
            var property = typeof(CategoriesViewModel).GetProperty(nameof(CategoriesViewModel.Tooltip));

            //Act
            var attribute = (DisplayAttribute)property.GetCustomAttribute(typeof(DisplayAttribute));

            //Assert
            Assert.True(attribute.Name == "Tooltip" && attribute.Prompt == "CategoryTooltip" && attribute.ResourceType == typeof(Resources) );
        }

        [Fact]
        public void Tooltip_StringLegth()
        {
            //Arrange
            var property = typeof(CategoriesViewModel).GetProperty(nameof(CategoriesViewModel.Tooltip));

            //Act
            var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));

            //Assert
            Assert.True(attribute.MaximumLength == 50 && attribute.ErrorMessageResourceName == "Validation_MaxLength" && attribute.ErrorMessageResourceType == typeof(Resources));
        }

    }
}