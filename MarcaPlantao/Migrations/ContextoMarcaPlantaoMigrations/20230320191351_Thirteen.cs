using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Thirteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoClinicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: false),
                    plantaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoClinicas_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AvaliacaoClinicas_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoProfissionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: false),
                    plantaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoProfissionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoProfissionais_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AvaliacaoProfissionais_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoClinicas_ClinicaId",
                table: "AvaliacaoClinicas",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoClinicas_ProfissionalId",
                table: "AvaliacaoClinicas",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProfissionais_ClinicaId",
                table: "AvaliacaoProfissionais",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoProfissionais_ProfissionalId",
                table: "AvaliacaoProfissionais",
                column: "ProfissionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoClinicas");

            migrationBuilder.DropTable(
                name: "AvaliacaoProfissionais");
        }
    }
}
