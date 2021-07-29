using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjetoDevSTi3.ViewModel
{
    public class PedidoViewModel : PropertyChange
    {

        private ObservableCollection<Pedido> _pedido;
        public ObservableCollection<Pedido> Pedido
        {
            get => _pedido;
            set
            {
                _pedido = value;
                OnPropertyChanged(nameof(Pedido));
            }
        }

        private ObservableCollection<List<Pedido>> _cliente;
        public ObservableCollection<List<Pedido>> Cliente
        {
            get => _cliente;
            set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }

        private ObservableCollection<List<Pedido>> _enderecoEntrega;
        public ObservableCollection<List<Pedido>> EnderecoEntrega
        {
            get => _enderecoEntrega;
            set
            {
                _enderecoEntrega = value;
                OnPropertyChanged(nameof(EnderecoEntrega));
            }
        }

        private ObservableCollection<List<Pedido>> _itens;
        public ObservableCollection<List<Pedido>> Itens
        {
            get => _itens;
            set
            {
                _itens = value;
                OnPropertyChanged(nameof(Itens));
            }
        }

        private ObservableCollection<List<Pedido>> _pagamento;
        public ObservableCollection<List<Pedido>> Pagamento
        {
            get => _pagamento;
            set
            {
                _pagamento = value;
                OnPropertyChanged(nameof(Pagamento));
            }
        }

        private string _id;
        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _numero;
        public string Numero
        {
            get => _numero;
            set
            {
                _numero = value;
                OnPropertyChanged(nameof(Numero));
            }
        }

        private string _dataCriacao;
        public string DataCriacao
        {
            get => _dataCriacao;
            set
            {
                _dataCriacao = value;
                OnPropertyChanged(nameof(DataCriacao));
            }
        }

        private string _nome;
        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string _valorTotal;
        public string ValorTotal
        {
            get => _valorTotal;
            set
            {
                _valorTotal = value;
                OnPropertyChanged(nameof(ValorTotal));
            }
        }


        private ObservableCollection<PedidoItemViewModel> _itensAdicionados;
        public ObservableCollection<PedidoItemViewModel> ItensAdicionados
        {
            get => _itensAdicionados;
            set
            {
                _itensAdicionados = value;
                OnPropertyChanged(nameof(ItensAdicionados));
            }
        }

    }
}
