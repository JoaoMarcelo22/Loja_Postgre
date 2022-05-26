using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loja.Migrations
{
    public partial class AtualizaçãoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "tb_produto");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "tb_produto",
                newName: "preco");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_produto",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "tb_produto",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_produto",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_produto",
                table: "tb_produto");

            migrationBuilder.RenameTable(
                name: "tb_produto",
                newName: "Produtos");

            migrationBuilder.RenameColumn(
                name: "preco",
                table: "Produtos",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Produtos",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "categoria",
                table: "Produtos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Produtos",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");
        }
    }
}
