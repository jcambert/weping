using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WePing.Migrations
{
    public partial class Initial_Girpe_Create_2 : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
