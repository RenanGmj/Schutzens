using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSZ.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Sobrenome { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // Senha armazenada como hash
        [Required]
        public string Senha { get; set; }

        // Relacionamento com Veiculos
        public virtual ICollection<Veiculo> Veiculos { get; set; }

        // Relacionamento com Agendamentos
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
