using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.TicketComment.Create;

public class CreateCommandValidator(ITicketCommandRepository ticketCommandRepository) : IValidator<CreateCommand>
{
    public async Task<object> ValidateAsync(CreateCommand input, CancellationToken cancellationToken)
    {
        if (!await ticketCommandRepository.IsExistByIdAsync(input.TicketId, cancellationToken))
            throw new UseCaseException(string.Format("تیکتی با شناسه {0} وجود خارجی ندارد!", input.TicketId));

        return default;
    }
}