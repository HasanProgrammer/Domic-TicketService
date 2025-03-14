﻿#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.InActive;

public class InActiveCommandHandler(IDateTime dateTime, ISerializer serializer,
    [FromKeyedServices("Http2")] IIdentityUser identityUser
) : ICommandHandler<InActiveCommand, string>
{
    private readonly object _validationResult;

    public Task BeforeHandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(InActiveCommand command, CancellationToken cancellationToken)
    {
        var ticket = _validationResult as Domain.Ticket.Entities.Ticket;
        
        ticket.InActive(dateTime, serializer, identityUser);

        return Task.FromResult(ticket.Id);
    }

    public Task AfterHandleAsync(InActiveCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}