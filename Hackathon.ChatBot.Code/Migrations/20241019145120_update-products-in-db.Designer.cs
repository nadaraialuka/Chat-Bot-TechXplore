﻿// <auto-generated />
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
    [Migration("20241019145120_update-products-in-db")]
    partial class updateproductsindb
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
                            Subtype = "მიმდინარე",
                            Type = "მიმდინარე"
                        },
                        new
                        {
                            Id = 2,
                            Ccy = "USD",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210321",
                            Subtype = "მიმდინარე",
                            Type = "მიმდინარე"
                        },
                        new
                        {
                            Id = 3,
                            Ccy = "EUR",
                            CustomerId = 1,
                            Iban = "TBCGE89081239210321",
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

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

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
                            CustomerId = 1,
                            Name = "Visa Platinum",
                            Type = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
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

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("FriendlyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Deposits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            FriendlyName = "ახალი მობილური",
                            Name = "ჩემი მიზანი"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            FriendlyName = "ჩემი დანაზოგი",
                            Name = "ვადიანი ანაბარი"
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
                            FirstName = "Luka",
                            LastName = "Nadaraia",
                            PasswordHash = "XVD/vyDIwqyZNkUnBVQ52gaoNKTME0QFJXWKijC92GM=",
                            PhoneNumber = "599937315",
                            UserName = "nadaraialuka"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
