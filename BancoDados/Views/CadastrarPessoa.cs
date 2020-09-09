using BancoDados.Models;
using System;
using System.Linq;

namespace BancoDados.Views
{
    class CadastrarPessoa
    {
        public static void Renderizar()
        {
            Context ctx = new Context();
            Pessoa pessoa = new Pessoa
            {
                Nome = "Maria Ribeiro",
                Email = "maria@maria.com"
            };

            ctx.Pessoas.Add(pessoa);
            ctx.SaveChanges();

            Console.WriteLine("Pessoa cadastrada com sucesso!!!");

            foreach (Pessoa pessoaCadastrado in ctx.Pessoas.ToList())
            {
                Console.WriteLine(pessoaCadastrado);
            }
        }
    }
}
