using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Application.Dtos.Events;
using GloboTickets.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Events.Queries.GetEventList;

public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventDto>>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetEventsListQueryHandler(IAsyncRepository<Event> repository, IMapper mapper)
    {
        _eventRepository = repository;
        _mapper = mapper;
    }
    
    public async Task<List<EventDto>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        Console.Write("GetEventsListQueryHandler.Handle(GetEvetsListQuery request, CancellationToken cancellationToken) called");
        
        var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
        var mappedEvents = _mapper.Map<List<EventDto>>(allEvents);
        return mappedEvents;
    }
}