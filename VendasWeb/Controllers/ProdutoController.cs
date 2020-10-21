using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Context _context;
        public ProdutoController(Context context) => _context = context;
        public IActionResult Index()
        {
            List<Produto> produtos = _context.Produtos.ToList();
            ViewBag.Produtos = produtos;
            ViewBag.Quantidade = produtos.Count;
            return View();
        }
        public IActionResult Cadastrar() => View();
        [HttpPost]
        public IActionResult Cadastrar(string txtNome, int txtQuantidade, double txtPreco, string txtDescricao)
        {
            Produto produto = new Produto
            {
                Nome = txtNome,
                Descricao = txtDescricao,
                Preco = txtPreco,
                Quantidade = txtQuantidade
            };
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }

        public IActionResult Remover(int id)
        {
            //Completar com o código da remoção
            return RedirectToAction("Index", "Produto");
        }
    }
}
