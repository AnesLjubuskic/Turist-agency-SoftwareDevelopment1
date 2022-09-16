using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1Seminarski.Migrations
{
    public partial class putovanjegradovi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PutovanjeGradovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PutovanjeId = table.Column<int>(type: "int", nullable: false),
                    GradId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutovanjeGradovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PutovanjeGradovi_Gradovi_GradId",
                        column: x => x.GradId,
                        principalTable: "Gradovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutovanjeGradovi_Putovanje_PutovanjeId",
                        column: x => x.PutovanjeId,
                        principalTable: "Putovanje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeGradovi_GradId",
                table: "PutovanjeGradovi",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_PutovanjeGradovi_PutovanjeId",
                table: "PutovanjeGradovi",
                column: "PutovanjeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutovanjeGradovi");
        }
    }
}
