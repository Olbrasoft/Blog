using System;

namespace Olbrasoft.Blog.Data.Dtos
{
    public class PostDto : simplePost
    {

      
        public string Content { get; set; }

        public DateTimeOffset Created { get; set; }

        public int CreatorId { get; set; }
    }

    public class simplePost
    {

        public int Id { get; set; }
        public string Title { get; set; }

    }

}