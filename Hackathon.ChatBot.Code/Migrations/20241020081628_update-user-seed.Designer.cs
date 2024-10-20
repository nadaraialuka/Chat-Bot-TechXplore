﻿// <auto-generated />
using System;
using Hackathon.ChatBot.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241020081628_update-user-seed")]
    partial class updateuserseed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hackathon.ChatBot.Code.Entitites.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ccy")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("OpenDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Subtype")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ccy = "GEL",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210321",
                            OpenDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtype = "მიმდინარე",
                            Type = "მიმდინარე"
                        },
                        new
                        {
                            Id = 2,
                            Ccy = "USD",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210321",
                            OpenDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtype = "მიმდინარე",
                            Type = "მიმდინარე"
                        },
                        new
                        {
                            Id = 3,
                            Ccy = "EUR",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210321",
                            OpenDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subtype = "მიმდინარე",
                            Type = "მიმდინარე"
                        });
                });

            modelBuilder.Entity("Hackathon.ChatBot.Code.Entitites.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ccys")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ccys = "[\"GEL\",\"USD\",\"EUR\"]",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210333",
                            Name = "Visa Platinum",
                            Type = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            Ccys = "[\"GEL\",\"USD\",\"EUR\"]",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210334",
                            Name = "MC World Elite",
                            Type = "MasterCard"
                        });
                });

            modelBuilder.Entity("Hackathon.ChatBot.Code.Entitites.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ccy")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("OpenDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("Deposits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ccy = "GEL",
                            CustomerId = 1,
                            FriendlyName = "ახალი მობილური",
                            Iban = "TBCGE89081239210111",
                            Name = "ჩემი მიზანი",
                            OpenDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Ccy = "USD",
                            CustomerId = 1,
                            FriendlyName = "ჩემი დანაზოგი",
                            Iban = "TBCGE89081239210222",
                            Name = "ვადიანი ანაბარი",
                            OpenDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Hackathon.ChatBot.Entitites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", "User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Tbilisi, Zgvis Ubani",
                            Email = "Lukanadaraia2001@gmail.com",
                            FirstName = "ლუკა",
                            LastName = "ნადარაია",
                            PasswordHash = "XVD/vyDIwqyZNkUnBVQ52gaoNKTME0QFJXWKijC92GM=",
                            PhoneNumber = "599937315",
                            UserName = "nadaraialuka"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Tbilisi, Tsereteli",
                            Email = "mzardiashvili@gmail.com",
                            FirstName = "მარიამ",
                            LastName = "ზარდიაშვილი",
                            PasswordHash = "k9ziLsJcDKTWxBui/qdDecxIugZ+cQ/UQB/wT3OGJ/Q=",
                            PhoneNumber = "599937316",
                            UserName = "mzardiashvili"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
