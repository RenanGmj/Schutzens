using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Models;
using Schutzens.Models;

namespace ProjetoSZ.Context
{
    public class SchutzenDbContext:DbContext
    {
        public SchutzenDbContext(DbContextOptions<SchutzenDbContext> options)
        : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ClasseVeiculo> ClasseVeiculos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        // Configuração de precisão para o campo PrecoBase
            modelBuilder.Entity<Servico>()
                .Property(s => s.PrecoBase)
                .HasPrecision(18, 2);

        // Configuração de relacionamento entre Servico e ClasseVeiculo
            modelBuilder.Entity<Servico>()
                .HasMany(s => s.ClassesVeiculo)
                .WithMany(c => c.Servicos)
                .UsingEntity(j => j.ToTable("ServicoClasseVeiculo"));

            modelBuilder.Entity<Servico>().HasData(
                new Servico{
                    ServicoID = 1,
                    Nome = "Lavagem detalhada",
                    Descricao = "Lavagem detalhada do veículo, incluindo interior e exterior.",
                    PrecoBase = 100.00m
                },
                new Servico{
                    ServicoID = 2,
                    Nome = "Polimento tecnico",
                    Descricao = "Remoção profunda de defeitos na pintura, com acabamento de alta qualidade e durabilidade.",
                    PrecoBase = 400.00m
                },
                new Servico{
                    ServicoID = 3,
                    Nome = "Polimento comercial",
                    Descricao = "Melhoria rápida da aparência da pintura, focando em brilho e custo-benefício.",
                    PrecoBase = 250.00m
                },
                new Servico{
                    ServicoID = 4,
                    Nome = "Higienização interna",
                    Descricao = "Limpeza completa do interior do veículo, incluindo estofados e carpetes.",
                    PrecoBase = 200.00m
                },
                new Servico{
                    ServicoID = 5,
                    Nome = "Detalhamento de Motor",
                    Descricao = "Limpeza e proteção do compartimento do motor.",
                    PrecoBase = 350.00m
                },
                new Servico{
                    ServicoID = 6,
                    Nome = "Polimento de Vidros",
                    Descricao = "Remoção de riscos e manchas dos vidros.",
                    PrecoBase = 200.00m
                },
                new Servico{
                    ServicoID = 7,
                    Nome = "Impermeabilização de Estofados",
                    Descricao = "Proteção contra líquidos e manchas em tecidos.",
                    PrecoBase = 500.00m
                },
                new Servico{
                    ServicoID = 8,
                    Nome = "Remoção de Odor",
                    Descricao = "Eliminação de odores indesejáveis no interior do veículo.",
                    PrecoBase = 350.00m
                }
                

            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto{
                    ProdutoId = 1,
                    ImagemProduto = "~/img/ImgDoProduto1.jpeg",
                    ProdutoNome = "Kit Vonixx",
                    PrecoProduto = 200.00m,
                    DescricaoProduto = "O Kit Vonixx oferece produtos essenciais para limpar e proteger o carro, incluindo shampoo, cera e desengraxante, proporcionando brilho e conservação para todas as superfícies."

                },
                new Produto{
                    ProdutoId = 2,
                    ImagemProduto = "~/img/ImgDoProduto2.jpeg",
                    ProdutoNome = "Kit Limpa Plástico",
                    PrecoProduto = 90.00m,
                    DescricaoProduto = "Renova superfícies plásticas do veículo, removendo sujeiras e protegendo contra raios UV, deixando um acabamento brilhante e conservado."

                },
                new Produto{
                    ProdutoId = 3,
                    ImagemProduto = "~/img/ImgDoProduto3.jpeg",
                    ProdutoNome = "Vonixx Sintra",
                    PrecoProduto = 120.00m,
                    DescricaoProduto = "Limpador concentrado de alta performance, desenvolvido para remover sujeiras pesadas em estofados, carpetes e superfícies internas do veículo."

                },
                new Produto{
                    ProdutoId = 4,
                    ImagemProduto = "~/img/ImgDoProduto4.jpeg",
                    ProdutoNome = "GH-Wax Pure",
                    PrecoProduto = 80.00m,
                    DescricaoProduto = "Cera de carnaúba premium usada para proteção e brilho de alta qualidade em pinturas automotivas."

                },
                new Produto{
                    ProdutoId = 5,
                    ImagemProduto = "~/img/ImgDoProduto5.jpeg",
                    ProdutoNome = "Vonixx Restaurax",
                    PrecoProduto = 70.00m,
                    DescricaoProduto = "Revitalizador de plásticos que recupera e renova superfícies plásticas automotivas desgastadas pelo tempo."

                }
            );

            modelBuilder.Entity<ClasseVeiculo>().HasData(
                new ClasseVeiculo{
                    ClasseVeiculoID = 1,
                    Nome = "SUV"
                    
                },
                new ClasseVeiculo{
                    ClasseVeiculoID = 2,
                    Nome = "SEDAN"
                    
                },
                new ClasseVeiculo{
                    ClasseVeiculoID = 3,
                    Nome = "HATCH"
                    
                }
            );    

        

        // Relacionamento entre Agendamento e Usuario
            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Agendamentos)
                .HasForeignKey(a => a.UsuarioID)
                .OnDelete(DeleteBehavior.NoAction); // Adiciona DeleteBehavior.NoAction

        
        // Relacionamento entre Agendamento e Servico
            modelBuilder.Entity<Agendamento>()
                .HasMany(a => a.Servicos)
                .WithMany(s => s.Agendamentos)
                .UsingEntity(j => j.ToTable("AgendamentoServico"));
        }


    }
}