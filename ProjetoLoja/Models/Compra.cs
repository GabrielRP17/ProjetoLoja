using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class Compra
    {
        public int ClienteId { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeCompra { get; set; }
        public decimal ValorCompra { get; set; }


        //public Cliente ClienteNome { get; set; }
        //public HistoricoCompra DataCompra { get; set; }
        //public Produto NomeProduto { get; set; }
        //public  Produto Preco { get; set; }

    }
}
