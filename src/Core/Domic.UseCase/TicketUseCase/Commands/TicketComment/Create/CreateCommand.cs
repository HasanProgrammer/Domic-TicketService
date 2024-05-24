using Domic.Core.UseCase.Contracts.Abstracts;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.TicketComment.Create;

public class CreateCommand : Auditable, ICommand<string>
{
    public required string Comment { get; set; }
}