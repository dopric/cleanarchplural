using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Domain.Entities;
using GloboTickets.Infrastructure.Data;

namespace GloboTickets.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Orders>, IOrderRepository
{
    public OrderRepository(GloboTicketsDbContext dbContext) : base(dbContext)
    {
    }
}