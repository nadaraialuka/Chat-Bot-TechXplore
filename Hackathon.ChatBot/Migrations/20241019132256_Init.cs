using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "User");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "User",
                table: "AppUsers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UserName" },
                values: new object[] { 1, "Tbilisi, Zgvis Ubani", "Lukanadaraia2001@gmail.com", "Luka", "Nadaraia", "XVD/vyDIwqyZNkUnBVQ52gaoNKTME0QFJXWKijC92GM=", "599937315", "nadaraialuka" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers",
                schema: "User");
        }
    }
}
