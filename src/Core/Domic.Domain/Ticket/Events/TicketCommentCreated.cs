using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Ticket.Events;

[EventConfig(ExchangeType = Exchange.FanOut, Exchange = "Ticket_TicketComment_Exchange")]
public class TicketCommentCreated : CreateDomainEvent<string>
{
    public required string Comment { get; init; }
}