using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class Initial_Girpe_Create_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "GirpeClub");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GirpeClub",
                table: "GirpeClub",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GirpeClub",
                table: "GirpeClub");

            migrationBuilder.RenameTable(
                name: "GirpeClub",
                newName: "Club");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "Id");
        }
    }
}
