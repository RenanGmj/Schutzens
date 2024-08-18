using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    // Relacionamento com a classe Veiculo
    public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}