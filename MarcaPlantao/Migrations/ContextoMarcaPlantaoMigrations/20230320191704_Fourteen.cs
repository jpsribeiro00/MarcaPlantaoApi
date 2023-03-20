using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "plantaoId",
                table: "AvaliacaoProfissionais",
                newName: "PlantaoId");

            migrationBuilder.RenameColumn(
                name: "plantaoId",
                table: "AvaliacaoClinicas",
                newName: "PlantaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlantaoId",
                table: "AvaliacaoProfissionais",
                newName: "plantaoId");

            migrationBuilder.RenameColumn(
                name: "PlantaoId",
                table: "AvaliacaoClinicas",
                newName: "plantaoId");
        }
    }
}
