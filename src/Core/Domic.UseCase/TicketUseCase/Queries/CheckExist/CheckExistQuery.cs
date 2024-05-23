using Domic.Core.UseCase.Contracts.Interfaces;

namespace Domic.UseCase.TicketUseCase.Queries.CheckExist;

public class CheckExistQuery : IQuery<bool>
{
    public required string Id { get; set; }
}