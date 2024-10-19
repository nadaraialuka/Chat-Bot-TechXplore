using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class updateproductsindb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "User",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "User",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                column: "CustomerId",
                value: 0);
        }
    }
}
