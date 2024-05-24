using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Create;

public class CreateCommand : Auditable, ICommand<string>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Status Status { get; init; }
    public required Priority Priority { get; init; }
}