using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class AddPaswordHashAndUserNameV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "User",
                table: "AppUsers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { new Guid("5cbe2b6a-4b86-4875-bc02-90464c23811f"), "Tbilisi, Zgvis Ubani", "Lukanadaraia2001@gmail.com", "Luka", "Nadaraia", "XVD/vyDIwqyZNkUnBVQ52gaoNKTME0QFJXWKijC92GM=", "599937315", "nadaraialuka" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("5cbe2b6a-4b86-4875-bc02-90464c23811f"));
        }
    }
}
