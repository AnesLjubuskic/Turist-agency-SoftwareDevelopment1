using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class dodanetabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin_BrojTelefona",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_DatumRodjenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_DatumZaposlenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_Email",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Admin_Prezime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "DatumZaposlenja",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "KorisnickiNalog");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vodic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vodic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vodic_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Vodic");

            migrationBuilder.AddColumn<string>(
                name: "Admin_BrojTelefona",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Admin_DatumRodjenja",
                table: "KorisnickiNalog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Admin_DatumZaposlenja",
                table: "KorisnickiNalog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_Email",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_Ime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Admin_Prezime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "KorisnickiNalog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumZaposlenja",
                table: "KorisnickiNalog",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
