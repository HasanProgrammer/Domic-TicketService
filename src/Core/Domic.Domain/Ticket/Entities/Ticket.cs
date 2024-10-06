#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.Domain.ValueObjects;
using Domic.Domain.Ticket.Enumerations;
using Domic.Domain.Ticket.Events;
using Domic.Domain.Ticket.ValueObjects;

namespace Domic.Domain.Ticket.Entities;

public class Ticket : Entity<string>
{
    public string UserId { get; private set; }
    public Status Status { get; private set; }
    public Priority Priority { get; private set; }
    
    //Value Objects
    
    public Title Title { get; private set; }
    public Description Description { get; private set; }

    /*---------------------------------------------------------------*/
    
    //Relations
    
    public ICollection<TicketComment> Comments { get; set; }

    /*---------------------------------------------------------------*/

    //EF Core
    private Ticket() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="globalUniqueIdGeneratorstring"></param>
    /// <param name="dateTime"></param>
    /// <param name="serializer"></param>
    /// <param name="userId"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="priority"></param>
    /// <param name="createdBy"></param>
    /// <param name="createdRoles"></param>
    public Ticket(IGlobalUniqueIdGenerator globalUniqueIdGeneratorstring, IDateTime dateTime, 
        ISerializer serializer, string userId, string title, string description, Priority priority, string createdBy, 
        IReadOnlyCollection<string> createdRoles
    )
    {
        var roles = serializer.Serialize(createdRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGeneratorstring.GetRandom(6);
        UserId = userId;
        Title = new Title(title);
        Description = new Description(description);
        Status = Status.Open;
        Priority = priority;
        CreatedBy = createdBy;
        CreatedRole = roles;
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDate);
        
        AddEvent(
            new TicketCreated {
                Id = Id,
                Title = title,
                UserId = userId,
                Description = description,
                Status = (int)Status,
                Priority = (int)Priority,
                CreatedBy = createdBy,
                CreatedRole = roles,
                CreatedAt_EnglishDate = nowDateTime,
                CreatedAt_PersianDate = nowPersianDate
            }
        );
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="serializer"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="priority"></param>
    /// <param name="status"></param>
    /// <param name="updatedBy"></param>
    /// <param name="updatedRoles"></param>
    public void Change(IDateTime dateTime, ISerializer serializer, string title, string description, Priority priority,
        Status status, string updatedBy, IReadOnlyCollection<string> updatedRoles
    )
    {
        var roles = serializer.Serialize(updatedRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        Title = new Title(title);
        Description = new Description(description);
        Priority = priority;
        Status = status;
        UpdatedBy = updatedBy;
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);
        
        AddEvent(
            new TicketUpdated {
                Id = Id,
                Title = title,
                Description = description,
                Priority = (int)priority,
                Status = (int)status,
                UpdatedBy = updatedBy,
                UpdatedRole = roles,
                UpdatedAt_EnglishDate = nowDateTime,
                UpdatedAt_PersianDate = nowPersianDate
            }
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="serializer"></param>
    /// <param name="updatedBy"></param>
    /// <param name="updatedRoles"></param>
    public void Active(IDateTime dateTime, ISerializer serializer, string updatedBy, 
        IReadOnlyCollection<string> updatedRoles
    )
    {
        var roles = serializer.Serialize(updatedRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.Active;
        UpdatedBy = updatedBy;
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        AddEvent(
            new TicketActived {
                Id = Id,
                UpdatedBy = updatedBy,
                UpdatedRole = roles,
                UpdatedAt_EnglishDate = nowDateTime,
                UpdatedAt_PersianDate = nowPersianDate
            }
        );
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="serializer"></param>
    /// <param name="updatedBy"></param>
    /// <param name="updatedRoles"></param>
    public void InActive(IDateTime dateTime, ISerializer serializer, string updatedBy, 
        IReadOnlyCollection<string> updatedRoles
    )
    {
        var roles = serializer.Serialize(updatedRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.InActive;
        UpdatedBy = updatedBy;
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        AddEvent(
            new TicketInActived {
                Id = Id,
                UpdatedBy = updatedBy,
                UpdatedRole = roles,
                UpdatedAt_EnglishDate = nowDateTime,
                UpdatedAt_PersianDate = nowPersianDate
            }
        );
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="serializer"></param>
    /// <param name="updatedBy"></param>
    /// <param name="updatedRoles"></param>
    public void Delete(IDateTime dateTime, ISerializer serializer, string updatedBy, 
        IReadOnlyCollection<string> updatedRoles
    )
    {
        var roles = serializer.Serialize(updatedRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsDeleted = IsDeleted.Delete;
        UpdatedBy = updatedBy;
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        AddEvent(
            new TicketDeleted {
                Id = Id,
                UpdatedBy = updatedBy,
                UpdatedRole = roles,
                UpdatedAt_EnglishDate = nowDateTime,
                UpdatedAt_PersianDate = nowPersianDate
            }
        );
    }
}