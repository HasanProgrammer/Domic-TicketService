#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.Domain.ValueObjects;
using Domic.Domain.Service.Events;
using Domic.Domain.Service.ValueObjects;
using Domic.Domain.Ticket.Enumerations;

namespace Domic.Domain.Service.Entities;

public class Ticket : Entity<string>
{
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
    /// <param name="title"></param>
    /// <param name="description"></param>
    /// <param name="priority"></param>
    /// <param name="createdBy"></param>
    /// <param name="createdRoles"></param>
    public Ticket(IGlobalUniqueIdGenerator globalUniqueIdGeneratorstring, IDateTime dateTime, 
        ISerializer serializer, string title, string description, Priority priority, string createdBy, 
        IReadOnlyCollection<string> createdRoles
    )
    {
        var roles = serializer.Serialize(createdRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGeneratorstring.GetRandom(6);
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
    public void Active(IDateTime dateTime)
    {
        IsActive = IsActive.Active;
        
        /*AddEvent(
            new TemplateActived {
                Id       = Id ,
                IsActive = IsActive == IsActive.Active
            }
        );*/
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void InActive()
    {
        IsActive = IsActive.InActive;
        
        /*AddEvent(
            new TemplateInActived {
                Id       = Id ,
                IsActive = IsActive == IsActive.Active
            }
        );*/
    }
}