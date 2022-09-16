using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class testiranje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevoznoSredstvo_Putovanje_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropIndex(
                name: "IX_PrevoznoSredstvo_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo");
        }
    }
}
