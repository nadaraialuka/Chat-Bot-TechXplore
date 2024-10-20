using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class updateuserseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "ლუკა", "ნადარაია" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "მარიამ", "ზარდიაშვილი" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Luka", "Nadaraia" });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mariam", "Zardiashvili" });
        }
    }
}
