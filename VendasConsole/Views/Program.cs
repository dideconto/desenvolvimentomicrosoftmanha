﻿using System;
using VendasConsole.DAL;

namespace VendasConsole.Views
{
    class Program
    {
        static void Main(string[] args)
        {
            Dados.Inicializar();
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine(" ---- PROJETO DE VENDAS ---- \n");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Listar clientes");
                Console.WriteLine("3 - Cadastrar vendedor");
                Console.WriteLine("4 - Listar vendedores");
                Console.WriteLine("5 - Cadastrar produto");
                Console.WriteLine("6 - Listar produtos");
                Console.WriteLine("7 - Cadastrar venda");
                Console.WriteLine("8 - Listar vendas");
                Console.WriteLine("9 - Listar vendas por cliente");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("\nEscolha uma opção:");
                opcao = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        CadastrarCliente.Renderizar();
                        break;
                    case 2:
                        ListarClientes.Renderizar();
                        break;
                    case 3:
                        CadastrarVendedor.Renderizar();
                        break;
                    case 4:
                        ListarVendedors.Renderizar();
                        break;
                    case 5:
                        CadastrarProduto.Renderizar();
                        break;
                    case 6:
                        ListarProdutos.Renderizar();
                        break;
                    case 7:
                        CadastrarVenda.Renderizar();
                        break;
                    case 8:
                        ListarVendas.Renderizar(VendaDAO.Listar());
                        break;
                    case 9:
                        Console.Clear();
                        Console.WriteLine("Digite o CPF do cliente: ");
                        string cpf = Console.ReadLine();
                        ListarVendas.Renderizar(VendaDAO.ListarPorCliente(cpf));
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
