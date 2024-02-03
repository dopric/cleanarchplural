using GloboTickets.Application.Dtos.Events;
using MediatR;

namespace GloboTickets.Application.Features.Events.Queries.GetEventList;

public class GetEventsListQuery : IRequest<List<EventDto>>
{
    
}