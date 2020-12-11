using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasWeb.DAL;
using VendasWeb.Models;

namespace VendasWeb.Controllers
{
    //RestClient - VS Code
    //Postman
    //Insomnia
    [Route("api/Produto")]
    [ApiController]
    public class ProdutoAPIController : ControllerBase
    {
        private readonly ProdutoDAO _produtoDAO;
        public ProdutoAPIController(ProdutoDAO produtoDAO)
        {
            _produtoDAO = produtoDAO;
        }

        //GET: /api/Produto/Listar
        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<Produto> produtos = _produtoDAO.Listar();
            if (produtos.Count > 0)
            {
                return Ok(produtos);
            }
            return BadRequest(new { msg = "Não existem registros de produto!" });
        }

        //GET: /api/Produto/Buscar
        [HttpGet]
        [Route("Buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            Produto produto = _produtoDAO.BuscarPorId(id);
            if (produto != null)
            {
                return Ok(produto);
            }
            return NotFound(new { msg = "Produto não encontrado!" });
        }

        //GET: /api/Produto/Cadastrar
        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (_produtoDAO.Cadastrar(produto))
                {
                    return Created("", produto);
                }
                return Conflict(new { msg = "Já existe um produto com esse nome!" });
            }
            return BadRequest(ModelState);
        }
    }
}
