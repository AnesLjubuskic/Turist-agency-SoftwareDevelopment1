using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class twoStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isTwoStep",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "twoStep",
                table: "KorisnickiNalog",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isTwoStep",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "twoStep",
                table: "KorisnickiNalog");
        }
    }
}
