using Domic.Core.Persistence.Configs;
using Domic.Domain.Ticket.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domic.Persistence.Configs.C;

public class TicketCommentConfig : BaseEntityConfig<TicketComment, string>
{
    public override void Configure(EntityTypeBuilder<TicketComment> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("TicketComments");
        
        //configs
        
     
        builder.OwnsOne(comment => comment.Comment)
               .Property(title => title.Value)
               .IsRequired()
               .HasMaxLength(2000)
               .HasColumnName("Comment");
        
        //relations
        
        builder.HasOne(comment => comment.Ticket)
               .WithMany(ticket => ticket.Comments)
               .HasForeignKey(comment => comment.TicketId)
               .OnDelete(DeleteBehavior.NoAction);
        
    }
}