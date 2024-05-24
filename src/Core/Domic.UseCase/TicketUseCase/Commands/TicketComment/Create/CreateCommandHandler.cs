using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.TicketComment.Create;

public class CreateCommandHandler(ITicketCommandRepository ticketCommandRepository) 
    : ICommandHandler<CreateCommand, string>
{
    public Task<string> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        return default;
    }
}