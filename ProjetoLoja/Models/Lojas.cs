    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class Lojas
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoFornecedor DescricaoProduto { get; set; }  
        public ProdutoLoja NomeProduto { get; set; }
        public ProdutoLoja Preco { get; set; }

    }
}
