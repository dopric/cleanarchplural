using FluentValidation;
using GloboTickets.Application.Contracts.Persistance;

namespace GloboTickets.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    
    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
        
        RuleFor(p=>p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");
        
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        
        RuleFor(e=>e)
            .MustAsync(BeUniqueName)
            .WithMessage("An event with the same name and date already exists");
    }
    
    private async Task<bool> BeUniqueName(CreateEventCommand command, CancellationToken token)
    {
        return await _eventRepository.IsEventUnique(command.Name, command.Date);
    }
}