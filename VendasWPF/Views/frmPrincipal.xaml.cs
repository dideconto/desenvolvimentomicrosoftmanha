﻿using System.Windows;

namespace VendasWPF.Views
{
    /// <summary>
    /// Interaction logic for frmPrincipal.xaml
    /// </summary>
    public partial class frmPrincipal : Window
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void menuSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Vendas WPF",
                   MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void menuCadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            frmCadastrarCliente frm = new frmCadastrarCliente();
            frm.ShowDialog();
        }
    }
}
