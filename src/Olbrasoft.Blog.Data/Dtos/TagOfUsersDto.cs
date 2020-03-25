namespace Olbrasoft.Blog.Data.Dtos
{
    public class TagOfUsersDto : TagOfUserDto
    {
        public int CreatorId { get; set; }

        public string Creator { get; set; }
    }
}