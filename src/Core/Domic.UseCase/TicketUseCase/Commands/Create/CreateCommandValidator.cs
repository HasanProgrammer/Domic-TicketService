using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandValidator(ITicketCommandRepository ticketCommandRepository) : IValidator<CreateCommand>
{
    public Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken) 
        => Task.FromResult(default(object));
}