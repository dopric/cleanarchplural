using MediatR;

namespace GloboTickets.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class GetCategoryWithEventsQuery : IRequest<List<CategoryWithEventsDto>>
{
    public bool IncludeHistory { get; set; }
}