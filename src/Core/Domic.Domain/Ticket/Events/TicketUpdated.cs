using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Ticket.Events;

[EventConfig(ExchangeType = Exchange.FanOut, Exchange = "Ticket_Ticket_Exchange")]
public class TicketUpdated : UpdateDomainEvent<string>
{
    public required string CategoryId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Status { get; init; }
    public required int Priority { get; init; }
}