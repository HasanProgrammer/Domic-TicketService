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
               Code = configuration.GetValue<int>("StatusCode:SuccessFetchData"),
               Message = configuration.GetValue<string>("Message:FA:SuccessFetchData"),
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
            Code = configuration.GetValue<int>("StatusCode:SuccessFetchData"),
            Message = configuration.GetValue<string>("Message:FA:SuccessFetchData"),
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
                Code = configuration.GetValue<int>("StatusCode:SuccessCreate"),
                Message = configuration.GetValue<string>("Message:FA:SuccessCreate"),
                Body = new CreateResponseBody { TicketId = result }
            };
        else if(typeof(TResponse) == typeof(UpdateResponse))
            response = new UpdateResponse {
                Code = configuration.GetValue<int>("StatusCode:Success"),
                Message = configuration.GetValue<string>("Message:FA:SuccessUpdate"),
                Body = new UpdateResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(ActiveResponse))
            response = new ActiveResponse {
                Code = configuration.GetValue<int>("StatusCode:Success"),
                Message = configuration.GetValue<string>("Message:FA:SuccessUpdate"),
                Body = new ActiveResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(InActiveResponse))
            response = new InActiveResponse {
                Code = configuration.GetValue<int>("StatusCode:Success"),
                Message = configuration.GetValue<string>("Message:FA:SuccessUpdate"),
                Body = new InActiveResponseBody { TicketId = result }
            };
        if(typeof(TResponse) == typeof(DeleteResponse))
            response = new DeleteResponse {
                Code = configuration.GetValue<int>("StatusCode:Success"),
                Message = configuration.GetValue<string>("Message:FA:SuccessDelete"),
                Body = new DeleteResponseBody { TicketId = result }
            };

        return (TResponse)response;
    }
}