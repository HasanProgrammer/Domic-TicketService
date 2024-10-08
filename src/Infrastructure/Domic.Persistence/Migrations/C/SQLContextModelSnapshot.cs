﻿// <auto-generated />
using System;
using Domic.Persistence.Contexts.C;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domic.Persistence.Migrations.C
{
    [DbContext(typeof(SQLContext))]
    partial class SQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domic.Core.Domain.Entities.ConsumerEvent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CountOfRetry")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConsumerEvents", (string)null);
                });

            modelBuilder.Entity("Domic.Core.Domain.Entities.Event", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedAt_PersianDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Payload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Service")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Table")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt_EnglishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedAt_PersianDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Priority")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id", "IsDeleted");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketComment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsDeleted")
                        .HasColumnType("tinyint");

                    b.Property<string>("TicketId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("Id", "IsDeleted");

                    b.ToTable("TicketComments", (string)null);
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.Ticket", b =>
                {
                    b.OwnsOne("Domic.Core.Domain.ValueObjects.CreatedAt", "CreatedAt", b1 =>
                        {
                            b1.Property<string>("TicketId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime?>("EnglishDate")
                                .IsRequired()
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt_EnglishDate");

                            b1.Property<string>("PersianDate")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CreatedAt_PersianDate");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("Domic.Core.Domain.ValueObjects.UpdatedAt", "UpdatedAt", b1 =>
                        {
                            b1.Property<string>("TicketId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime?>("EnglishDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("UpdatedAt_EnglishDate");

                            b1.Property<string>("PersianDate")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UpdatedAt_PersianDate");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("Domic.Domain.Ticket.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<string>("TicketId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("nvarchar(2000)")
                                .HasColumnName("Description");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.OwnsOne("Domic.Domain.Ticket.ValueObjects.Title", "Title", b1 =>
                        {
                            b1.Property<string>("TicketId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Title");

                            b1.HasKey("TicketId");

                            b1.ToTable("Tickets");

                            b1.WithOwner()
                                .HasForeignKey("TicketId");
                        });

                    b.Navigation("CreatedAt")
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("Title");

                    b.Navigation("UpdatedAt");
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.TicketComment", b =>
                {
                    b.HasOne("Domic.Domain.Ticket.Entities.Ticket", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("Domic.Core.Domain.ValueObjects.CreatedAt", "CreatedAt", b1 =>
                        {
                            b1.Property<string>("TicketCommentId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime?>("EnglishDate")
                                .IsRequired()
                                .HasColumnType("datetime2")
                                .HasColumnName("CreatedAt_EnglishDate");

                            b1.Property<string>("PersianDate")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CreatedAt_PersianDate");

                            b1.HasKey("TicketCommentId");

                            b1.ToTable("TicketComments");

                            b1.WithOwner()
                                .HasForeignKey("TicketCommentId");
                        });

                    b.OwnsOne("Domic.Core.Domain.ValueObjects.UpdatedAt", "UpdatedAt", b1 =>
                        {
                            b1.Property<string>("TicketCommentId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<DateTime?>("EnglishDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("UpdatedAt_EnglishDate");

                            b1.Property<string>("PersianDate")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UpdatedAt_PersianDate");

                            b1.HasKey("TicketCommentId");

                            b1.ToTable("TicketComments");

                            b1.WithOwner()
                                .HasForeignKey("TicketCommentId");
                        });

                    b.OwnsOne("Domic.Domain.Ticket.ValueObjects.Comment", "Comment", b1 =>
                        {
                            b1.Property<string>("TicketCommentId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(2000)
                                .HasColumnType("nvarchar(2000)")
                                .HasColumnName("Comment");

                            b1.HasKey("TicketCommentId");

                            b1.ToTable("TicketComments");

                            b1.WithOwner()
                                .HasForeignKey("TicketCommentId");
                        });

                    b.Navigation("Comment");

                    b.Navigation("CreatedAt")
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("UpdatedAt");
                });

            modelBuilder.Entity("Domic.Domain.Ticket.Entities.Ticket", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
