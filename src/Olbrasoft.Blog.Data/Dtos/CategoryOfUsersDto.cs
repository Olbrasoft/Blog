namespace Olbrasoft.Blog.Data.Dtos
{
    public class CategoryOfUsersDto : CategoryOfUserDto
    {
        public int CreatorId { get; set; }

        public string Creator { get; set; }
    }
}