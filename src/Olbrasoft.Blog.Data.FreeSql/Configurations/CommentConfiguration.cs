using FreeSql.Extensions.EfCoreFluentApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations;
public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EfCoreTableFluent<Comment> model)
    {
        model.ToTable("Comments");
    }
}
