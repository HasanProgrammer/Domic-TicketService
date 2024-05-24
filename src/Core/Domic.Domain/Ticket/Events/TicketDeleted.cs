using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Enumerations;

namespace Domic.Domain.Ticket.Events;

[MessageBroker(ExchangeType = Exchange.FanOut, Exchange = "")]
public class TicketDeleted : UpdateDomainEvent<string>;