using System;
using System.Collections.Generic;

namespace VendasConsole
{
    class Program
    {
        //https://www.geradorcpf.com/algoritmo_do_cpf.htm
        static void Main(string[] args)
        {
            int opcao;
            Cliente c = new Cliente();
            List<Cliente> clientes = new List<Cliente>();
            bool clienteEncontrado = false;

            do
            {
                Console.Clear();
                Console.WriteLine(" --- PROJETO DE VENDAS --- \n");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("0 - Sair\n");
                Console.WriteLine("Escolha uma opção:");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        c = new Cliente();
                        Console.WriteLine(" --- CADASTRAR CLIENTE --- \n");
                        Console.WriteLine("Digite o nome do cliente:");
                        c.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o CPF do cliente:");
                        c.Cpf = Console.ReadLine();

                        if(clientes.Count == 0)
                        {
                            clientes.Add(c);
                            Console.WriteLine("\nCliente cadastrado como sucesso!!!");
                        }
                        else
                        {
                            clienteEncontrado = false;
                            foreach (Cliente clienteCadastrado in clientes)
                            {
                                if (clienteCadastrado.Cpf == c.Cpf)
                                {
                                    Console.WriteLine("Esse cliente já existe!");
                                    clienteEncontrado = true;
                                }
                            }
                            if(!clienteEncontrado)
                            {
                                clientes.Add(c);
                                Console.WriteLine("\nCliente cadastrado como sucesso!!!");
                            }
                        }
                        break;
                    case 2:
                        Console.WriteLine(" --- LISTAR CLIENTES --- \n");
                        foreach (Cliente clienteCadastrado in clientes)
                        {
                            Console.WriteLine(clienteCadastrado);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saindo...\n");
                        break;
                    default:
                        Console.WriteLine(" --- OPÇÃO INVÁLIDA!!! --- \n");
                        break;
                }
                Console.WriteLine("\nAperte uma tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }
    
    }
}
