using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class TwentieOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sobre",
                table: "Profissionais",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sobre",
                table: "Clinicas",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sobre",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Sobre",
                table: "Clinicas");
        }
    }
}
