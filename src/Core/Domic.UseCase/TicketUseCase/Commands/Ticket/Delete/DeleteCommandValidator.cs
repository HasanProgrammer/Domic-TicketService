using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.Domain.Service.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Delete;

public class DeleteCommandValidator(ITicketCommandRepository ticketCommandRepository) : IValidator<DeleteCommand>
{
    public async Task<object> ValidateAsync(DeleteCommand input, CancellationToken cancellationToken)
    {
        var ticket = await ticketCommandRepository.FindByIdAsync(input.Id, cancellationToken);

        if (ticket is null)
            throw new UseCaseException(string.Format("تیکتی با شناسه {0} موجود نمی باشد!", input.Id));

        return ticket;
    }
}