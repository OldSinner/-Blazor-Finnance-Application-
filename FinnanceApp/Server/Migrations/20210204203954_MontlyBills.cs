using Microsoft.EntityFrameworkCore.Migrations;

namespace FinnanceApp.Server.Migrations
{
    public partial class MontlyBills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MontlyBills",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dayOfMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    value = table.Column<double>(type: "REAL", nullable: false),
                    shopid = table.Column<int>(type: "INTEGER", nullable: true),
                    personid = table.Column<int>(type: "INTEGER", nullable: true),
                    userid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MontlyBills", x => x.id);
                    table.ForeignKey(
                        name: "FK_MontlyBills_Person_personid",
                        column: x => x.personid,
                        principalTable: "Person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MontlyBills_Shops_shopid",
                        column: x => x.shopid,
                        principalTable: "Shops",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MontlyBills_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MontlyBills_personid",
                table: "MontlyBills",
                column: "personid");

            migrationBuilder.CreateIndex(
                name: "IX_MontlyBills_shopid",
                table: "MontlyBills",
                column: "shopid");

            migrationBuilder.CreateIndex(
                name: "IX_MontlyBills_userid",
                table: "MontlyBills",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MontlyBills");
        }
    }
}
