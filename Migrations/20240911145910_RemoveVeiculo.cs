using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoSZ.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Veiculos_VeiculoID",
                table: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_VeiculoID",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "VeiculoID",
                table: "Agendamentos");

            migrationBuilder.InsertData(
                table: "ClasseVeiculos",
                columns: new[] { "ClasseVeiculoID", "Nome" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "SEDAN" },
                    { 3, "HATCH" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClasseVeiculos",
                keyColumn: "ClasseVeiculoID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClasseVeiculos",
                keyColumn: "ClasseVeiculoID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClasseVeiculos",
                keyColumn: "ClasseVeiculoID",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "VeiculoID",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasseVeiculoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoID);
                    table.ForeignKey(
                        name: "FK_Veiculos_ClasseVeiculos_ClasseVeiculoID",
                        column: x => x.ClasseVeiculoID,
                        principalTable: "ClasseVeiculos",
                        principalColumn: "ClasseVeiculoID");
                    table.ForeignKey(
                        name: "FK_Veiculos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_VeiculoID",
                table: "Agendamentos",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ClasseVeiculoID",
                table: "Veiculos",
                column: "ClasseVeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UsuarioID",
                table: "Veiculos",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Veiculos_VeiculoID",
                table: "Agendamentos",
                column: "VeiculoID",
                principalTable: "Veiculos",
                principalColumn: "VeiculoID");
        }
    }
}
