using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoSZ.Context;
using Schutzens.Models;
using Schutzens.Repositories.Interfaces;

namespace Schutzens.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SchutzenDbContext _context;
        public ProdutoRepository(SchutzenDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Produto> Produtos => throw new NotImplementedException();

        public IEnumerable<Produto> produtos => throw new NotImplementedException();

        public IEnumerable<Produto> ProdutosPreferidos => throw new NotImplementedException();

        public Produto GetLancheById(int produtoId) => _context.Produtos.FirstOrDefault(i=>i.ProdutoId == produtoId);
    }
}
