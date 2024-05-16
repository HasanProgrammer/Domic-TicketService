using Domic.Core.Domain.Contracts.Interfaces;

namespace Domic.Domain.Service.Contracts.Interfaces;

public interface ITicketCommandRepository : ICommandRepository<Entities.Ticket, string>;