using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCamposDealer.Migrations
{
    /// <inheritdoc />
    public partial class AjusteForeingKeyVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClientesidCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_ProdutosidProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClientesidCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_ProdutosidProduto",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ClientesidCliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ProdutosidProduto",
                table: "Vendas");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idCliente",
                table: "Vendas",
                column: "idCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas",
                column: "idProduto",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_idCliente",
                table: "Vendas",
                column: "idCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas",
                column: "idProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_idCliente",
                table: "Vendas");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Produtos_idProduto",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idCliente",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_idProduto",
                table: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "ClientesidCliente",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutosidProduto",
                table: "Vendas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClientesidCliente",
                table: "Vendas",
                column: "ClientesidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProdutosidProduto",
                table: "Vendas",
                column: "ProdutosidProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClientesidCliente",
                table: "Vendas",
                column: "ClientesidCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Produtos_ProdutosidProduto",
                table: "Vendas",
                column: "ProdutosidProduto",
                principalTable: "Produtos",
                principalColumn: "idProduto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
