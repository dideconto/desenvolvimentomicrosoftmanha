using System;
using VendasConsole.DAL;
using VendasConsole.Models;

namespace VendasConsole.Views
{
    class ListarVendas
    {
        public static void Renderizar()
        {
            double totalGeral = 0, totalVenda = 0, totalItem = 0;
            Console.WriteLine(" --- LISTAR VENDAS --- \n");
            foreach (Venda vendaCadastrada in VendaDAO.Listar())
            {
                totalVenda = 0;
                Console.WriteLine($"Cliente: {vendaCadastrada.Cliente.Nome}");
                Console.WriteLine($"Vendedor: {vendaCadastrada.Vendedor.Nome}");
                Console.WriteLine("\n --- ITENS DA VENDA --- \n");
                Console.WriteLine($"\t{vendaCadastrada.Produto.Nome}");
                totalItem = vendaCadastrada.Quantidade * vendaCadastrada.Produto.Preco;
                Console.WriteLine($"\t{vendaCadastrada.Produto.Preco:C2} " +
                    $"x {vendaCadastrada.Quantidade} = {totalItem:C2}");
                totalVenda += totalItem;
                Console.WriteLine($"\tTotal da venda: {totalVenda:C2}\n");
                totalGeral += totalVenda;
            }
            Console.WriteLine($"\nTotal geral: {totalGeral:C2}");
        }
    }
}
