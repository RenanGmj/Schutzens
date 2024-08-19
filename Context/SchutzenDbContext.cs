using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Models;

namespace ProjetoSZ.Context
{
    public class SchutzenDbContext:DbContext
    {
        public SchutzenDbContext(DbContextOptions<SchutzenDbContext> options)
        : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<ClasseVeiculo> ClasseVeiculos { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }


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

    // Relacionamento entre Veiculo e ClasseVeiculo
    modelBuilder.Entity<Veiculo>()
        .HasOne(v => v.ClasseVeiculo)
        .WithMany(c => c.Veiculos)
        .HasForeignKey(v => v.ClasseVeiculoID)
        .OnDelete(DeleteBehavior.NoAction); // Adiciona DeleteBehavior.NoAction

    // Relacionamento entre Veiculo e Usuario
    modelBuilder.Entity<Veiculo>()
        .HasOne(v => v.Usuario)
        .WithMany(u => u.Veiculos)
        .HasForeignKey(v => v.UsuarioID)
        .OnDelete(DeleteBehavior.NoAction); // Adiciona DeleteBehavior.NoAction

    // Relacionamento entre Agendamento e Usuario
    modelBuilder.Entity<Agendamento>()
        .HasOne(a => a.Usuario)
        .WithMany(u => u.Agendamentos)
        .HasForeignKey(a => a.UsuarioID)
        .OnDelete(DeleteBehavior.NoAction); // Adiciona DeleteBehavior.NoAction

    // Relacionamento entre Agendamento e Veiculo
    modelBuilder.Entity<Agendamento>()
        .HasOne(a => a.Veiculo)
        .WithMany(v => v.Agendamentos)
        .HasForeignKey(a => a.VeiculoID)
        .OnDelete(DeleteBehavior.NoAction); // Adiciona DeleteBehavior.NoAction

    // Relacionamento entre Agendamento e Servico
    modelBuilder.Entity<Agendamento>()
        .HasMany(a => a.Servicos)
        .WithMany(s => s.Agendamentos)
        .UsingEntity(j => j.ToTable("AgendamentoServico"));
}


    }
}