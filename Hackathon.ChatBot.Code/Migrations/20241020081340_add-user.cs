using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class adduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "User",
                table: "AppUsers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { 2, "Tbilisi, Tsereteli", "mzardiashvili@gmail.com", "Mariam", "Zardiashvili", "k9ziLsJcDKTWxBui/qdDecxIugZ+cQ/UQB/wT3OGJ/Q=", "599937316", "mzardiashvili" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
