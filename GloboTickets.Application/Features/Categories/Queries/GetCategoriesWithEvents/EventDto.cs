namespace GloboTickets.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class EventDto
{
    public Guid EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}

public class CategoryEventDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<EventDto>? Events { get; set; }
}