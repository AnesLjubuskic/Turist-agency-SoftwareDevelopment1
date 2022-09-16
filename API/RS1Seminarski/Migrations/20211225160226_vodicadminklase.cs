using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class vodicadminklase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
