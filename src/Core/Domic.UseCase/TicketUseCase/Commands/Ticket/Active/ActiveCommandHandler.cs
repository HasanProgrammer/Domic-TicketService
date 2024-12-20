﻿#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Active;

public class ActiveCommandHandler(IDateTime dateTime, ISerializer serializer) : ICommandHandler<ActiveCommand, string>
{
    private readonly object _validationResult;
    
    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(ActiveCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Ticket.Entities.Ticket;
        
        ticket.Active(dateTime, serializer, command.UserId, command.UserRoles);

        return Task.FromResult(ticket.Id);
    }

    public Task AfterTransactionHandleAsync(ActiveCommand message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}