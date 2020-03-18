using System;
using Microsoft.AspNetCore.Identity;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserLogin : IdentityUserLogin<int>, IHaveCreated
    {
        public DateTime Created { get; set; }
    }
}