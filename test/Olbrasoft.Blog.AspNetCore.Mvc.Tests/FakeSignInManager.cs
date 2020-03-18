using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Olbrasoft.Blog.Data.Entities.Identity;


namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class FakeSignInManager : SignInManager<BlogUser>
    {
        public FakeSignInManager() : base(new FakeUserManager(),
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<BlogUser>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<BlogUser>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object,
                     new Mock<IUserConfirmation<BlogUser>>().Object)
        { }
    }
}
