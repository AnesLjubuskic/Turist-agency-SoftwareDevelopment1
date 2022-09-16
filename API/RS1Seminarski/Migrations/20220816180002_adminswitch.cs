using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class adminswitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vodic");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "KorisnickiNalog",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "KorisnickiNalog");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vodic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
