using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class TicketConfig : BaseEntityConfig<Ticket, string>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);
        
        //configs
        
        builder.ToTable("Tickets");
    }
}