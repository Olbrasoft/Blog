using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Mapping.AutoMapper;
using System.Linq;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Profiles
{
    public class TagToTagOfUserDtoProfile : GenericProfile<Tag, TagOfUserDto>
    {
        public TagToTagOfUserDtoProfile()
        {
            Expression.ForMember(
                tagOfUser => tagOfUser.PostCount,
                opt => opt.MapFrom(src => src.ToPosts.Count()));
        }
    }
}