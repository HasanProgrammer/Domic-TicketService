using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Ticket.Events;

[MessageBroker(ExchangeType = Exchange.FanOut, Exchange = "")]
public class TicketCreated : CreateDomainEvent<string>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Status { get; init; }
    public required int Priority { get; init; }
}