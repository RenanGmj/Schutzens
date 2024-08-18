using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; set; }
        public string Nome { get; set; }
        public string Classe { get; set; }  // Referência à classe de veículos
        public string Cor { get; set; }
        public string Placa { get; set; }

    // Relacionamento com a classe Usuario
    public int UsuarioID { get; set; }
    public virtual Usuario Usuario { get; set; }
    }
}