using Olbrasoft.Blog.Data.Dtos;
using Olbrasoft.Blog.Data.Entities;
using Olbrasoft.Mapping.AutoMapper;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Profiles
{
    public class TagToTagOfUsersDtoProfile : GenericProfile<Tag, TagOfUsersDto>
    {
        public TagToTagOfUsersDtoProfile()
        {
            Expression.ForMember(
               tagOfUsers => tagOfUsers.Creator,
               opt => opt.MapFrom(tag => $"{tag.Creator.FirstName}  {tag.Creator.LastName}"));
        }
    }
}