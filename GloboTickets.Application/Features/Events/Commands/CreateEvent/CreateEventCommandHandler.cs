using GloboTickets.Application.Contracts.Infrastructure;
using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Application.Exceptions;
using GloboTickets.Application.Models.Mail;
using GloboTickets.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _emailService = emailService;
    }
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var myEvent = _mapper.Map<Event>(request);
        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
            throw new EntryNotCreatedException(validationResult);
        
        myEvent = await _eventRepository.AddAsync(myEvent);
        var email = new Email()
        {
            To = "dragan.opric@team-w.ch",
            Body = "New event was created: " + myEvent.Name,
            Subject = "New event was created"
        };
        try
        {
            await _emailService.SendEmail(email);
        }catch(Exception e)
        {
            //log this error
        }
        return myEvent.EventId;
    }
}