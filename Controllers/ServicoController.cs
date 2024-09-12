using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoSZ.Context;
using ProjetoSZ.Models;

namespace Schutzens.Controllers
{
    [Route("[controller]")]
    public class ServicoController : Controller
    {

        private readonly SchutzenDbContext _db;
        public ServicoController(SchutzenDbContext db){
            _db = db;
        }
        
        
        public IActionResult Index()
        {
            List<Servico> objServicoList = _db.Servicos.ToList();
            return View(objServicoList);
        }

    }       
}