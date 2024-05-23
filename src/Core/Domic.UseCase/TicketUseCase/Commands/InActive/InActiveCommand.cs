using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.InActive;

public class InActiveCommand : Auditable, ICommand<string>
{
    public required string Id { get; set; }
}