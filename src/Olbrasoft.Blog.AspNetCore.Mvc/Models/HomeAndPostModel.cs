using Olbrasoft.Blog.Data.Dtos;
using System;
using System.Collections.Generic;

namespace Olbrasoft.Blog.AspNetCore.Mvc.Models
{
    public class HomeAndPostModel
    {
        public Tuple<IEnumerable<CategorySmallDto>, IEnumerable<CategorySmallDto>> Categories { get; set; }
    }
}