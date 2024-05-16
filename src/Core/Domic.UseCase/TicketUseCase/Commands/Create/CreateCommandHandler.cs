using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.UseCase.Attributes;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Domain.Service.Entities;

namespace Domic.UseCase.TicketUseCase.Commands.Create;

public class CreateCommandHandler(
    ITicketCommandRepository ticketCommandRepository, IGlobalUniqueIdGenerator globalUniqueIdGenerator,
    IDateTime dateTime, ISerializer serializer
)
: ICommandHandler<CreateCommand, bool>
{
    [WithTransaction]
    public Task<bool> HandleAsync(CreateCommand command, CancellationToken cancellationToken)
    {
        var newTicket = new Ticket(
            globalUniqueIdGenerator, dateTime, serializer, command.Title, command.Description, command.Priority, 
            command.UserId, command.UserRoles
        );
        
        ticketCommandRepository.Add(newTicket);

        return Task.FromResult(true);
    }
}