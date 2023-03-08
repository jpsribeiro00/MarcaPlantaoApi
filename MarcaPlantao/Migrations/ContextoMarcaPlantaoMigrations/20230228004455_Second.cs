using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorTotal",
                table: "Plantoes",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<double>(
                name: "HoraExtra",
                table: "Plantoes",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValorTotal",
                table: "Plantoes",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "HoraExtra",
                table: "Plantoes",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
