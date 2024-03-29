﻿using Olbrasoft.Blog.Data.Entities.Identity;

namespace Olbrasoft.Blog.Data.FreeSql.Configurations.EntityConfigurations.Identity;
public class RoleConfiguration : IEntityTypeConfiguration<BlogRole>
{
    public void Configure(EfCoreTableFluent<BlogRole> model)
    {
        model.ToTable("Identity.Roles");
    }
}



