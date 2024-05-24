using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.UseCase.TicketUseCase.Queries.ReadAllPaginate;

public class ReadAllPaginatedQueryHandler(ITicketCommandRepository ticketCommandRepository) 
    : IQueryHandler<ReadAllPaginatedQuery, List<TicketDto>>
{
    public async Task<List<TicketDto>> HandleAsync(ReadAllPaginatedQuery query, CancellationToken cancellationToken)
    {
        var result =
            await ticketCommandRepository.FindAllWithPaginateByProjectionAsync(ticket => 
                new TicketDto {
                    Title = ticket.Title.Value,
                    Description = ticket.Description.Value,
                    Status = ticket.Status,
                    Priority = ticket.Priority
                }, 
                query.CountPerPage.Value, query.PageNumber.Value, cancellationToken
            );

        return result.ToList();
    }
}