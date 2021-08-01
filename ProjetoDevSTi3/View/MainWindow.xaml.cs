using Newtonsoft.Json;
using ProjetoDevSTi3.View.UserControls;
using ProjetoDevSTi3.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace ProjetoDevSTi3.View
{
    public partial class MainWindow : Window
    {
        public UcOrderDetails UcOrderDetailsVm = new UcOrderDetails();

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

        private void TxtBxPesquisa_LostFocus(object sender, RoutedEventArgs e)
        {
            LimparLista();
            ItemsPedido((sender as TextBox).Text);
        }

        private void LimparLista()
        {
            ItemsControlPedido.Items.Clear();
        }
        private void BtnSincronizar_Click(object sender, RoutedEventArgs e)
        {
        }

        public ObservableCollection<Tuple<long, DateTime, string, string, string>> ItemsPedidoList { get; set; } = 
            new ObservableCollection<Tuple<long, DateTime, string, string, string>>();

        private void ItemsPedido(string pedido)
        {
            //https://desafiotecnicosti3.azurewebsites.net/pedido
            var client = new HttpClient
            {
                BaseAddress = new System.Uri("https://desafiotecnicosti3.azurewebsites.net/")
            };

            var response = client.GetAsync($"/pedido").Result;

            if (response.IsSuccessStatusCode)
            {
                var enderecoCompleto = response.Content.ReadAsStringAsync().Result;
                var obj = JsonConvert.DeserializeObject<List<Pedido>>(enderecoCompleto);


                foreach (var item in obj)
                {
                    var pedidoNum = Convert.ToInt64(item.Numero);
                    var pedidoData = Convert.ToDateTime(item.DataCriacao);
                    var pedidoNome = Convert.ToString(item.Cliente.Nome);
                    var pedidoStatus = Convert.ToString(item.Status);

                    if(item.ValorTotal.Length == 5)
                    {
                        var pedidoValorTotal = Convert.ToDecimal(item.ValorTotal)/10;

                        ItemsControlPedido.Items.Add(Tuple.Create(pedidoNum,
                            pedidoData,
                            pedidoNome,
                            pedidoStatus,
                            pedidoValorTotal
                            ));
                    }
                    if(item.ValorTotal.Length == 3 || item.ValorTotal.Length == 4)
                    {
                        var pedidoValorTotal = Convert.ToDecimal(item.ValorTotal);
                        ItemsControlPedido.Items.Add(Tuple.Create(pedidoNum,
                            pedidoData,
                            pedidoNome,
                            pedidoStatus,
                            pedidoValorTotal
                            ));
                    }
                }
            }
        }
    }
}
