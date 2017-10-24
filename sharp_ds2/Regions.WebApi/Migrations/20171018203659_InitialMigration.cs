using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Regions.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "regions",
                columns: table => new
                {
                    region_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    region_capital = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    region_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regions", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "areas",
                columns: table => new
                {
                    area_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    area_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    region_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areas", x => x.area_id);
                    table.ForeignKey(
                        name: "FK_areas_regions_region_id",
                        column: x => x.region_id,
                        principalTable: "regions",
                        principalColumn: "region_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "localities",
                columns: table => new
                {
                    locality_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    area_id = table.Column<int>(type: "int", nullable: false),
                    locality_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    locality_population = table.Column<int>(type: "int", nullable: false),
                    locality_type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localities", x => x.locality_id);
                    table.ForeignKey(
                        name: "FK_localities_areas_area_id",
                        column: x => x.area_id,
                        principalTable: "areas",
                        principalColumn: "area_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_areas_region_id",
                table: "areas",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_localities_area_id",
                table: "localities",
                column: "area_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "localities");

            migrationBuilder.DropTable(
                name: "areas");

            migrationBuilder.DropTable(
                name: "regions");
        }
    }
}
