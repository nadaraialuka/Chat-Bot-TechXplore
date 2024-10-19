using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon.ChatBot.Migrations
{
    /// <inheritdoc />
    public partial class AddPaswordHashAndUserNameV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_APpUsers",
                schema: "User",
                table: "APpUsers");

            migrationBuilder.RenameTable(
                name: "APpUsers",
                schema: "User",
                newName: "AppUsers",
                newSchema: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                schema: "User",
                table: "AppUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                schema: "User",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                schema: "User",
                newName: "APpUsers",
                newSchema: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_APpUsers",
                schema: "User",
                table: "APpUsers",
                column: "Id");
        }
    }
}
