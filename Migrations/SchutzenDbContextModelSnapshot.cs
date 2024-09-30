﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoSZ.Context;

#nullable disable

namespace ProjetoSZ.Migrations
{
    [DbContext(typeof(SchutzenDbContext))]
    partial class SchutzenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgendamentoServico", b =>
                {
                    b.Property<int>("AgendamentosAgendamentoID")
                        .HasColumnType("int");

                    b.Property<int>("ServicosServicoID")
                        .HasColumnType("int");

                    b.HasKey("AgendamentosAgendamentoID", "ServicosServicoID");

                    b.HasIndex("ServicosServicoID");

                    b.ToTable("AgendamentoServico", (string)null);
                });

            modelBuilder.Entity("ClasseVeiculoServico", b =>
                {
                    b.Property<int>("ClassesVeiculoClasseVeiculoID")
                        .HasColumnType("int");

                    b.Property<int>("ServicosServicoID")
                        .HasColumnType("int");

                    b.HasKey("ClassesVeiculoClasseVeiculoID", "ServicosServicoID");

                    b.HasIndex("ServicosServicoID");

                    b.ToTable("ServicoClasseVeiculo", (string)null);
                });

            modelBuilder.Entity("ProjetoSZ.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoID"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("AgendamentoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Agendamentos");
                });

            modelBuilder.Entity("ProjetoSZ.Models.ClasseVeiculo", b =>
                {
                    b.Property<int>("ClasseVeiculoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClasseVeiculoID"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClasseVeiculoID");

                    b.ToTable("ClasseVeiculos");

                    b.HasData(
                        new
                        {
                            ClasseVeiculoID = 1,
                            Nome = "SUV"
                        },
                        new
                        {
                            ClasseVeiculoID = 2,
                            Nome = "SEDAN"
                        },
                        new
                        {
                            ClasseVeiculoID = 3,
                            Nome = "HATCH"
                        });
                });

            modelBuilder.Entity("ProjetoSZ.Models.Servico", b =>
                {
                    b.Property<int>("ServicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicoID"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoBase")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServicoID");

                    b.ToTable("Servicos");

                    b.HasData(
                        new
                        {
                            ServicoID = 1,
                            Descricao = "Lavagem detalhada do veículo, incluindo interior e exterior.",
                            Nome = "Lavagem detalhada",
                            PrecoBase = 100.00m
                        },
                        new
                        {
                            ServicoID = 2,
                            Descricao = "Remoção profunda de defeitos na pintura, com acabamento de alta qualidade e durabilidade.",
                            Nome = "Polimento tecnico",
                            PrecoBase = 400.00m
                        },
                        new
                        {
                            ServicoID = 3,
                            Descricao = "Melhoria rápida da aparência da pintura, focando em brilho e custo-benefício.",
                            Nome = "Polimento comercial",
                            PrecoBase = 250.00m
                        },
                        new
                        {
                            ServicoID = 4,
                            Descricao = "Limpeza completa do interior do veículo, incluindo estofados e carpetes.",
                            Nome = "Higienização interna",
                            PrecoBase = 200.00m
                        },
                        new
                        {
                            ServicoID = 5,
                            Descricao = "Limpeza e proteção do compartimento do motor.",
                            Nome = "Detalhamento de Motor",
                            PrecoBase = 350.00m
                        },
                        new
                        {
                            ServicoID = 6,
                            Descricao = "Remoção de riscos e manchas dos vidros.",
                            Nome = "Polimento de Vidros",
                            PrecoBase = 200.00m
                        },
                        new
                        {
                            ServicoID = 7,
                            Descricao = "Proteção contra líquidos e manchas em tecidos.",
                            Nome = "Impermeabilização de Estofados",
                            PrecoBase = 500.00m
                        },
                        new
                        {
                            ServicoID = 8,
                            Descricao = "Eliminação de odores indesejáveis no interior do veículo.",
                            Nome = "Remoção de Odor",
                            PrecoBase = 350.00m
                        });
                });

            modelBuilder.Entity("ProjetoSZ.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Schutzens.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("DescricaoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoProduto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProdutoNome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            DescricaoProduto = "O Kit Vonixx oferece produtos essenciais para limpar e proteger o carro, incluindo shampoo, cera e desengraxante, proporcionando brilho e conservação para todas as superfícies.",
                            ImagemProduto = "~/img/ImgDoProduto1.jpeg",
                            PrecoProduto = 200.00m,
                            ProdutoNome = "Kit Vonixx"
                        },
                        new
                        {
                            ProdutoId = 2,
                            DescricaoProduto = "Renova superfícies plásticas do veículo, removendo sujeiras e protegendo contra raios UV, deixando um acabamento brilhante e conservado.",
                            ImagemProduto = "~/img/ImgDoProduto2.jpeg",
                            PrecoProduto = 90.00m,
                            ProdutoNome = "Kit Limpa Plástico"
                        },
                        new
                        {
                            ProdutoId = 3,
                            DescricaoProduto = "Limpador concentrado de alta performance, desenvolvido para remover sujeiras pesadas em estofados, carpetes e superfícies internas do veículo.",
                            ImagemProduto = "~/img/ImgDoProduto3.jpeg",
                            PrecoProduto = 120.00m,
                            ProdutoNome = "Vonixx Sintra"
                        },
                        new
                        {
                            ProdutoId = 4,
                            DescricaoProduto = "Cera de carnaúba premium usada para proteção e brilho de alta qualidade em pinturas automotivas.",
                            ImagemProduto = "~/img/ImgDoProduto4.jpeg",
                            PrecoProduto = 80.00m,
                            ProdutoNome = "GH-Wax Pure"
                        },
                        new
                        {
                            ProdutoId = 5,
                            DescricaoProduto = "Revitalizador de plásticos que recupera e renova superfícies plásticas automotivas desgastadas pelo tempo.",
                            ImagemProduto = "~/img/ImgDoProduto5.jpeg",
                            PrecoProduto = 70.00m,
                            ProdutoNome = "Vonixx Restaurax"
                        });
                });

            modelBuilder.Entity("AgendamentoServico", b =>
                {
                    b.HasOne("ProjetoSZ.Models.Agendamento", null)
                        .WithMany()
                        .HasForeignKey("AgendamentosAgendamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoSZ.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosServicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClasseVeiculoServico", b =>
                {
                    b.HasOne("ProjetoSZ.Models.ClasseVeiculo", null)
                        .WithMany()
                        .HasForeignKey("ClassesVeiculoClasseVeiculoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoSZ.Models.Servico", null)
                        .WithMany()
                        .HasForeignKey("ServicosServicoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjetoSZ.Models.Agendamento", b =>
                {
                    b.HasOne("ProjetoSZ.Models.Usuario", "Usuario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoSZ.Models.Usuario", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
