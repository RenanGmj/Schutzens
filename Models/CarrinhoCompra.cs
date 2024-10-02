using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoSZ.Context;

namespace Schutzens.Models
{
    public class CarrinhoCompra
    {
        private readonly SchutzenDbContext _context;
        public CarrinhoCompra(SchutzenDbContext context)
        {
            _context = context;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider services){
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<SchutzenDbContext>();

            string carrinhoId = session.GetString("CarrinhoId")?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            }    ;
        }

        public void AdicionarAoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                i => i.Produto.ProdutoId == produto.ProdutoId &&
                i.CarrinhoCompraId == CarrinhoCompraId );

            if(carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();    
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                i => i.Produto.ProdutoId == produto.ProdutoId &&
                i.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if(carrinhoCompraItem.Quantidade>1)
            {
                carrinhoCompraItem.Quantidade--;
                quantidadeLocal = carrinhoCompraItem.Quantidade;
            }
            else
            {
                _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
            }

            _context.SaveChanges();
            return quantidadeLocal;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItems()
        {
            return CarrinhoCompraItems ??
            (CarrinhoCompraItems =
                _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId).Include(s => s.Produto).ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);
                _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);
                _context.SaveChanges();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens.Where(_c => _c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produto.PrecoProduto * c.Quantidade).Sum();
            return total;
        }
    }
}