using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;

namespace GloboTickets.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
{
    
    private readonly IAsyncRepository<Category> _categoryRepository;
    private readonly IMapper _mapper;
    
    public GetCategoryListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
        // return mapped categories
        return _mapper.Map<List<CategoryDto>>(allCategories);
    }
}