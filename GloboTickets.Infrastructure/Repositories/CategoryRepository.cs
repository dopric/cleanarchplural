using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using GloboTickets.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GloboTickets.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(GloboTicketsDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
    {
        var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
        if (!includeHistory)
        {
            allCategories.ForEach(p=> p.Events.ToList().RemoveAll(c=>c.Date < DateTime.Today));
        }

        return allCategories;
    }
}