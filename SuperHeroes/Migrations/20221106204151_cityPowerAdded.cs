using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroes.Migrations
{
    public partial class cityPowerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperHeroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Powers_SuperHeroes_SuperHeroId",
                        column: x => x.SuperHeroId,
                        principalTable: "SuperHeroes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_CityId",
                table: "SuperHeroes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Powers_SuperHeroId",
                table: "Powers",
                column: "SuperHeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Cities_CityId",
                table: "SuperHeroes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Cities_CityId",
                table: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_CityId",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
