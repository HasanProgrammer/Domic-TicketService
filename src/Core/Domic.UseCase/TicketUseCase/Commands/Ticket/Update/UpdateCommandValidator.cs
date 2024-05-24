﻿using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Core.UseCase.Exceptions;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Update;

public class UpdateCommandValidator(ITicketCommandRepository ticketCommandRepository) : IValidator<UpdateCommand>
{
    public async Task<object> ValidateAsync(UpdateCommand input, CancellationToken cancellationToken)
    {
        var ticket = await ticketCommandRepository.FindByIdAsync(input.Id, cancellationToken);

        if (ticket is null)
            throw new UseCaseException(string.Format("تیکتی با شناسه {0} موجود نمی باشد!", input.Id));

        return ticket;
    }
}