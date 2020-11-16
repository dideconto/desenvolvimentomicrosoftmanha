using Microsoft.AspNetCore.Mvc;
using VendasWeb.DAL;

namespace VendasWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoDAO _produtoDAO;
        private readonly CategoriaDAO _categoriaDAO;
        public HomeController(ProdutoDAO produtoDAO, CategoriaDAO categoriaDAO)
        {
            _produtoDAO = produtoDAO;
            _categoriaDAO = categoriaDAO;
        }
        public IActionResult Index(int id)
        {
            ViewBag.Title = "E-commerce Manhã";
            ViewBag.Categorias = _categoriaDAO.Listar();
            if (id == 0)
            {
                return View(_produtoDAO.Listar());
            }
            return View(_produtoDAO.ListarPorCategoria(id));
        }
    }
}
