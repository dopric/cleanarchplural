using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using GloboTickets.Infrastructure.Data;

namespace GloboTickets.Infrastructure.Repositories;

public class EventsRepository : BaseRepository<Event>, IEventRepository
{
    public EventsRepository(GloboTicketsDbContext dbContext) : base(dbContext)
    {
    }

    public Task<bool> IsEventUnique(string name, DateTime eventDate)
    {
        var matches = _dbContext.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate.Date));
        return Task.FromResult(matches);
    }
}