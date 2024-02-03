using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Categories.Queries.GetCategoriesWithEvents;

public class GetCategoryWithEventsQueryHandler : IRequestHandler<GetCategoryWithEventsQuery, List<CategoryWithEventsDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IMapper _mapper;

    public GetCategoryWithEventsQueryHandler(ICategoryRepository categoryRepository, IAsyncRepository<Event> eventRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _eventRepository = eventRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CategoryWithEventsDto>> Handle(GetCategoryWithEventsQuery request, CancellationToken cancellationToken)
    {
        var allCategories = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
        return _mapper.Map<List<CategoryWithEventsDto>>(allCategories);
    }
}