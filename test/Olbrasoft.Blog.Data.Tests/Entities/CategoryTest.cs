using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Xunit;

namespace Olbrasoft.Blog.Data.Entities
{
    public class CategoryTest
    {
        [Fact]
        public void Instance_Have_Name()
        {
            //Arrange
            var category = new Category();

            //Act
            var name = category.Name;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        [Fact]
        public void Instance_Inherit_From_CreationInfo()
        {
            //Arrange
            var type = typeof(CreationInfo);

            //Act
            var category = new Category();

            //Assert
            Assert.IsAssignableFrom(type, category);
        }

        [Fact]
        public void Instance_Have_Posts()
        {
            //Arrange
            Category category = CreateCategory();

            //Act
            var posts = category.Posts;

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Post>>(posts);
        }

        private static Category CreateCategory()
        {
            return new Category();
        }

        [Fact]
        public void Name_StringLength_Attribute()
        {
            //Arrange
            var property = typeof(Category).GetProperty("Name");

            //Act
            var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));

            //Assert
            Assert.True(attribute.MaximumLength == 25);
        }
                
        [Fact]
        public void Name_IsRequired()
        {
            //Arrange
            var property = typeof(Category).GetProperty("Name");

            //Act
            var attribute = (RequiredAttribute)property.GetCustomAttribute(typeof(RequiredAttribute));

            //Assert
            Assert.IsAssignableFrom<RequiredAttribute>(attribute);
        }

        [Fact]
        public void Have_Tooltip()
        {
            //Arrange
            var cat = new Category();

            //Act
            var tip = cat.Tooltip;

            //Assert
            Assert.IsAssignableFrom<string>(tip);
        }

        [Fact]
        public void Tooltip_StringLength()
        {
            //Arrange
            var property = typeof(Category).GetProperty(nameof(Category.Tooltip));

            //Act
            var attribute = (StringLengthAttribute)property.GetCustomAttribute(typeof(StringLengthAttribute));

            //Assert
            Assert.True(attribute.MaximumLength == 50);

        }



    }
}