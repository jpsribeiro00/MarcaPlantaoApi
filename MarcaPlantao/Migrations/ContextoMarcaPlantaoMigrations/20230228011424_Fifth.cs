using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicaId",
                table: "Plantoes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Plantoes_ClinicaId",
                table: "Plantoes",
                column: "ClinicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantoes_Clinicas_ClinicaId",
                table: "Plantoes",
                column: "ClinicaId",
                principalTable: "Clinicas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantoes_Clinicas_ClinicaId",
                table: "Plantoes");

            migrationBuilder.DropIndex(
                name: "IX_Plantoes_ClinicaId",
                table: "Plantoes");

            migrationBuilder.DropColumn(
                name: "ClinicaId",
                table: "Plantoes");
        }
    }
}
