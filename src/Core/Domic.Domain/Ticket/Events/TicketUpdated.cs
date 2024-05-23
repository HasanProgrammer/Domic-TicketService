using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Service.Events;

[MessageBroker(ExchangeType = Exchange.FanOut, Exchange = "")]
public class TicketUpdated : UpdateDomainEvent<string>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int Status { get; init; }
    public required int Priority { get; init; }
}