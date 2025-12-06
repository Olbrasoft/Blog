using System.Security.Claims;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Controllers;

public abstract class BlogController : Controller
{
    private int _currentUserId;

    public int CurrentUserId
    {
        get
        {
            var value = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    
            if (value != null) _currentUserId = int.Parse(value);
                       
            return _currentUserId;
        }
    }
}