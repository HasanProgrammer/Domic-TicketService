using Domic.Core.Domain.Contracts.Abstracts;
using Domic.Core.Domain.Contracts.Interfaces;
using Domic.Core.Domain.ValueObjects;
using Domic.Domain.Ticket.Events;
using Domic.Domain.Ticket.ValueObjects;

namespace Domic.Domain.Ticket.Entities;

public class TicketComment : Entity<string>
{
    public string TicketId { get; private set; }
    
    //Value Objects
    
    public Comment Comment { get; private set; }
    
    /*---------------------------------------------------------------*/
    
    //Relations

    public Ticket Ticket { get; set; }
    
    /*---------------------------------------------------------------*/

    //EF Core
    public TicketComment(){}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="globalUniqueIdGenerator"></param>
    /// <param name="dateTime"></param>
    /// <param name="ticketId"></param>
    /// <param name="comment"></param>
    public TicketComment(IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, ISerializer serializer,
        string ticketId, string comment, string createdBy, IReadOnlyCollection<string> createdRoles
    )
    {
        var roles = serializer.Serialize(createdRoles);
        var nowDateTime = DateTime.Now;
        var nowPersianDateTime = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGenerator.GetRandom(6);
        TicketId = ticketId;
        Comment = new Comment(comment);
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDateTime);
        CreatedBy = createdBy;
        CreatedRole = roles;
        
        AddEvent(
            new TicketCommentCreated {
                Id = Id,
                Comment = comment,
                CreatedBy = createdBy,
                CreatedRole = roles,
                CreatedAt_EnglishDate = nowDateTime,
                CreatedAt_PersianDate = nowPersianDateTime
            }
        );
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors
    
}