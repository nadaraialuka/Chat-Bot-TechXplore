using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class updateproductsindb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ccy",
                table: "Deposits",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Deposits",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                table: "Deposits",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Ccys",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Cards",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "OpenDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "OpenDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "OpenDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ccys", "Iban" },
                values: new object[] { "[\"GEL\",\"USD\",\"EUR\"]", "TBCGE89081239210333" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ccys", "Iban" },
                values: new object[] { "[\"GEL\",\"USD\",\"EUR\"]", "TBCGE89081239210334" });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ccy", "Iban" },
                values: new object[] { "GEL", "TBCGE89081239210111" });

            migrationBuilder.UpdateData(
                table: "Deposits",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Ccy", "Iban" },
                values: new object[] { "USD", "TBCGE89081239210222" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ccy",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Ccys",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "OpenDate",
                table: "Accounts");
        }
    }
}
