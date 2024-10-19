using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class addproductsindb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "User",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iban = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ccy = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Subtype = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FriendlyName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Ccy", "CustomerId", "Iban", "Subtype", "Type" },
                values: new object[,]
                {
                    { 1, "GEL", 0, "TBCGE89081239210321", "მიმდინარე", "მიმდინარე" },
                    { 2, "USD", 0, "TBCGE89081239210321", "მიმდინარე", "მიმდინარე" },
                    { 3, "EUR", 0, "TBCGE89081239210321", "მიმდინარე", "მიმდინარე" }
                });

            migrationBuilder.UpdateData(
                schema: "User",
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerId",
                value: 0);

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "CustomerId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 0, "Visa Platinum", "Visa" },
                    { 2, 0, "MC World Elite", "MasterCard" }
                });

            migrationBuilder.InsertData(
                table: "Deposits",
                columns: new[] { "Id", "CustomerId", "FriendlyName", "Name" },
                values: new object[,]
                {
                    { 1, 0, "ახალი მობილური", "ჩემი მიზანი" },
                    { 2, 0, "ჩემი დანაზოგი", "ვადიანი ანაბარი" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "User",
                table: "AppUsers");
        }
    }
}
