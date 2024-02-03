using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Application.Exceptions;
using GloboTickets.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var myEvent = _mapper.Map<Event>(request);
        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
            throw new EntryNotCreatedException(validationResult);
        
        myEvent = await _eventRepository.AddAsync(myEvent);
        return myEvent.EventId;
    }
}