using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schutzens.Models;

namespace Schutzens.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> produtos { get; }
        Produto GetLancheById(int produtoId);
    }
}