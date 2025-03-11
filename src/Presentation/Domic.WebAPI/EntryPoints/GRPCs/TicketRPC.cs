using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Ticket.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.UseCase.TicketUseCase.Queries.CheckExist;
using Domic.WebAPI.Frameworks.Extensions.Mappers.TemplateMappers;
using Grpc.Core;

namespace Domic.WebAPI.EntryPoints.GRPCs;

public class TicketRPC(IMediator mediator, IConfiguration configuration, ISerializer serializer, 
    IJsonWebToken jsonWebToken
) : TicketService.TicketServiceBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<CheckExistResponse> CheckExist(CheckExistRequest request, ServerCallContext context)
    {
        var query = new CheckExistQuery { Id = request.TicketId.Value };

        var result = await mediator.DispatchAsync(query, context.CancellationToken);

        return result.ToResponse();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<ReadOneResponse> ReadOne(ReadOneRequest request, ServerCallContext context)
    {
        var query = request.ToQuery();

        var result = await mediator.DispatchAsync(query, context.CancellationToken);

        return result.ToResponse(configuration, serializer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<ReadAllPaginatedResponse> ReadAllPaginate(ReadAllPaginatedRequest request, 
        ServerCallContext context
    )
    {
        var query = request.ToQuery();

        var result = await mediator.DispatchAsync(query, context.CancellationToken);

        return result.ToResponse(configuration, serializer);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<CreateResponse> Create(CreateRequest request, ServerCallContext context)
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<CreateResponse>(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, 
        ServerCallContext context
    )
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<CreateCommentResponse>(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<UpdateResponse> Update(UpdateRequest request, ServerCallContext context)
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<UpdateResponse>(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<ActiveResponse> Active(ActiveRequest request, ServerCallContext context)
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<ActiveResponse>(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<InActiveResponse> InActive(InActiveRequest request, ServerCallContext context)
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<InActiveResponse>(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public override async Task<DeleteResponse> Delete(DeleteRequest request, ServerCallContext context)
    {
        var command = request.ToCommand();

        var result = await mediator.DispatchAsync(command, context.CancellationToken);

        return result.ToResponse<DeleteResponse>(configuration);
    }
}