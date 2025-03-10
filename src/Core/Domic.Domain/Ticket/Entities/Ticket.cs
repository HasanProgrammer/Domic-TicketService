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
    public string CategoryId { get; private set; }
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
    /// <param name="identityUser"></param>
    /// <param name="serializer"></param>
    /// <param name="categoryId"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="priority"></param>
    public Ticket(IGlobalUniqueIdGenerator globalUniqueIdGeneratorstring, IDateTime dateTime, IIdentityUser identityUser,
        ISerializer serializer, string categoryId, string title, string description, Priority priority
    )
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGeneratorstring.GetRandom(6);
        CategoryId = categoryId;
        Title = new Title(title);
        Description = new Description(description);
        Status = Status.Open;
        Priority = priority;
        
        //audit
        CreatedBy = identityUser.GetIdentity();
        CreatedRole = roles;
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDate);
        
        AddEvent(
            new TicketCreated {
                Id = Id,
                Title = title,
                CategoryId = categoryId,
                Description = description,
                Status = (int)Status,
                Priority = (int)Priority,
                CreatedBy = CreatedBy,
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
    /// <param name="identityUser"></param>
    /// <param name="categoryId"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="priority"></param>
    /// <param name="status"></param>
    public void Change(IDateTime dateTime, ISerializer serializer, IIdentityUser identityUser,
        string categoryId, string title, string description, Priority priority, Status status
    )
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        CategoryId = categoryId;
        Title = new Title(title);
        Description = new Description(description);
        Priority = priority;
        Status = status;
        
        //audit
        UpdatedBy = identityUser.GetIdentity();
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);
        
        AddEvent(
            new TicketUpdated {
                Id = Id,
                CategoryId = categoryId,
                Title = title,
                Description = description,
                Priority = (int)priority,
                Status = (int)status,
                UpdatedBy = UpdatedBy,
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
    /// <param name="identityUser"></param>
    /// <param name="withEventRaising"></param>
    public void Active(IDateTime dateTime, ISerializer serializer, IIdentityUser identityUser, bool withEventRaising = true)
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.Active;
        
        //audit
        UpdatedBy = identityUser.GetIdentity();
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketActived {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
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
    /// <param name="updatedBy"></param>
    /// <param name="updatedRole"></param>
    /// <param name="withEventRaising"></param>
    public void Active(IDateTime dateTime, string updatedBy, string updatedRole, bool withEventRaising = true)
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.Active;
        
        //audit
        UpdatedBy = updatedBy;
        UpdatedRole = updatedRole;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketActived {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
                    UpdatedRole = UpdatedRole,
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
    /// <param name="identityUser"></param>
    /// <param name="withEventRaising"></param>
    public void InActive(IDateTime dateTime, ISerializer serializer, IIdentityUser identityUser, bool withEventRaising = true)
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.InActive;
        
        //audit
        UpdatedBy = identityUser.GetIdentity();
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketInActived {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
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
    /// <param name="updateBy"></param>
    /// <param name="updateRole"></param>
    /// <param name="withEventRaising"></param>
    public void InActive(IDateTime dateTime, string updateBy, string updateRole, bool withEventRaising = true)
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsActive = IsActive.InActive;
        
        //audit
        UpdatedBy = updateBy;
        UpdatedRole = updateRole;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketInActived {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
                    UpdatedRole = updateRole,
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
    /// <param name="identityUser"></param>
    /// <param name="withEventRaising"></param>
    public void Delete(IDateTime dateTime, ISerializer serializer, IIdentityUser identityUser, bool withEventRaising = true)
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsDeleted = IsDeleted.Delete;
        UpdatedBy = identityUser.GetIdentity();
        UpdatedRole = roles;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketDeleted {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
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
    /// <param name="updateBy"></param>
    /// <param name="updatedRole"></param>
    /// <param name="withEventRaising"></param>
    public void Delete(IDateTime dateTime, string updateBy, string updatedRole, bool withEventRaising = true)
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);
        
        IsDeleted = IsDeleted.Delete;
        
        //audit
        UpdatedBy = updateBy;
        UpdatedRole = updatedRole;
        UpdatedAt = new UpdatedAt(nowDateTime, nowPersianDate);

        if(withEventRaising)
            AddEvent(
                new TicketDeleted {
                    Id = Id,
                    UpdatedBy = UpdatedBy,
                    UpdatedRole = UpdatedRole,
                    UpdatedAt_EnglishDate = nowDateTime,
                    UpdatedAt_PersianDate = nowPersianDate
                }
            );
    }
}