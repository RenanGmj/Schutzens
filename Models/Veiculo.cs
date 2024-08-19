using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Veiculo
    {
    public int VeiculoID { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Cor { get; set; }

    [Required]
    public string Placa { get; set; }

    // Chave estrangeira para ClasseVeiculo
    [Required]
    public int ClasseVeiculoID { get; set; }

    // Propriedade de navegação
    [ForeignKey("ClasseVeiculoID")]
    public virtual ClasseVeiculo ClasseVeiculo { get; set; }

    // Chave estrangeira para Usuario
    [Required]
    public int UsuarioID { get; set; }

    // Propriedade de navegação
    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; }

    // Relacionamento com Agendamentos
    public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}