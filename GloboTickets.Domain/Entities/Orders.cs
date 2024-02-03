using GloboTickets.Domain.Common;

namespace GloboTickets.Domain.Entities;

public class Orders : AuditableEntity
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public int OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
    public bool OrderPaid { get; set; }
}