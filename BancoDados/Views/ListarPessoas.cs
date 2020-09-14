using BancoDados.Models;
using System;
using System.Collections.Generic;

namespace BancoDados.Views
{
    class ListarPessoas
    {
        public static void Renderizar(List<Pessoa> pessoas)
        {
            Console.WriteLine("\n --- LISTAR PESSOAS --- \n");
            foreach (Pessoa pessoaCadastrado in pessoas)
            {
                Console.WriteLine(pessoaCadastrado);
            }
        }
    }
}
