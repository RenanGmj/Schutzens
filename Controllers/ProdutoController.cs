using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSZ.Context;
using Schutzens.Models;

namespace Schutzens.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private readonly SchutzenDbContext _db;

        public ProdutoController(SchutzenDbContext db)
        {
            _db = db;
        }

        

        public IActionResult Index()
        {
            IEnumerable<Produto> produtos = _db.Produtos;    
            return View(produtos);
            
        }
    }
}