using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Profissionais",
                type: "varbinary",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "binary(16)",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Imagem",
                table: "Clinicas",
                type: "varbinary",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Clinicas");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Profissionais",
                type: "binary(16)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary",
                oldNullable: true);
        }
    }
}
