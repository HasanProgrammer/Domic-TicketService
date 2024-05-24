using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Commands.TicketComment.Create;

public class CreateCommandHandler(ITicketCommentCommandRepository ticketCommentCommandRepository, 
    IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, ISerializer serializer
) : ICommandHandler<CreateCommand, string>
{
    [WithTransaction, WithValidation]
    public Task<string> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        var newTicketComment =
            new Domain.Ticket.Entities.TicketComment(globalUniqueIdGenerator, dateTime, serializer, command.TicketId,
                command.Comment, command.UserId, command.UserRoles
            );
        
        ticketCommentCommandRepository.Add(newTicketComment);
        
        return Task.FromResult(newTicketComment.Id);
    }
}