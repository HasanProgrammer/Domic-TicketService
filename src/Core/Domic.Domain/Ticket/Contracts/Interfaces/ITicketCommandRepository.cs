using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketCommandRepository : ICommandRepository<Entities.Ticket, string>;