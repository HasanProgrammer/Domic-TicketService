using Domic.Core.Common.ClassExtensions;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Ticket.Grpc;
using Domic.UseCase.TicketUseCase.DTOs;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.TemplateMappers;

//Query
public static partial class RpcResponseExtension
{
    /// <summary>
    /// Map bool -> CheckExistResponse
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static CheckExistResponse ToResponse(this bool result)
        => new() { Result = result };
    
    /// <summary>
    /// Map TicketDto -> ReadOneResponse
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static ReadOneResponse ToResponse(this TicketDto result, IConfiguration configuration, ISerializer serializer)
        => new() {
               Code = configuration.GetSuccessStatusCode(),
               Message = configuration.GetSuccessFetchDataMessage(),
               Body = new ReadOneResponseBody {
                   Ticket = serializer.Serialize(result)
               }
           };
    
    /// <summary>
    /// Map List<TicketDto> -> ReadAllPaginatedResponse
    /// </summary>
    /// <param name="result"></param>
    /// <param name="configuration"></param>
    /// <param name="serializer"></param>
    /// <returns></returns>
    public static ReadAllPaginatedResponse ToResponse(this List<TicketDto> result, 
        IConfiguration configuration, ISerializer serializer
    ) => new() {
            Code = configuration.GetSuccessStatusCode(),
            Message = configuration.GetSuccessFetchDataMessage(),
            Body = new ReadAllPaginatedResponseBody {
                Tickets = serializer.Serialize(result)
            }
         };
}

//Command
public partial class RpcResponseExtension
{
    /// <summary>
    /// Map string -> TResponse
    /// </summary>
    /// <param name="result"></param>
    /// <param name="configuration"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    public static TResponse ToResponse<TResponse>(this string result, IConfiguration configuration)
    {
        object response = default;
        
        if (typeof(TResponse) == typeof(CreateResponse))
            response = new CreateResponse {
                Code = configuration.GetSuccessCreateStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new CreateResponseBody { TicketId = result }
            };
        if (typeof(TResponse) == typeof(CreateCommentResponse))
            response = new CreateCommentResponse {
                Code = configuration.GetSuccessCreateStatusCode(),
                Message = configuration.GetSuccessCreateMessage(),
                Body = new CreateCommentResponseBody { TicketCommentId = result }
            };
        else if(typeof(TResponse) == typeof(UpdateResponse))
            response = new UpdateResponse {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessUpdateMessage(),
                Body = new UpdateResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(ActiveResponse))
            response = new ActiveResponse {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessUpdateMessage(),
                Body = new ActiveResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(InActiveResponse))
            response = new InActiveResponse {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessUpdateMessage(),
                Body = new InActiveResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(DeleteResponse))
            response = new DeleteResponse {
                Code = configuration.GetSuccessStatusCode(),
                Message = configuration.GetSuccessUpdateMessage(),
                Body = new DeleteResponseBody { TicketId = result }
            };

        return (TResponse)response;
    }
}