﻿namespace GloboTickets.Application.Dtos.Events;

public class EventDto
{
    public Guid EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public CategoryDto Category { get; set; } = default!;
}