using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadOne;

public class ReadOneQueryHandler(ITicketCommandRepository ticketCommandRepository) 
    : IQueryHandler<ReadOneQuery, TicketDto>
{
    public Task<TicketDto> HandleAsync(ReadOneQuery query, CancellationToken cancellationToken) 
        => ticketCommandRepository.FindByIdByProjectionAsync(ticket =>
                new TicketDto {
                    Title = ticket.Title.Value,
                    Description = ticket.Description.Value,
                    Status = ticket.Status,
                    Priority = ticket.Priority
                }, query.Id, cancellationToken
           );
}