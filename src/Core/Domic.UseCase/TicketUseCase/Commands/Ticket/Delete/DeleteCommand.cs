using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Delete;

public class DeleteCommand : ICommand<string>
{
    public required string Id { get; set; }
}