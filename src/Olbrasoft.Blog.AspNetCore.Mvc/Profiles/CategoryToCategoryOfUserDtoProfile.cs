using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Mapping.AutoMapper;
using System.Linq;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Profiles
{
    public class CategoryToCategoryOfUserDtoProfile : GenericProfile<Category, CategoryOfUserDto>
    {
        public CategoryToCategoryOfUserDtoProfile()
        {
            Expression.ForMember(
                catOfUser => catOfUser.PostCount,
                opt => opt.MapFrom(src => src.Posts.Count()));
        }
    }
}