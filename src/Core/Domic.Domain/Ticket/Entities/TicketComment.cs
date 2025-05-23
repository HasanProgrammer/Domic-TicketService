﻿using Domic.Core.Domain.Contracts.Abstracts;
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
    /// <param name="serializer"></param>
    /// <param name="identityUser"></param>
    /// <param name="ticketId"></param>
    /// <param name="comment"></param>
    public TicketComment(IGlobalUniqueIdGenerator globalUniqueIdGenerator, IDateTime dateTime, ISerializer serializer,
        IIdentityUser identityUser, string ticketId, string comment
    )
    {
        var roles = serializer.Serialize(identityUser.GetRoles());
        var nowDateTime = DateTime.Now;
        var nowPersianDateTime = dateTime.ToPersianShortDate(nowDateTime);

        Id = globalUniqueIdGenerator.GetRandom(6);
        TicketId = ticketId;
        Comment = new Comment(comment);
        
        //audit
        CreatedAt = new CreatedAt(nowDateTime, nowPersianDateTime);
        CreatedBy = identityUser.GetIdentity();
        CreatedRole = roles;
        
        AddEvent(
            new TicketCommentCreated {
                Id = Id,
                Comment = comment,
                CreatedBy = CreatedBy,
                CreatedRole = roles,
                CreatedAt_EnglishDate = nowDateTime,
                CreatedAt_PersianDate = nowPersianDateTime
            }
        );
    }
    
    /*---------------------------------------------------------------*/
    
    //Behaviors
    
}