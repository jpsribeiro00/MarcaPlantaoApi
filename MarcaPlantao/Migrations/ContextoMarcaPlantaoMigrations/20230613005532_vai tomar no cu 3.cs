using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class vaitomarnocu3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_Clinicas_ClinicaId",
                table: "Alertas");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_ClinicaId",
                table: "Alertas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Alertas_ClinicaId",
                table: "Alertas",
                column: "ClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_Clinicas_ClinicaId",
                table: "Alertas",
                column: "ClinicaId",
                principalTable: "Clinicas",
                principalColumn: "Id");
        }
    }
}
