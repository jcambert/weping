using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class girpe_create_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AncienPointsMensuel",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Arbitre",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategorieAge",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificatMedical",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateDeValidationDuCertificatMedical",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Echelon",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JugeArbitre",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenceId",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mutation",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationnalite",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointClassement",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsInitials",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PointsMensuel",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexe",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tech",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "GirpeJoueur",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AncienPointsMensuel",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Arbitre",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "CategorieAge",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "CertificatMedical",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "DateDeValidationDuCertificatMedical",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Echelon",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "JugeArbitre",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "LicenceId",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Mutation",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Nationnalite",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointClassement",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointsInitials",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "PointsMensuel",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Sexe",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Tech",
                table: "GirpeJoueur");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "GirpeJoueur");
        }
    }
}
