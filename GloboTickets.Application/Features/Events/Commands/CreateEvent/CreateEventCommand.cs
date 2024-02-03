using MediatR;

namespace GloboTickets.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommand  : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Artist { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Descrition { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public override string ToString()
    {
        return $"Event Name: {Name}; Price: {Price}; On: {Date.ToShortDateString()}";
    }
}