using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public UpdateEventCommandHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        // get event by id
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
        // map request to event
        _mapper.Map(request, eventToUpdate, 
            typeof(UpdateEventCommand), typeof(Event));
        // update event
        await _eventRepository.UpdateAsync(eventToUpdate);
    }
}