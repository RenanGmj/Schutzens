using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Agendamento
    {
    public int AgendamentoID { get; set; }

    [Required]
    public DateTime Data { get; set; }

    // Chave estrangeira para Usuario
    [Required]
    public int UsuarioID { get; set; }

    // Propriedade de navegação
    [ForeignKey("UsuarioID")]
    public virtual Usuario Usuario { get; set; }


    // Relacionamento com Servicos
    public virtual ICollection<Servico> Servicos { get; set; }

    
    }
}