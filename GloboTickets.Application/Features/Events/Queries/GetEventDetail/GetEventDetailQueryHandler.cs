using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Application.Dtos.Events;
using MapsterMapper;
using MediatR;
using GloboTickets.Domain.Entities;

namespace GloboTickets.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailDto>
{
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;

    public GetEventDetailQueryHandler(IAsyncRepository<Event> repository, IMapper mapper, IAsyncRepository<Category> categoryRepository)
    {
        _eventRepository = repository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<EventDetailDto> Handle(GetEventDetailQuery request, 
        CancellationToken cancellationToken)
    {
        Event? @event= await _eventRepository.GetByIdAsync(request.EventId);
        if (@event == null)
        {
            return null;
        }
        var eventDto = _mapper.Map<EventDetailDto>(@event);
        Category? category = await _categoryRepository.GetByIdAsync(@event.CategoryId);
        eventDto.Category = _mapper.Map<CategoryDto>(category);
        return eventDto;
    }
}