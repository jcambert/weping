using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class girpe_create_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GirpeJoueur_GirpeClub_ClubId",
                table: "GirpeJoueur");

            migrationBuilder.DropIndex(
                name: "IX_GirpeJoueur_ClubId",
                table: "GirpeJoueur");

            migrationBuilder.AddColumn<string>(
                name: "AncienClassementGlobal",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnciensPoints",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassementGlobal",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "GirpeJoueur",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "GirpeJoueur",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "GirpeJoueur",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "GirpeJoueur",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "GirpeJoueur",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomClub",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroClub",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsDebutSaison",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsMensuels",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsOfficiels",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropositionClassement",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RangDepartmental",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RangRegional",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GirpePartiesSpid",
                columns: table => new
                {
                    JoueurId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    NomPrenomAdversaire = table.Column<string>(type: "text", nullable: false),
                    ClassementAdversaire = table.Column<string>(type: "text", nullable: true),
                    Epreuve = table.Column<string>(type: "text", nullable: true),
                    VictoireOuDefaite = table.Column<string>(type: "text", nullable: true),
                    Forfait = table.Column<string>(type: "text", nullable: true),
                    PointsAcquisPerdus = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirpePartiesSpid", x => new { x.JoueurId, x.Date, x.NomPrenomAdversaire });
                    table.ForeignKey(
                        name: "FK_GirpePartiesSpid_GirpeJoueur_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "GirpeJoueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointCalculatorBareme",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ecart = table.Column<int>(type: "integer", nullable: false),
                    vn = table.Column<double>(type: "double precision", nullable: false),
                    va = table.Column<double>(type: "double precision", nullable: false),
                    dn = table.Column<double>(type: "double precision", nullable: false),
                    da = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointCalculatorBareme", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GirpePartiesSpid");

            migrationBuilder.DropTable(
                name: "PointCalculatorBareme");

            migrationBuilder.DropColumn(
                name: "AncienClassementGlobal",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "AnciensPoints",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "ClassementGlobal",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "NomClub",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "NumeroClub",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointsDebutSaison",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointsMensuels",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointsOfficiels",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PropositionClassement",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "RangDepartmental",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "RangRegional",
                table: "GirpeJoueur");

            migrationBuilder.CreateIndex(
                name: "IX_GirpeJoueur_ClubId",
                table: "GirpeJoueur",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_GirpeJoueur_GirpeClub_ClubId",
                table: "GirpeJoueur",
                column: "ClubId",
                principalTable: "GirpeClub",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
