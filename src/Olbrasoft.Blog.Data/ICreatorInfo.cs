using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data
{
    public interface ICreatorInfo
    {
        int CreatorId { get; set; }

        BlogUser Creator { get; set; }
    }
}