﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Olbrasoft.Blog.Data.Entities.Identity
{
    public class BlogUserClaim : IdentityUserClaim<int>, IHaveCreated
    {
        public DateTimeOffset Created { get; set; }
    }
}