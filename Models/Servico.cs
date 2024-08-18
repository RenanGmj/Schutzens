using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class Servico
    {
        public int ServicoID { get; set; }
        public string Nome { get; set; }  // Nome do serviço, por exemplo, "Polimento", "Higienização", etc.
        public decimal PrecoBase { get; set; } // Preço base do serviço

        // Relacionamento com as classes de veículos
        public virtual ICollection<ClasseVeiculo> ClassesVeiculo { get; set; }
    }
}