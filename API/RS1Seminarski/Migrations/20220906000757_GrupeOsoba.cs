using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class GrupeOsoba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupePutovanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutovajeId = table.Column<int>(type: "int", nullable: false),
                    VodicId = table.Column<int>(type: "int", nullable: false),
                    BrojPutnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupePutovanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupePutovanja_Putovanje_PutovajeId",
                        column: x => x.PutovajeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupePutovanja_Vodic_VodicId",
                        column: x => x.VodicId,
                        principalTable: "Vodic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osobe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osobe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osobe_GrupePutovanja_GrupeId",
                        column: x => x.GrupeId,
                        principalTable: "GrupePutovanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupePutovanja_PutovajeId",
                table: "GrupePutovanja",
                column: "PutovajeId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupePutovanja_VodicId",
                table: "GrupePutovanja",
                column: "VodicId");

            migrationBuilder.CreateIndex(
                name: "IX_Osobe_GrupeId",
                table: "Osobe",
                column: "GrupeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Osobe");

            migrationBuilder.DropTable(
                name: "GrupePutovanja");
        }
    }
}
