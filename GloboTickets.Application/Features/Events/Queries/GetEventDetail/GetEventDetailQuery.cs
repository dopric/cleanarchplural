using GloboTickets.Application.Dtos.Events;
using MediatR;

namespace GloboTickets.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery : IRequest<EventDetailDto>
{
    public Guid EventId { get; set; }   
}