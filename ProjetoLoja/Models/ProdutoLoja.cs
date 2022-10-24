using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class ProdutoLoja
    {
        public int ProdutoLojaId { get; set; }
        public int EstoqueId { get; set; }
        public string NomeProdutoLoja { get; set; }
        public decimal preco { get; set; }
        //public Compra QuantidadeCompra { get; set; }
        //public Estoque QuantidadeEstoque { get; set; }
        //public ProdutoFornecedor DescricaoProduto { get; set; }
    }
}
