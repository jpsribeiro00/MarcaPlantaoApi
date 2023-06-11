using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Tentwiefour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Clinicas",
                type: "varbinary(8000)",
                maxLength: 8000,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Imagem",
                table: "Clinicas",
                type: "varbinary",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(8000)",
                oldMaxLength: 8000,
                oldNullable: true);
        }
    }
}
