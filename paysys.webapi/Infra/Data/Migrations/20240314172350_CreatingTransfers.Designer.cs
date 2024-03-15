﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using paysys.webapi.Infra.Data;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240314172350_CreatingTransfers")]
    partial class CreatingTransfers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("paysys.webapi.Domain.Entities.AdministratorUser", b =>
                {
                    b.Property<Guid>("AdministratorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("administrator_id");

                    b.Property<string>("AdministratorCPF")
                        .IsRequired()
                        .HasColumnType("CHAR(11)")
                        .HasColumnName("administrator_cpf");

                    b.Property<string>("AdministratorName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("administrator_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("AdministratorId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("administrator_users");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.CommonUser", b =>
                {
                    b.Property<Guid>("CommonUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("common_user_id");

                    b.Property<string>("CommonUserCPF")
                        .IsRequired()
                        .HasColumnType("CHAR(11)")
                        .HasColumnName("common_user_cpf");

                    b.Property<string>("CommonUserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("common_user_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("CommonUserId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("common_users");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.Shopkeeper", b =>
                {
                    b.Property<Guid>("ShopkeeperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("shopkeeper_id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("MONEY")
                        .HasColumnName("balance");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<string>("FancyName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fancy_name");

                    b.Property<string>("ShopkeeperCNJP")
                        .IsRequired()
                        .HasColumnType("CHAR(14)")
                        .HasColumnName("shopkeeper_cnpj");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("ShopkeeperId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("shopkeepers");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.Transfer", b =>
                {
                    b.Property<Guid>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("tranfer_id");

                    b.Property<Guid>("ReceiverUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("receiver_user_id");

                    b.Property<Guid>("SenderUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("sender_user_id");

                    b.Property<decimal>("TransferAmount")
                        .HasColumnType("MONEY")
                        .HasColumnName("transfer_amount");

                    b.Property<DateTime>("TransferDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("transfer_datetime");

                    b.Property<string>("TransferDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("transfer_description");

                    b.HasKey("TransferId");

                    b.HasIndex("ReceiverUserId");

                    b.HasIndex("SenderUserId");

                    b.ToTable("transfer");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasColumnType("BYTEA")
                        .HasColumnName("hash");

                    b.Property<DateTime>("LastUpdatedOn")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_updated_on");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("CHAR(11)")
                        .HasColumnName("phone_number");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("BYTEA")
                        .HasColumnName("salt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_type_id");

                    b.HasKey("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.UserType", b =>
                {
                    b.Property<Guid>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_type_id");

                    b.Property<string>("TypeName")
                        .HasColumnType("text")
                        .HasColumnName("user_type_name");

                    b.HasKey("UserTypeId");

                    b.ToTable("user_types");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.AdministratorUser", b =>
                {
                    b.HasOne("paysys.webapi.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.CommonUser", b =>
                {
                    b.HasOne("paysys.webapi.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.Shopkeeper", b =>
                {
                    b.HasOne("paysys.webapi.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.Transfer", b =>
                {
                    b.HasOne("paysys.webapi.Domain.Entities.User", "ReceiverUser")
                        .WithMany()
                        .HasForeignKey("ReceiverUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("paysys.webapi.Domain.Entities.User", "SenderUser")
                        .WithMany()
                        .HasForeignKey("SenderUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("paysys.webapi.Domain.ValueObjects.TransferCategory", "TransferCategory", b1 =>
                        {
                            b1.Property<Guid>("TransferId")
                                .HasColumnType("uuid");

                            b1.Property<string>("TransferCategoryName")
                                .HasColumnType("text")
                                .HasColumnName("transfer_category_name");

                            b1.HasKey("TransferId");

                            b1.ToTable("transfer");

                            b1.WithOwner()
                                .HasForeignKey("TransferId");
                        });

                    b.OwnsOne("paysys.webapi.Domain.ValueObjects.TransferStatus", "TransferStatus", b1 =>
                        {
                            b1.Property<Guid>("TransferId")
                                .HasColumnType("uuid");

                            b1.Property<string>("TransferStatusName")
                                .HasColumnType("text")
                                .HasColumnName("transfer_status_name");

                            b1.HasKey("TransferId");

                            b1.ToTable("transfer");

                            b1.WithOwner()
                                .HasForeignKey("TransferId");
                        });

                    b.Navigation("ReceiverUser");

                    b.Navigation("SenderUser");

                    b.Navigation("TransferCategory")
                        .IsRequired();

                    b.Navigation("TransferStatus")
                        .IsRequired();
                });

            modelBuilder.Entity("paysys.webapi.Domain.Entities.User", b =>
                {
                    b.HasOne("paysys.webapi.Domain.Entities.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}
