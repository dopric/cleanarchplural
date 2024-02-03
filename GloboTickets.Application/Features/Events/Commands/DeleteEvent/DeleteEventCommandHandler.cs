using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using MediatR;

namespace GloboTickets.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IAsyncRepository<Event> _eventRepository;

    public DeleteEventCommandHandler(IAsyncRepository<Event> eventRepository)
    {
        _eventRepository = eventRepository;
    }
    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        Guid eventToDeleteGuid = request.EventId;
        var eventToDelete = await _eventRepository.GetByIdAsync(eventToDeleteGuid);
        if (eventToDelete != null)
        {
            await _eventRepository.DeleteAsync(eventToDelete);
        }
    }
}