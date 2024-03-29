﻿namespace Olbrasoft.Blog.Data.Dtos.CategoryDtos;

public class CategoryOfUserDto : CategorySmallDto
{
    public int PostCount { get; set; }

    public string Tooltip { get; set; } = string.Empty;

    public DateTimeOffset Created { get; set; }
}