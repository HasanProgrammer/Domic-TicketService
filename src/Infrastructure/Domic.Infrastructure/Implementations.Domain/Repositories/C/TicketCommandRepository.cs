using Domic.Domain.Service.Contracts.Interfaces;
using Domic.Persistence.Contexts.C;

namespace Domic.Infrastructure.Implementations.Domain.Repositories.C;

public class TicketCommandRepository : ITicketCommandRepository
{
    private readonly SQLContext _sqlContext;

    public TicketCommandRepository(SQLContext sqlContext)
    {
        _sqlContext = sqlContext;
    }
}