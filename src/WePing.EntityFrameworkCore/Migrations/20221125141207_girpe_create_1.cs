using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class girpe_create_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "GirpeClub");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GirpeClub");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "GirpeClub");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "GirpeClub");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GirpeClub");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "GirpeClub");

            migrationBuilder.CreateTable(
                name: "GirpeJoueur",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Licence = table.Column<string>(type: "text", nullable: true),
                    Nom = table.Column<string>(type: "text", nullable: true),
                    Prenom = table.Column<string>(type: "text", nullable: true),
                    Classement = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirpeJoueur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GirpeJoueur_GirpeClub_ClubId",
                        column: x => x.ClubId,
                        principalTable: "GirpeClub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GirpeJoueur_ClubId",
                table: "GirpeJoueur",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirpeJoueur");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "GirpeClub",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GirpeClub",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "GirpeClub",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "GirpeClub",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GirpeClub",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "GirpeClub",
                type: "uuid",
                nullable: true);
        }
    }
}
