using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommand : Auditable, ICommand<bool>
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Status Status { get; init; }
    public required Priority Priority { get; init; }
}