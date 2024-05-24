using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Ticket.Contracts.Interfaces;

public interface ITicketCommentCommandRepository : ICommandRepository<Entities.TicketComment, string>;