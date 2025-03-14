﻿#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Delete;

public class DeleteCommandHandler(ITicketCommandRepository ticketCommandRepository, IDateTime dateTime, 
    ISerializer serializer, [FromKeyedServices("Http2")] IIdentityUser identityUser
) : ICommandHandler<DeleteCommand, string>
{
    private readonly object _validationResult;

    public Task BeforeHandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(DeleteCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Ticket.Entities.Ticket;
        
        ticket.Delete(dateTime, serializer, identityUser);
        
        ticketCommandRepository.Change(ticket);

        return Task.FromResult(ticket.Id);
    }

    public Task AfterHandleAsync(DeleteCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}