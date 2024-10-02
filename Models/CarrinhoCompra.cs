using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}