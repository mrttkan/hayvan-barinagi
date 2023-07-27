using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HayvanBarinagi.Migrations
{
    /// <inheritdoc />
    public partial class SahiplendirmeBasvurusu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SahiplendirmeBasvurusus");

            migrationBuilder.CreateTable(
                name: "SahiplendirmeBasvurulari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanId = table.Column<int>(type: "int", nullable: false),
                    BasvuranKisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SahiplendirmeBasvurulari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SahiplendirmeBasvurulari_Hayvanlar_HayvanId",
                        column: x => x.HayvanId,
                        principalTable: "Hayvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SahiplendirmeBasvurulari_HayvanId",
                table: "SahiplendirmeBasvurulari",
                column: "HayvanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SahiplendirmeBasvurulari");

            migrationBuilder.CreateTable(
                name: "SahiplendirmeBasvurusus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvanId = table.Column<int>(type: "int", nullable: false),
                    BasvuranKisi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SahiplendirmeBasvurusus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SahiplendirmeBasvurusus_Hayvanlar_HayvanId",
                        column: x => x.HayvanId,
                        principalTable: "Hayvanlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SahiplendirmeBasvurusus_HayvanId",
                table: "SahiplendirmeBasvurusus",
                column: "HayvanId");
        }
    }
}
