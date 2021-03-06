﻿using Olbrasoft.Blog.Data.Dtos.CategoryDtos;
using Xunit;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class CategoryOfUserDtoTest
    {
        [Fact]
        public void Have_Name()
        {
            //Arrange
            var dto = new CategoryOfUserDto();

            //Act
            var name = dto.Name;

            //Assert
            Assert.IsAssignableFrom<string>(name);
        }

        [Fact]
        public void Have_Id()
        {
            //Arrange
            var dto = new CategoryOfUserDto();

            //Act
            var id = dto.Id;

            //Assert
            Assert.IsAssignableFrom<int>(id);
        }

        [Fact]
        public void Have_PostCount()
        {
            //Arrange
            var dto = new CategoryOfUserDto();

            //Act
            var count = dto.PostCount;

            //Assert
            Assert.IsAssignableFrom<int>(count);
        }

        [Fact]
        public void Have_Tooltip()
        {
            //Arrange
            var dto = new CategoryOfUserDto();

            //Act
            var tip = dto.Tooltip;

            //Assert
            Assert.IsAssignableFrom<string>(tip);
        }
    }
}