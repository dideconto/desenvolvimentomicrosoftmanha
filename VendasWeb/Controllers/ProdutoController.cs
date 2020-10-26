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
            _produtoDAO.Cadastrar(produto);
            return RedirectToAction("Index", "Produto");
        }

        public IActionResult Remover(int id)
        {
            _produtoDAO.Remover(id);
            return RedirectToAction("Index", "Produto");
        }
        public IActionResult Alterar(int id)
        {
            ViewBag.Produto = _produtoDAO.BuscarPorId(id);
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(int txtId, int hdnId,
            string txtNome, int txtQuantidade, double txtPreco, string txtDescricao)
        {
            Produto produto = _produtoDAO.BuscarPorId(txtId);

            produto.Nome = txtNome;
            produto.Descricao = txtDescricao;
            produto.Preco = txtPreco;
            produto.Quantidade = txtQuantidade;

            _produtoDAO.Alterar(produto);
            return RedirectToAction("Index", "Produto");
        }
    }
}
