using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoSZ.Migrations
{
    /// <inheritdoc />
    public partial class injecaoServicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "ServicoID", "Descricao", "Nome", "PrecoBase" },
                values: new object[,]
                {
                    { 5, "Limpeza e proteção do compartimento do motor.", "Detalhamento de Motor", 350.00m },
                    { 6, "Remoção de riscos e manchas dos vidros.", "Polimento de Vidros", 200.00m },
                    { 7, "Proteção contra líquidos e manchas em tecidos.", "Impermeabilização de Estofados", 500.00m },
                    { 8, "Eliminação de odores indesejáveis no interior do veículo.", "Remoção de Odor", 350.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 8);
        }
    }
}
