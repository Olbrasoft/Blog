using System;

namespace Olbrasoft.Blog.Data
{
    public interface IHaveCreated
    {
        DateTimeOffset Created { get; set; }
    }
}