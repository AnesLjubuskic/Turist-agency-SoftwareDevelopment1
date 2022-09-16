using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class putovanjesmjestaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutovanjeDrzava");

            migrationBuilder.CreateTable(
                name: "PutovanjePrevoznoSredstvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutovanjeId = table.Column<int>(type: "int", nullable: false),
                    PrevoznoSredstvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutovanjePrevoznoSredstvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PutovanjePrevoznoSredstvo_PrevoznoSredstvo_PrevoznoSredstvoId",
                        column: x => x.PrevoznoSredstvoId,
                        principalTable: "PrevoznoSredstvo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutovanjePrevoznoSredstvo_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PutovanjeSmjestaj",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutovanjeId = table.Column<int>(type: "int", nullable: false),
                    SmjestajId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutovanjeSmjestaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PutovanjeSmjestaj_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutovanjeSmjestaj_Smjestaj_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjePrevoznoSredstvo_PrevoznoSredstvoId",
                table: "PutovanjePrevoznoSredstvo",
                column: "PrevoznoSredstvoId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjePrevoznoSredstvo_PutovanjeId",
                table: "PutovanjePrevoznoSredstvo",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeSmjestaj_PutovanjeId",
                table: "PutovanjeSmjestaj",
                column: "PutovanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeSmjestaj_SmjestajId",
                table: "PutovanjeSmjestaj",
                column: "SmjestajId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutovanjePrevoznoSredstvo");

            migrationBuilder.DropTable(
                name: "PutovanjeSmjestaj");

            migrationBuilder.CreateTable(
                name: "PutovanjeDrzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrzavaId = table.Column<int>(type: "int", nullable: false),
                    PutovanjeId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_PutovanjeDrzava_DrzavaId",
                table: "PutovanjeDrzava",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeDrzava_PutovanjeId",
                table: "PutovanjeDrzava",
                column: "PutovanjeId");
        }
    }
}
