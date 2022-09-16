using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class smjestajgradovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "Smjestaj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "Gradovi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Smjestaj_PutovanjeId",
                table: "Smjestaj",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_PutovanjeId",
                table: "Gradovi",
                column: "PutovanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gradovi_Putovanje_PutovanjeId",
                table: "Gradovi",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gradovi_Putovanje_PutovanjeId",
                table: "Gradovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Smjestaj_Putovanje_PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropIndex(
                name: "IX_Smjestaj_PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropIndex(
                name: "IX_Gradovi_PutovanjeId",
                table: "Gradovi");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "Smjestaj");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "Gradovi");
        }
    }
}
