using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.TicketUseCase.Commands.Ticket.Create;

public class CreateCommandHandler(
    ITicketCommandRepository ticketCommandRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator,
    IDateTime dateTime, ISerializer serializer, [FromKeyedServices("Http2")] IIdentityUser identityUser
) : ICommandHandler<CreateCommand, string>
{
    public Task BeforeHandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;

    [WithTransaction]
    public async Task<string> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        var newTicket = new Domain.Ticket.Entities.Ticket(
            globalUniqueIdGenerator, dateTime, identityUser, serializer, command.CategoryId, command.Title, 
            command.Description, command.Priority
        );
        
        await ticketCommandRepository.AddAsync(newTicket, cancellationToken);

        return newTicket.Id;
    }

    public Task AfterHandleAsync(CreateCommand command, CancellationToken cancellationToken)
        => Task.CompletedTask;
}