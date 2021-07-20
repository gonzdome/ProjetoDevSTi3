using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDevSTi3.ViewModel
{
    public class ItemsPedidoViewModel : PropertyChange
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public DateTime DataTotal { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
