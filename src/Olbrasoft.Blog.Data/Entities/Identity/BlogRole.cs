using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogRole : IdentityRole<int>, IHaveCreated
    {
        public DateTime Created { get; set; }
        public IEnumerable<BlogUserToRole> ToUsers { get; set; } = new HashSet<BlogUserToRole>();
    }
}