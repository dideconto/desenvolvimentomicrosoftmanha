using System;
using System.Windows;

namespace VendasWPF.Views
{
    /// <summary>
    /// Interaction logic for frmCadastrarCliente.xaml
    /// </summary>
    public partial class frmCadastrarCliente : Window
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n1 = Convert.ToInt32(txtNumero1.Text);
                int n2 = Convert.ToInt32(txtNumero2.Text);
                int soma = n1 + n2;
                MessageBox.Show($"Resultado: {soma}");
            }
            catch (Exception)
            {
                MessageBox.Show($"Somente números!!!");
            }
        }
    }
}
