using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Olbrasoft.Blog.Data.Entities;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Configurations
{
    public class BlogPostCommentConfiguration :BlogTypeConfiguration<Comment>
    {

        public BlogPostCommentConfiguration():base("Comments")
        {
            
        }

        public override void TypeConfigure(EntityTypeBuilder<Comment> builder)
        {
        }
    }
}