using Azure;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Controls;

namespace ProjetoDevSTi3.ViewModel
{
    public class ConsumedAPI
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
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public string RazaoSozial { get; set; }

        public string IdProduto { get; set; }
        public int Quantidade { get; set; }
        public int Parcela { get; set; }
        public string Codigo { get; set; }
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
