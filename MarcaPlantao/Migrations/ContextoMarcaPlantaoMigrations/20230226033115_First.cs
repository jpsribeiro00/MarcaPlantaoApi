using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", nullable: false),
                    UF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especializacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especializacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Genero = table.Column<string>(type: "varchar(1)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: false),
                    Imagem = table.Column<byte[]>(type: "binary(16)", nullable: true),
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinicas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspecializacaoProfissional",
                columns: table => new
                {
                    EspecializacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecializacaoProfissional", x => new { x.EspecializacoesId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_EspecializacaoProfissional_Especializacoes_EspecializacoesId",
                        column: x => x.EspecializacoesId,
                        principalTable: "Especializacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspecializacaoProfissional_Profissionais_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    Turno = table.Column<string>(type: "varchar(200)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    ValorHoraExtra = table.Column<double>(type: "float", nullable: false),
                    Pagamento = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClinicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ofertas_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EspecializacaoOferta",
                columns: table => new
                {
                    EspecializacoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfertasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecializacaoOferta", x => new { x.EspecializacoesId, x.OfertasId });
                    table.ForeignKey(
                        name: "FK_EspecializacaoOferta_Especializacoes_EspecializacoesId",
                        column: x => x.EspecializacoesId,
                        principalTable: "Especializacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EspecializacaoOferta_Ofertas_OfertasId",
                        column: x => x.OfertasId,
                        principalTable: "Ofertas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfertaProfissional",
                columns: table => new
                {
                    OfertasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfissionaisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfertaProfissional", x => new { x.OfertasId, x.ProfissionaisId });
                    table.ForeignKey(
                        name: "FK_OfertaProfissional_Ofertas_OfertasId",
                        column: x => x.OfertasId,
                        principalTable: "Ofertas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfertaProfissional_Profissionais_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plantoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValorTotal = table.Column<string>(type: "varchar(200)", nullable: false),
                    HoraExtra = table.Column<string>(type: "varchar(200)", nullable: false),
                    Desconto = table.Column<string>(type: "varchar(200)", nullable: false),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comprovante = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProfissionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfertaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantoes_Ofertas_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Ofertas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plantoes_Profissionais_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_EnderecoId",
                table: "Clinicas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecializacaoOferta_OfertasId",
                table: "EspecializacaoOferta",
                column: "OfertasId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecializacaoProfissional_ProfissionaisId",
                table: "EspecializacaoProfissional",
                column: "ProfissionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_OfertaProfissional_ProfissionaisId",
                table: "OfertaProfissional",
                column: "ProfissionaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_ClinicaId",
                table: "Ofertas",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantoes_OfertaId",
                table: "Plantoes",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantoes_ProfissionalId",
                table: "Plantoes",
                column: "ProfissionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EspecializacaoOferta");

            migrationBuilder.DropTable(
                name: "EspecializacaoProfissional");

            migrationBuilder.DropTable(
                name: "OfertaProfissional");

            migrationBuilder.DropTable(
                name: "Plantoes");

            migrationBuilder.DropTable(
                name: "Especializacoes");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
