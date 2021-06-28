using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Mebl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pocupcis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pocupcis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodavcis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavcis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Robitnikis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Staj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robitnikis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meblis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProdavecID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meblis", x => x.id);
                    table.ForeignKey(
                        name: "FK_Meblis_Prodavcis_ProdavecID",
                        column: x => x.ProdavecID,
                        principalTable: "Prodavcis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opsis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Virobnik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MebliID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opsis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opsis_Meblis_MebliID",
                        column: x => x.MebliID,
                        principalTable: "Meblis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamovlennyas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MebliID = table.Column<int>(type: "int", nullable: false),
                    PocupciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamovlennyas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zamovlennyas_Meblis_MebliID",
                        column: x => x.MebliID,
                        principalTable: "Meblis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zamovlennyas_Pocupcis_PocupciID",
                        column: x => x.PocupciID,
                        principalTable: "Pocupcis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZamovlenyaRobitniki",
                columns: table => new
                {
                    RobitnikisId = table.Column<int>(type: "int", nullable: false),
                    ZamovlennyasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamovlenyaRobitniki", x => new { x.RobitnikisId, x.ZamovlennyasId });
                    table.ForeignKey(
                        name: "FK_ZamovlenyaRobitniki_Robitnikis_RobitnikisId",
                        column: x => x.RobitnikisId,
                        principalTable: "Robitnikis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamovlenyaRobitniki_Zamovlennyas_ZamovlennyasId",
                        column: x => x.ZamovlennyasId,
                        principalTable: "Zamovlennyas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meblis_ProdavecID",
                table: "Meblis",
                column: "ProdavecID");

            migrationBuilder.CreateIndex(
                name: "IX_Opsis_MebliID",
                table: "Opsis",
                column: "MebliID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zamovlennyas_MebliID",
                table: "Zamovlennyas",
                column: "MebliID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamovlennyas_PocupciID",
                table: "Zamovlennyas",
                column: "PocupciID");

            migrationBuilder.CreateIndex(
                name: "IX_ZamovlenyaRobitniki_ZamovlennyasId",
                table: "ZamovlenyaRobitniki",
                column: "ZamovlennyasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opsis");

            migrationBuilder.DropTable(
                name: "ZamovlenyaRobitniki");

            migrationBuilder.DropTable(
                name: "Robitnikis");

            migrationBuilder.DropTable(
                name: "Zamovlennyas");

            migrationBuilder.DropTable(
                name: "Meblis");

            migrationBuilder.DropTable(
                name: "Pocupcis");

            migrationBuilder.DropTable(
                name: "Prodavcis");
        }
    }
}
