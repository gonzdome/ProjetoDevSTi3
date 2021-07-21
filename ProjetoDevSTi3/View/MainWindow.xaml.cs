using ProjetoDevSTi3.View.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjetoDevSTi3.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnFechar.IsEnabled = false;
        }
        private void BtnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            InicializarUc(sender);
        }

        private void InicializarUc(object sender)
        {
            if (sender is Button)
            {
                Conteudo.Content = new UcOrderDetails();
                BtnFechar.IsEnabled = true;
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            Conteudo.Content = "";
            BtnFechar.IsEnabled = false;
        }

        private void BtnSincronizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
