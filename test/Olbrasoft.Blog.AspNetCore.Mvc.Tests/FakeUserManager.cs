using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class FakeUserManager : UserManager<BlogUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<BlogUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<BlogUser>>().Object,
                new IUserValidator<BlogUser>[0],
                new IPasswordValidator<BlogUser>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<BlogUser>>>().Object)
        { }
    }
}
