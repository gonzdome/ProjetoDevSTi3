using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDevSTi3.ViewModel
{
    public class UcPedidoViewModel : PropertyChange
    {
        public long Id { get; set; }
        public long Numero { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Status { get; set; }
        public decimal Desconto { get; set; }
        public decimal Frete { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }


        public string Nome { get; set; }
        public int Documento { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        
        public string Endereco { get; set; }
        public int NumeroRua { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
    }
}
