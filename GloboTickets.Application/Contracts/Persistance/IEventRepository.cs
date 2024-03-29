﻿using GloboTickets.Domain.Entities;

namespace GloboTickets.Application.Contracts.Persistance;

public interface IEventRepository : IAsyncRepository<Event>
{
    Task<bool> IsEventUnique(string commandName, DateTime commandDate);
}