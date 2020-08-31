using System.Collections.Generic;
using VendasConsole.Models;

namespace VendasConsole.DAL
{
    class ProdutoDAO
    {
        private static List<Produto> produtos = new List<Produto>();

        public static bool Cadastrar(Produto produto)
        {
            if (BuscarPorNome(produto.Nome) != null)
            {
                return false;
            }
            produtos.Add(produto);
            return true;
        }

        public static Produto BuscarPorNome(string nome)
        {
            foreach (Produto produtoCadastrado in produtos)
            {
                if (nome.Equals(produtoCadastrado.Nome))
                {
                    return produtoCadastrado;
                }
            }
            return null;
        }

        public static List<Produto> Listar() => produtos;

    }
}
