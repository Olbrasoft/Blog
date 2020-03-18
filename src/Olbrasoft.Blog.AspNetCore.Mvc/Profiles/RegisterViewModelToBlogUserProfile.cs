using Olbrasoft.Blog.AspNetCore.Mvc.Areas.Administration.Models;
using Olbrasoft.Blog.Data.Entities.Identity;
using Olbrasoft.Mapping.AutoMapper;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Profiles
{
    public class RegisterViewModelToBlogUserProfile : GenericProfile<RegisterViewModel, BlogUser>
    {
        public RegisterViewModelToBlogUserProfile()
        {
           Expression.ForMember(
               user => user.UserName,
               opt => opt.MapFrom(src => src.Email));
        }
    }
}