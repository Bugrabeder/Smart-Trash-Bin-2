using Microsoft.EntityFrameworkCore.Migrations;

namespace iotdustbin.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "verilers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doluluk = table.Column<float>(type: "real", nullable: false),
                    sicaklik = table.Column<float>(type: "real", nullable: false),
                    atesdurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gazdurumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fan = table.Column<int>(type: "int", nullable: false),
                    buzzer = table.Column<int>(type: "int", nullable: false),
                    kapakacma = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verilers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "verilers");
        }
    }
}
