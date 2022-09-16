using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class putsmjeprev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevoznoSredstvo_Putovanje_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropForeignKey(
                name: "FK_Smjestaj_Putovanje_PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropIndex(
                name: "IX_Smjestaj_PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropIndex(
                name: "IX_PrevoznoSredstvo_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "Smjestaj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Smjestaj_PutovanjeId",
                table: "Smjestaj",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PrevoznoSredstvo_PutovanjeId",
                table: "PrevoznoSredstvo",
                column: "PutovanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevoznoSredstvo_Putovanje_PutovanjeId",
                table: "PrevoznoSredstvo",
                column: "PutovanjeId",
                principalTable: "Putovanje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Smjestaj_Putovanje_PutovanjeId",
                table: "Smjestaj",
                column: "PutovanjeId",
                principalTable: "Putovanje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
