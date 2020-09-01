using System;
using VendasConsole.DAL;
using VendasConsole.Models;

namespace VendasConsole.Views
{
    class CadastrarVenda
    {
        public static void Renderizar()
        {
            Venda venda = new Venda();
            Cliente c = new Cliente();
            Vendedor v = new Vendedor();
            Produto p = new Produto();
            ItemVenda iv = new ItemVenda();

            Console.WriteLine(" ---- CADASTRAR VENDA ---- \n");
            Console.WriteLine("Digite o CPF do cliente: ");
            c.Cpf = Console.ReadLine();
            c = ClienteDAO.BuscarPorCpf(c.Cpf);
            if (c != null)
            {
                venda.Cliente = c;

                Console.WriteLine("Digite o CPF do vendedor: ");
                v.Cpf = Console.ReadLine();
                v = VendedorDAO.BuscarPorCpf(v.Cpf);
                if (v != null)
                {
                    venda.Vendedor = v;

                    do
                    {
                        iv = new ItemVenda();
                        p = new Produto();
                        Console.Clear();
                        Console.WriteLine(" ---- ADICIONAR ITEM ---- \n");
                        Console.WriteLine("Digite o nome do produto: ");
                        p.Nome = Console.ReadLine();
                        p = ProdutoDAO.BuscarPorNome(p.Nome);
                        if (p != null)
                        {
                            iv.Produto = p;
                            Console.WriteLine("Digite a quantidade do produto: ");
                            iv.Quantidade = Convert.ToInt32(Console.ReadLine());
                            iv.Preco = p.Preco;
                            venda.Itens.Add(iv);
                        }
                        else
                        {
                            Console.WriteLine("\nEsse produto não existe!!!");
                        }
                        Console.WriteLine("Deseja adicionar mais produtos? S/N");
                    } while (Console.ReadLine().ToUpper().Equals("S"));
                    VendaDAO.Cadastrar(venda);
                    Console.WriteLine("\nVenda cadastrada com sucesso!!!");
                }
                else
                {
                    Console.WriteLine("\nEsse vendedor não existe!!!");
                }
            }
            else
            {
                Console.WriteLine("\nEsse cliente não existe!!!");
            }
        }
    }
}
