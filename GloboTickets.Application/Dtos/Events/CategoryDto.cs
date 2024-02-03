namespace GloboTickets.Application.Dtos.Events;

public class CategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
}