using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class Putovanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Putovanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipPutovanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojPutnika = table.Column<int>(type: "int", nullable: false),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trajanje = table.Column<int>(type: "int", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Putovanje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PutovanjeDrzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutovanjeId = table.Column<int>(type: "int", nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutovanjeDrzava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PutovanjeDrzava_Drzave_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutovanjeDrzava_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrevoznoSredstvo_PutovanjeId",
                table: "PrevoznoSredstvo",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeDrzava_DrzavaId",
                table: "PutovanjeDrzava",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeDrzava_PutovanjeId",
                table: "PutovanjeDrzava",
                column: "PutovanjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrevoznoSredstvo_Putovanje_PutovanjeId",
                table: "PrevoznoSredstvo",
                column: "PutovanjeId",
                principalTable: "Putovanje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrevoznoSredstvo_Putovanje_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropTable(
                name: "PutovanjeDrzava");

            migrationBuilder.DropTable(
                name: "Putovanje");

            migrationBuilder.DropIndex(
                name: "IX_PrevoznoSredstvo_PutovanjeId",
                table: "PrevoznoSredstvo");

            migrationBuilder.DropColumn(
                name: "PutovanjeId",
                table: "PrevoznoSredstvo");
        }
    }
}
