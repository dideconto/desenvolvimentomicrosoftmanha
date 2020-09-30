using System;
using System.Collections.Generic;
using System.Windows;
using VendasWPF.DAL;
using VendasWPF.Models;

namespace VendasWPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarVenda.xaml
    /// </summary>
    public partial class frmCadastrarVenda : Window
    {
        private List<dynamic> produtos = new List<dynamic>();
        private Venda venda = new Venda();
        private double total = 0;
        public frmCadastrarVenda()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar lista de clientes
            cboClientes.ItemsSource = ClienteDAO.Listar();
            cboClientes.DisplayMemberPath = "Nome";
            cboClientes.SelectedValuePath = "Id";
            //Carregar lista de vendedores
            cboVendedores.ItemsSource = VendedorDAO.Listar();
            cboVendedores.DisplayMemberPath = "Nome";
            cboVendedores.SelectedValuePath = "Id";
            //Carregar lista de produtos
            cboProdutos.ItemsSource = ProdutoDAO.Listar();
            cboProdutos.DisplayMemberPath = "Nome";
            cboProdutos.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)cboProdutos.SelectedValue;
            Produto produto = ProdutoDAO.BuscarPorId(id);
            PopularDataGrid(produto);
            PopularVenda(produto);
            total += Convert.ToInt32(txtQuantidade.Text) * produto.Preco;
            lblTotal.Content = $"Total: {total:C2}";
        }

        private void PopularVenda(Produto produto)
        {
            venda.Itens.Add(
                new ItemVenda
                {
                    Produto = produto,
                    Preco = produto.Preco,
                    Quantidade = Convert.ToInt32(txtQuantidade.Text)
                }
            );
        }

        private void PopularDataGrid(Produto produto)
        {
            dynamic item = new
            {
                Nome = produto.Nome,
                Quantidade = txtQuantidade.Text,
                Preco = produto.Preco.ToString("C2"),
                Subtotal = (Convert.ToInt32(txtQuantidade.Text) * produto.Preco)
                    .ToString("C2")
            };
            produtos.Add(item);
            dtaProdutos.ItemsSource = produtos;
            dtaProdutos.Items.Refresh();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            int idCliente = (int)cboClientes.SelectedValue;
            int idVendedor = (int)cboVendedores.SelectedValue;
            Cliente cliente = ClienteDAO.BuscarPorId(idCliente);
            Vendedor vendedor = VendedorDAO.BuscarPorId(idVendedor);
            venda.Cliente = cliente;
            venda.Vendedor = vendedor;
            VendaDAO.Cadastrar(venda);
            MessageBox.Show("Venda cadastrada com sucesso!!!");
        }
    }
}
