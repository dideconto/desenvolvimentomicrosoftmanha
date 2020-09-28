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
            dynamic item = new
            {
                Nome = produto.Nome,
                Subtotal = Convert.ToInt32(txtQuantidade.Text) * produto.Preco
            };
            produtos.Add(item);
            dtaProdutos.ItemsSource = produtos;
            dtaProdutos.Items.Refresh();
        }
    }
}
