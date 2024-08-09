using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Domic.Domain.Ticket.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domic.Persistence.Configs.C;

public class TicketConfig : BaseEntityConfig<Ticket, string>
{
    public override void Configure(EntityTypeBuilder<Ticket> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Tickets");
        
        //configs
        
        builder.OwnsOne(ticket => ticket.Title)
               .Property(title => title.Value)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnName("Title");
        
        builder.OwnsOne(ticket => ticket.Description)
               .Property(title => title.Value)
               .IsRequired()
               .HasMaxLength(2000)
               .HasColumnName("Description");

        builder.Property(ticket => ticket.Priority).HasConversion(new EnumToNumberConverter<Priority, byte>()).IsRequired();
        builder.Property(ticket => ticket.Status).HasConversion(new EnumToNumberConverter<Status, byte>()).IsRequired();
        
        //relations
        
        builder.HasMany(ticket => ticket.Comments)
               .WithOne(comment => comment.Ticket)
               .HasForeignKey(comment => comment.TicketId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}