using GloboTickets.Domain.Entities;

namespace GloboTickets.Application.Contracts.Persistance;

public interface ICategoryRepository: IAsyncRepository<Category>
{
    public Task<List<Category>> GetCategoriesWithEvents(bool includeHistory);
}