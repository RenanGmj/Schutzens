using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schutzens.Models
{
    [Table("Produtos")]
    public class Produto
    {
        public int ProdutoId { get; set;}

        public string ImagemProduto { get; set;}
        public string ProdutoNome { get; set;}
        public decimal PrecoProduto { get; set;}
        public string DescricaoProduto { get; set;}

    }
}