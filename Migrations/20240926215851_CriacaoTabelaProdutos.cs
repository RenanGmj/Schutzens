using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoSZ.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoTabelaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagemProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdutoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "DescricaoProduto", "ImagemProduto", "PrecoProduto", "ProdutoNome" },
                values: new object[,]
                {
                    { 1, "O Kit Vonixx oferece produtos essenciais para limpar e proteger o carro, incluindo shampoo, cera e desengraxante, proporcionando brilho e conservação para todas as superfícies.", "~/img/ImgDoProduto1.jpeg", 200.00m, "Kit Vonixx" },
                    { 2, "Renova superfícies plásticas do veículo, removendo sujeiras e protegendo contra raios UV, deixando um acabamento brilhante e conservado.", "~/img/ImgDoProduto2.jpeg", 90.00m, "Kit Limpa Plástico" },
                    { 3, "Limpador concentrado de alta performance, desenvolvido para remover sujeiras pesadas em estofados, carpetes e superfícies internas do veículo.", "~/img/ImgDoProduto3.jpeg", 120.00m, "Vonixx Sintra" },
                    { 4, "Cera de carnaúba premium usada para proteção e brilho de alta qualidade em pinturas automotivas.", "~/img/ImgDoProduto4.jpeg", 80.00m, "GH-Wax Pure" },
                    { 5, "Revitalizador de plásticos que recupera e renova superfícies plásticas automotivas desgastadas pelo tempo.", "~/img/ImgDoProduto5.jpeg", 70.00m, "Vonixx Restaurax" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
