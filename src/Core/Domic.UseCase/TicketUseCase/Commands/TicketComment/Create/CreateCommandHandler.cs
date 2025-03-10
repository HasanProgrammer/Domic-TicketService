using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Domic.UseCase.TicketUseCase.Commands.TicketComment.Create;

public class CreateCommandHandler(ITicketCommentCommandRepository ticketCommentCommandRepository, 
    IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, ISerializer serializer, 
    [FromKeyedServices("Http2")] IIdentityUser identityUser
) : ICommandHandler<CreateCommand, string>
{
    [WithTransaction, WithValidation]
    public async Task<string> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        var newTicketComment =
            new Domain.Ticket.Entities.TicketComment(globalUniqueIdGenerator, dateTime, serializer, identityUser,
                command.TicketId, command.Comment
            );
        
        await ticketCommentCommandRepository.AddAsync(newTicketComment, cancellationToken);

        return newTicketComment.Id;
    }

    public Task AfterTransactionHandleAsync(CreateCommand message, CancellationToken cancellationToken)
        => Task.CompletedTask;
}