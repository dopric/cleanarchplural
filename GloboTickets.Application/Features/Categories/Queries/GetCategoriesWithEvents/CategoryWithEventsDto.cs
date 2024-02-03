namespace GloboTickets.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class CategoryWithEventsDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<EventDto> Events { get; set; }
}