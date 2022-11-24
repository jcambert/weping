using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class Initial_Girpe_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GirpeClub",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identifiant = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Validation = table.Column<string>(type: "text", nullable: true),
                    NomSalle = table.Column<string>(type: "text", nullable: true),
                    AdresseSalle1 = table.Column<string>(type: "text", nullable: true),
                    AdresseSalle2 = table.Column<string>(type: "text", nullable: true),
                    AdresseSalle3 = table.Column<string>(type: "text", nullable: true),
                    CodePostalSalle = table.Column<string>(type: "text", nullable: true),
                    VilleSalle = table.Column<string>(type: "text", nullable: true),
                    Web = table.Column<string>(type: "text", nullable: true),
                    NomCorrespondant = table.Column<string>(type: "text", nullable: true),
                    PrenomCorrespondant = table.Column<string>(type: "text", nullable: true),
                    MailCorrespondant = table.Column<string>(type: "text", nullable: true),
                    TelephoneCorrespondant = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
