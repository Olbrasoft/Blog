﻿namespace Olbrasoft.Blog.Data.FreeSql;
public interface IDataSelector
{
    ISelect<TEntity> Select<TEntity>() where TEntity : class;
}
