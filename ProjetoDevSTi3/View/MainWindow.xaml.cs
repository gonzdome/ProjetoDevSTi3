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
        }

        private void InicializarUc(object sender)
        {
            if (sender is Button)
            {
                Conteudo.Content = new UcOrderDetails();
                BtnFechar.IsEnabled = true;
            }
        }
        private void FinalizarUc(object sender)
        {
            if (sender is Button)
            {
                Conteudo.Content = "";
                BtnFechar.IsEnabled = false;
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
                    var pedidoId = Convert.ToString(item.Id);
                    var pedidoNum = Convert.ToInt64(item.Numero);
                    var pedidoDataCriacao = Convert.ToDateTime(item.DataCriacao);
                    var pedidoDataAlteracao = Convert.ToDateTime(item.DataAlteracao);
                    var pedidoDesc = Convert.ToDecimal(item.Desconto);
                    var pedidoFrete = Convert.ToDecimal(item.Frete);
                    var pedidoSubTotal = Convert.ToDecimal(item.SubTotal);
                    var pedidoNome = Convert.ToString(item.Cliente.Nome);
                    var pedidoStatus = Convert.ToString(item.Status);

                    var pedidoDoc1 = Convert.ToString(item.Cliente.Cnpj);
                    var pedidoDoc2 = Convert.ToString(item.Cliente.Cpf);
                    var pedidoDataNasc = Convert.ToDateTime(item.Cliente.DataNascimento);
                    var pedidoEmail = Convert.ToString(item.Cliente.Email);

                    var pedidoEndereco = Convert.ToString(item.EnderecoEntrega.Endereco);
                    var pedidoNumEntrega = Convert.ToString(item.EnderecoEntrega.Numero);
                    var pedidoCep = Convert.ToString(item.EnderecoEntrega.Cep);
                    var pedidoBairro = Convert.ToString(item.EnderecoEntrega.Bairro);
                    var pedidoCidade = Convert.ToString(item.EnderecoEntrega.Cidade);
                    var pedidoEstado = Convert.ToString(item.EnderecoEntrega.Estado);
                    var pedidoComplemento = Convert.ToString(item.EnderecoEntrega.Complemento);
                    var pedidoReferencia = Convert.ToString(item.EnderecoEntrega.Referencia);

                    if (item.ValorTotal.Length == 5)
                    {
                        var pedidoValorTotal = Convert.ToDecimal(item.ValorTotal)/10;

                        ItemsControlPedido.Items.Add(Tuple.Create(pedidoNum,
                            pedidoDataCriacao,
                            pedidoNome,
                            pedidoStatus,
                            pedidoValorTotal
                            ));
                    }
                    if(item.ValorTotal.Length == 3 || item.ValorTotal.Length == 4)
                    {
                        var pedidoValorTotal = Convert.ToDecimal(item.ValorTotal);
                        ItemsControlPedido.Items.Add(Tuple.Create(pedidoNum,
                            pedidoDataCriacao,
                            pedidoNome,
                            pedidoStatus,
                            pedidoValorTotal
                            ));
                    }
                }
            }
        }
        private void ButtonNumero_Click(object sender, RoutedEventArgs e)
        {
            FinalizarUc(sender);
            InicializarUc(sender);
        }
    }
}
