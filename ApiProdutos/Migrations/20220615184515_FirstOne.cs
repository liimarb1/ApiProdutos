using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiProdutos.Migrations
{
    public partial class FirstOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Produto",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Produto",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "clientes");
        }
    }
}
