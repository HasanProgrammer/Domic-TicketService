﻿using Domic.Domain.Ticket.Enumerations;

namespace Domic.UseCase.TicketUseCase.DTOs;

public class TicketDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
}