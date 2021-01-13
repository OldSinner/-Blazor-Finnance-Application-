using Microsoft.EntityFrameworkCore.Migrations;

namespace FinnanceApp.Server.Migrations
{
    public partial class activation_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "activationkey",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "activationkey",
                table: "Users");
        }
    }
}
