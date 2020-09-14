using BancoDados.DAL;
using BancoDados.Models;
using System;

namespace BancoDados.Views
{
    class CadastrarPessoa
    {
        public static void Renderizar()
        {
            Pessoa pessoa = new Pessoa();
            Console.WriteLine(" --- CADASTRAR PESSOA --- \n");
            Console.WriteLine("Digite o nome da pessoa:");
            pessoa.Nome = Console.ReadLine();
            Console.WriteLine("Digite o e-mail da pessoa:");
            pessoa.Email = Console.ReadLine();
            PessoaDAO.Cadastrar(pessoa);
            Console.WriteLine("Pessoa cadastrada com sucesso!!!");
        }
    }
}
