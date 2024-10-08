using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "Ticket_User_Queue")]
public class UserActived : UpdateDomainEvent<string>;