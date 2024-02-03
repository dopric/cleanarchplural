using GloboTickets.Application.Dtos.Events;
using GloboTickets.Application.Responses;

namespace GloboTickets.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandResponse : BaseResponse
{
    public EventDto Event { get; set; } = default!;
    
    public CreateEventCommandResponse() : base()
    {
    }
}