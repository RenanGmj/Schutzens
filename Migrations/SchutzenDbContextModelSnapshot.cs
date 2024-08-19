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

                    b.Property<int>("VeiculoID")
                        .HasColumnType("int");

                    b.HasKey("AgendamentoID");

                    b.HasIndex("UsuarioID");

                    b.HasIndex("VeiculoID");

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
                });

            modelBuilder.Entity("ProjetoSZ.Models.Servico", b =>
                {
                    b.Property<int>("ServicoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServicoID"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoBase")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServicoID");

                    b.ToTable("Servicos");
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

            modelBuilder.Entity("ProjetoSZ.Models.Veiculo", b =>
                {
                    b.Property<int>("VeiculoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeiculoID"));

                    b.Property<int>("ClasseVeiculoID")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("VeiculoID");

                    b.HasIndex("ClasseVeiculoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Veiculos");
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

                    b.HasOne("ProjetoSZ.Models.Veiculo", "Veiculo")
                        .WithMany("Agendamentos")
                        .HasForeignKey("VeiculoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("ProjetoSZ.Models.Veiculo", b =>
                {
                    b.HasOne("ProjetoSZ.Models.ClasseVeiculo", "ClasseVeiculo")
                        .WithMany("Veiculos")
                        .HasForeignKey("ClasseVeiculoID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ProjetoSZ.Models.Usuario", "Usuario")
                        .WithMany("Veiculos")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ClasseVeiculo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ProjetoSZ.Models.ClasseVeiculo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ProjetoSZ.Models.Usuario", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ProjetoSZ.Models.Veiculo", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
