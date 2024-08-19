using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoSZ.Models
{
    public class Servico
    {
    public int ServicoID { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    [Precision(18, 2)] // Define a precisão (18) e a escala (2) para o valor decimal
    public decimal PrecoBase { get; set; }

    // Relacionamento com ClasseVeiculo
    public virtual ICollection<ClasseVeiculo> ClassesVeiculo { get; set; }

    // Relacionamento com Agendamentos
    public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}