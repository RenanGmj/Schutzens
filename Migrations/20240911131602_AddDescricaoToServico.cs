using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoSZ.Migrations
{
    /// <inheritdoc />
    public partial class AddDescricaoToServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Servicos",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Servicos",
                columns: new[] { "ServicoID", "Descricao", "Nome", "PrecoBase" },
                values: new object[,]
                {
                    { 1, "Lavagem detalhada do veículo, incluindo interior e exterior.", "Lavagem detalhada", 100.00m },
                    { 2, "Remoção profunda de defeitos na pintura, com acabamento de alta qualidade e durabilidade.", "Polimento tecnico", 400.00m },
                    { 3, "Melhoria rápida da aparência da pintura, focando em brilho e custo-benefício.", "Polimento comercial", 250.00m },
                    { 4, "Limpeza completa do interior do veículo, incluindo estofados e carpetes.", "Higienização interna", 200.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Servicos",
                keyColumn: "ServicoID",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Servicos");
        }
    }
}
