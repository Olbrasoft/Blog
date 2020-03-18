using Microsoft.AspNetCore.Identity;
using System;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogRoleClaim : IdentityRoleClaim<int>, IHaveCreated
    {
        public DateTime Created { get; set; }
    }
}