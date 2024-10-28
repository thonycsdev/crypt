﻿// <auto-generated />
using Crypt.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Crypt.Repository.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241028192043_credit-card-and-document")]
    partial class creditcardanddocument
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Crypt.Domain.CreditCard", b =>
                {
                    b.Property<string>("CreditCardNumberHash")
                        .HasColumnType("text");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CreditCardNumberHash");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Crypt.Domain.Document", b =>
                {
                    b.Property<string>("UserDocumentHash")
                        .HasColumnType("text");

                    b.Property<string>("UserDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserDocumentHash");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Crypt.Domain.Wallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CreditCardNumberHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocumentUserDocumentHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardNumberHash");

                    b.HasIndex("DocumentUserDocumentHash");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Crypt.Domain.Wallet", b =>
                {
                    b.HasOne("Crypt.Domain.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardNumberHash")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crypt.Domain.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentUserDocumentHash")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditCard");

                    b.Navigation("Document");
                });
#pragma warning restore 612, 618
        }
    }
}