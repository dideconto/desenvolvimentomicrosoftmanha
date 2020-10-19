using Microsoft.AspNetCore.Mvc;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Context _context;
        public ProdutoController(Context context)
        {
            _context = context;
        }
        public IActionResult Index() => View();
        public IActionResult Cadastrar() => View();
        [HttpPost]
        public IActionResult Cadastrar(string txtNome, int txtQuantidade,
            double txtPreco, string txtDescricao)
        {
            return RedirectToAction("Index", "Produto");
        }
    }
}
