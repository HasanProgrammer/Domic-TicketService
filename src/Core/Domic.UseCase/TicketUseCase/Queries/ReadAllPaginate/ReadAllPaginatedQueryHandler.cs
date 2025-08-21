using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;
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
                    Id = ticket.Id,
                    Title = ticket.Title.Value,
                    Description = ticket.Description.Value,
                    Status = ticket.Status,
                    StatusTitle = ticket.Status == Status.Close ? "بسته شده" : (
                        ticket.Status == Status.Waiting ? "در انتظار پاسخ" : "بسته شده"
                    ),
                    Priority = ticket.Priority,
                    PriorityTitle = ticket.Priority == Priority.Critical ? "بحرانی" : (
                        ticket.Priority == Priority.High ? "اولویت بالا" : (
                            ticket.Priority == Priority.Mid ? "اولویت متوسط" : "اولویت پایین"
                        )
                    )
                }, 
                query.CountPerPage.Value, query.PageNumber.Value, cancellationToken
            );

        return result.ToList();
    }
}