using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Ticket.Grpc;
using Domic.Core.UseCase.Contracts.Interfaces;
using Domic.Domain.Ticket.Enumerations;
using Domic.UseCase.TicketUseCase.Commands.Ticket.Active;
using Domic.UseCase.TicketUseCase.Commands.Ticket.Create;
using Domic.UseCase.TicketUseCase.Commands.Ticket.Delete;
using Domic.UseCase.TicketUseCase.Commands.Ticket.InActive;
using Domic.UseCase.TicketUseCase.Commands.Ticket.Update;
using Domic.UseCase.TicketUseCase.Queries.CheckExist;
using Domic.UseCase.TicketUseCase.Queries.ReadAllPaginate;
using Domic.UseCase.TicketUseCase.Queries.ReadOne;

namespace Domic.WebAPI.Frameworks.Extensions.Mappers.TemplateMappers;

//Query
public static partial class RpcRequestExtension
{
    /// <summary>
    /// Map CheckExistRequest -> CheckExistQuery
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static CheckExistQuery ToQuery(this CheckExistRequest request) => new() { Id = request.TicketId.Value };
    
    /// <summary>
    /// Map ReadOneRequest -> ReadOneQuery
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static ReadOneQuery ToQuery(this ReadOneRequest request) => new() { Id = request.TicketId.Value };

    /// <summary>
    /// Map ReadAllPaginatedRequest -> ReadAllPaginatedQuery
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static ReadAllPaginatedQuery ToQuery(this ReadAllPaginatedRequest request)
        => new() { PageNumber = request.PageNumber.Value, CountPerPage = request.CountPerPage.Value };
}

//Command
public partial class RpcRequestExtension
{
    /// <summary>
    /// Map CreateRequest -> CreateCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <param name="jsonWebToken"></param>
    /// <returns></returns>
    public static CreateCommand ToCommand(this CreateRequest request, string token, IJsonWebToken jsonWebToken) 
        => new() {
            UserId = jsonWebToken.GetIdentityUserId(token),
            CategoryId = request.CategoryId.Value,
            Username = jsonWebToken.GetUsername(token),
            UserRoles = jsonWebToken.GetRoles(token).AsReadOnly(),
            Title = request.Title.Value,
            Description = request.Description.Value,
            Status = (Status)request.Status.Value,
            Priority = (Priority)request.Priority.Value,
            UserPermissions = default
         };
    
    /// <summary>
    /// Map UpdateRequest -> UpdateCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <param name="jsonWebToken"></param>
    /// <returns></returns>
    public static UpdateCommand ToCommand(this UpdateRequest request, string token, IJsonWebToken jsonWebToken) 
        => new() {
            Id = request.TicketId.Value,
            UserId = jsonWebToken.GetIdentityUserId(token),
            CategoryId = request.CategoryId.Value,
            Username = jsonWebToken.GetUsername(token),
            UserRoles = jsonWebToken.GetRoles(token).AsReadOnly(),
            Title = request.Title.Value,
            Description = request.Description.Value,
            Status = (Status)request.Status.Value,
            Priority = (Priority)request.Priority.Value,
            UserPermissions = default
        };
    
    /// <summary>
    /// Map ActiveRequest -> ActiveCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <param name="jsonWebToken"></param>
    /// <returns></returns>
    public static ActiveCommand ToCommand(this ActiveRequest request, string token, IJsonWebToken jsonWebToken) 
        => new() {
            Id = request.TicketId.Value,
            UserId = jsonWebToken.GetIdentityUserId(token),
            Username = jsonWebToken.GetUsername(token),
            UserRoles = jsonWebToken.GetRoles(token).AsReadOnly(),
            UserPermissions = default
        };
    
    /// <summary>
    /// Map InActiveRequest -> InActiveCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <param name="jsonWebToken"></param>
    /// <returns></returns>
    public static InActiveCommand ToCommand(this InActiveRequest request, string token, IJsonWebToken jsonWebToken) 
        => new() {
            Id = request.TicketId.Value,
            UserId = jsonWebToken.GetIdentityUserId(token),
            Username = jsonWebToken.GetUsername(token),
            UserRoles = jsonWebToken.GetRoles(token).AsReadOnly(),
            UserPermissions = default
        };
    
    /// <summary>
    /// Map DeleteRequest -> DeleteCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="token"></param>
    /// <param name="jsonWebToken"></param>
    /// <returns></returns>
    public static DeleteCommand ToCommand(this DeleteRequest request, string token, IJsonWebToken jsonWebToken) 
        => new() {
            Id = request.TicketId.Value,
            UserId = jsonWebToken.GetIdentityUserId(token),
            Username = jsonWebToken.GetUsername(token),
            UserRoles = jsonWebToken.GetRoles(token).AsReadOnly(),
            UserPermissions = default
        };
}