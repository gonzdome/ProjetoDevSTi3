namespace ProjetoDevSTi3.ViewModel
{
    public class Pedido
    {
        public string Id { get; set; }
        public string Numero { get; set; }
        public string DataCriacao { get; set; }
        public string DataAlteracao { get; set; }
        public string Status { get; set; }
        public string Desconto { get; set; }
        public string Frete { get; set; }
        public string SubTotal { get; set; }
        public string ValorTotal { get; set; }

        public Cliente Cliente { get; set; }
        public EnderecoEntrega EnderecoEntrega { get; set; }
        public Itens Itens { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
