using Newtonsoft.Json;
using ProjetoDevSTi3.View.UserControls;
using ProjetoDevSTi3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
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

        private void TxtBxPesquisa_LostFocus(object sender, RoutedEventArgs e)
        {
            ItemsPedido((sender as TextBox).Text);
        }

        private void ItemsPedido(string pedido)
        {
            //https://desafiotecnicosti3.azurewebsites.net/pedido
            var client = new HttpClient
            {
                BaseAddress = new System.Uri("https://desafiotecnicosti3.azurewebsites.net/")
            };

            var response = client.GetAsync($"/pedido{pedido}").Result;

            if (response.IsSuccessStatusCode)
            {
                var enderecoCompleto = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<ConsumedAPIPedido>(enderecoCompleto);
            }
            else
            {
                MessageBox.Show("Erro encontrado, API funcionando incorretamente", "Atenção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public class ConsumedAPIPedido
        {
            public string Id { get; set; }
            public string Numero { get; set; }
            public string DataCriacao { get; set; }
            public string DataAlteracao { get; set; }
            public string Status { get; set; }
            public string Desconto { get; set; }
            public string Frete { get; set; }
            public string SubTotal { get; set; }
            public string Total { get; set; }


            public string Nome { get; set; }
            public string Documento { get; set; }
            public string DataNascimento { get; set; }
            public string Email { get; set; }
            public string Cnpj { get; set; }
            public string Cpf { get; set; }


            public string Endereco { get; set; }
            public string NumeroRua { get; set; }
            public string Cep { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Estado { get; set; }
            public string Complemento { get; set; }
            public string Referencia { get; set; }
        }
    }
}
