using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasWeb.DAL;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoController(ProdutoDAO produtoDAO) => _produtoDAO = produtoDAO;
        public IActionResult Index()
        {
            List<Produto> produtos = _produtoDAO.Listar();
            ViewBag.Quantidade = produtos.Count;
            return View(produtos);
        }
        public IActionResult Cadastrar() => View();

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                ModelState.AddModelError("", "Não foi possível cadastradar o produto! Já existe um produto com o mesmo nome na base de dados!");
            }
            return View(produto);
        }

        public IActionResult Remover(int id)
        {
            _produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }
        public IActionResult Alterar(int id)
        {
            return View(_produtoDAO.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            _produtoDAO.Alterar(produto);
            return RedirectToAction("Index", "Produto");
        }
    }
}
