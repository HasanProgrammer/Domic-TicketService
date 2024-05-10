#pragma warning disable CS0649

using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.Enumerations;
using Domic.Core.Domain.ValueObjects;
using Domic.Domain.Service.ValueObjects;

namespace Domic.Domain.Service.Entities;

public class Ticket : Entity<string>
{
    //Value Objects
    
    public Title Title { get; private set; }

    /*---------------------------------------------------------------*/
    
    //Relations

    /*---------------------------------------------------------------*/

    //EF Core
    private Ticket() {}

    public Ticket(IGlobalUniqueIdGenerator globalUniqueIdGeneratorstring, IDateTime dateTime, 
        string title, string createdBy, string createdRole
    )
    {
        var nowDateTime = DateTime.Now;
        var nowPersianDate = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGeneratorstring.GetRandom(6);
        Title = new Title(title);
        CreatedBy = createdBy;
        CreatedRole = createdRole;
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDate);
    }

    /*---------------------------------------------------------------*/
    
    //Behaviors

    /// <summary>
    /// 
    /// </summary>
    public void Active()
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