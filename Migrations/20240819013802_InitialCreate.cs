using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSZ.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasseVeiculos",
                columns: table => new
                {
                    ClasseVeiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseVeiculos", x => x.ClasseVeiculoID);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    ServicoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.ServicoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "ServicoClasseVeiculo",
                columns: table => new
                {
                    ClassesVeiculoClasseVeiculoID = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoClasseVeiculo", x => new { x.ClassesVeiculoClasseVeiculoID, x.ServicosServicoID });
                    table.ForeignKey(
                        name: "FK_ServicoClasseVeiculo_ClasseVeiculos_ClassesVeiculoClasseVeiculoID",
                        column: x => x.ClassesVeiculoClasseVeiculoID,
                        principalTable: "ClasseVeiculos",
                        principalColumn: "ClasseVeiculoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicoClasseVeiculo_Servicos_ServicosServicoID",
                        column: x => x.ServicosServicoID,
                        principalTable: "Servicos",
                        principalColumn: "ServicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClasseVeiculoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    AgendamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    VeiculoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.AgendamentoID);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID");
                    table.ForeignKey(
                        name: "FK_Agendamentos_Veiculos_VeiculoID",
                        column: x => x.VeiculoID,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoID");
                });

            migrationBuilder.CreateTable(
                name: "AgendamentoServico",
                columns: table => new
                {
                    AgendamentosAgendamentoID = table.Column<int>(type: "int", nullable: false),
                    ServicosServicoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoServico", x => new { x.AgendamentosAgendamentoID, x.ServicosServicoID });
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Agendamentos_AgendamentosAgendamentoID",
                        column: x => x.AgendamentosAgendamentoID,
                        principalTable: "Agendamentos",
                        principalColumn: "AgendamentoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendamentoServico_Servicos_ServicosServicoID",
                        column: x => x.ServicosServicoID,
                        principalTable: "Servicos",
                        principalColumn: "ServicoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_UsuarioID",
                table: "Agendamentos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_VeiculoID",
                table: "Agendamentos",
                column: "VeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoServico_ServicosServicoID",
                table: "AgendamentoServico",
                column: "ServicosServicoID");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoClasseVeiculo_ServicosServicoID",
                table: "ServicoClasseVeiculo",
                column: "ServicosServicoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_ClasseVeiculoID",
                table: "Veiculos",
                column: "ClasseVeiculoID");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_UsuarioID",
                table: "Veiculos",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoServico");

            migrationBuilder.DropTable(
                name: "ServicoClasseVeiculo");

            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "ClasseVeiculos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
