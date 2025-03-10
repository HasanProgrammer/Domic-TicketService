using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Active;

public class ActiveCommand : ICommand<string>
{
    public required string Id { get; set; }
}