using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCamposDealer.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTamanhoValores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "vlrUnitarioVenda",
                table: "Vendas",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "vlrTotalVenda",
                table: "Vendas",
                type: "numeric(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,2)");

            migrationBuilder.AlterColumn<float>(
                name: "vlrUnitario",
                table: "Produtos",
                type: "float(12)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "vlrUnitarioVenda",
                table: "Vendas",
                type: "numeric(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "vlrTotalVenda",
                table: "Vendas",
                type: "numeric(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(12,2)");

            migrationBuilder.AlterColumn<float>(
                name: "vlrUnitario",
                table: "Produtos",
                type: "float(6)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(12)");
        }
    }
}
