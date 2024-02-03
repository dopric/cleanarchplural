using GloboTickets.Domain.Entities;
using MediatR;

namespace GloboTickets.Application.Features.Categories.Queries.GetCategoryList;

public class GetCategoryListQuery : IRequest<List<Category>>, IRequest<List<CategoryDto>>
{
    
}