using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserToRole : IdentityUserRole<int> , IHaveCreated
    {
        public BlogUser User { get; set; }
        public BlogRole Role { get; set; }
        public DateTime Created { get; set; }
    }
}