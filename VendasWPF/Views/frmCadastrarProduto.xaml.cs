using System;
using System.Windows;
using VendasWPF.DAL;
using VendasWPF.Models;

namespace VendasWPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarCliente.xaml
    /// </summary>
    public partial class frmCadastrarProduto : Window
    {
        private Produto produto;
        public frmCadastrarProduto()
        {
            InitializeComponent();
            LimparFormulario();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                produto = new Produto
                {
                    Nome = txtNome.Text,
                    Quantidade = Convert.ToInt32(txtQuantidade.Text),
                    Preco = Convert.ToDouble(txtPreco.Text)
                };
                if (ProdutoDAO.Cadastrar(produto))
                {
                    MessageBox.Show("Produto cadastrado com sucesso!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    LimparFormulario();
                }
                else
                {
                    MessageBox.Show("Esse produto já existe!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LimparFormulario()
        {
            txtId.Clear();
            txtNome.Clear();
            txtQuantidade.Clear();
            txtPreco.Clear();
            txtCriadoEm.Clear();
            txtNome.Focus();
            produto = new Produto();
            btnAlterar.IsEnabled = false;
            btnRemover.IsEnabled = false;
            btnCadastrar.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNome.Text))
            {
                produto = ProdutoDAO.BuscarPorNome(txtNome.Text);
                if (produto != null)
                {
                    txtId.Text = produto.Id.ToString();
                    txtNome.Text = produto.Nome;
                    txtQuantidade.Text = produto.Quantidade.ToString();
                    txtPreco.Text = produto.Preco.ToString();
                    txtCriadoEm.Text = produto.CriadoEm.ToString();
                    btnAlterar.IsEnabled = true;
                    btnRemover.IsEnabled = true;
                    btnCadastrar.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("Este produto não existe!!!", "Vendas WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            LimparFormulario();
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (produto != null)
            {
                ProdutoDAO.Remover(produto);
                MessageBox.Show("O produto foi removido com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("O produto não existe!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            if (produto != null)
            {
                produto.Nome = txtNome.Text;
                produto.Preco = Convert.ToDouble(txtPreco.Text);
                produto.Quantidade = Convert.ToInt32(txtQuantidade.Text);
                ProdutoDAO.Alterar(produto);
                MessageBox.Show("O produto foi alterado com sucesso!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                LimparFormulario();
            }
            else
            {
                MessageBox.Show("O produto não existe!!!", "Vendas WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
