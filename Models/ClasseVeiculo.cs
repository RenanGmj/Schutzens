using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSZ.Models
{
    public class ClasseVeiculo
    {
        public int ClasseVeiculoID { get; set; }
        public string Nome { get; set; }  // Nome da classe, por exemplo, SUV, Hatchback

    // Relacionamento com os serviços
        public virtual ICollection<Servico> Servicos { get; set; }

    // Relacionamento com os veículos
        
    }
}