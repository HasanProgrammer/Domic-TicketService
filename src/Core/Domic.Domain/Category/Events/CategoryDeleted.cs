using Domic.Core.Domain.Attributes;
using Domic.Core.Domain.Contracts.Abstracts;

namespace Domic.Domain.Ticket.Events;

[EventConfig(Queue = "Ticket_Category_Queue")]
public class CategoryDeleted : UpdateDomainEvent<string>;