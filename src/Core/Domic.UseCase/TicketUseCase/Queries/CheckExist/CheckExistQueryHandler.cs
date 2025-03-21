﻿using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Queries.CheckExist;

public class CheckExistQueryHandler(ITicketCommandRepository ticketCommandRepository) 
    : IQueryHandler<CheckExistQuery, bool>
{
    public async Task<bool> HandleAsync(CheckExistQuery query, CancellationToken cancellationToken)
        => await ticketCommandRepository.IsExistByIdAsync(query.Id, cancellationToken);
}