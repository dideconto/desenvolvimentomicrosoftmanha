using BancoDados.Models;
using System;

namespace BancoDados.Views
{
    class BuscarPessoa
    {
        public static void Renderizar(Pessoa pessoa)
        {
            Console.WriteLine();
            string resultado = pessoa != null ? pessoa.ToString() : "Pessoa não encontrada!!!";
            Console.WriteLine(resultado);
        }
    }
}
