﻿namespace GloboTickets.Application.Features.Categories.Queries.GetCategoryList;

public class CategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
}