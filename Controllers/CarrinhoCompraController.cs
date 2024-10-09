using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Schutzens.Models;
using Schutzens.Repositories.Interfaces;
using Schutzens.ViewModels;

namespace Schutzens.Controllers
{
    [Route("[controller]")]
    public class CarrinhoCompraController : Controller
    {
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProdutoRepository produtoRepository, CarrinhoCompra carrinhoCompra)
        {
            _ProdutoRepository = produtoRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal(),
            };
            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoDeCompra(int produtoId){
            var produtoSelecionado = _ProdutoRepository.produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoverItemDoCarrinhoDeCompra(int produtoId){
            var produtoSelecionado = _ProdutoRepository.produtos
                                    .FirstOrDefault(p => p.ProdutoId == produtoId);
            
            if(produtoSelecionado != null){
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }

            return RedirectToAction("Index");
        }

        
    }
}