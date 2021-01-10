using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidStats.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BezirkId = table.Column<int>(type: "int", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Infections = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    WeeklyIncidents = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bundeslands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CasesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bundeslands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bundeslands_Cases_CasesId",
                        column: x => x.CasesId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bezirks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BundeslandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bezirks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bezirks_Bundeslands_BundeslandId",
                        column: x => x.BundeslandId,
                        principalTable: "Bundeslands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bezirks_BundeslandId",
                table: "Bezirks",
                column: "BundeslandId");

            migrationBuilder.CreateIndex(
                name: "IX_Bundeslands_CasesId",
                table: "Bundeslands",
                column: "CasesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_BezirkId",
                table: "Cases",
                column: "BezirkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Bezirks_BezirkId",
                table: "Cases",
                column: "BezirkId",
                principalTable: "Bezirks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bezirks_Bundeslands_BundeslandId",
                table: "Bezirks");

            migrationBuilder.DropTable(
                name: "Bundeslands");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Bezirks");
        }
    }
}
