using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Queries.CheckExist;

public class CheckExistQueryHandler(ITicketCommandRepository ticketCommandRepository) 
    : IQueryHandler<CheckExistQuery, bool>
{
    public async Task<bool> HandleAsync(CheckExistQuery query, CancellationToken cancellationToken)
        => await ticketCommandRepository.FindByIdAsync(query.Id, cancellationToken) is not null;
}