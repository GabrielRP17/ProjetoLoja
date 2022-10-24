using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class EstoqueFornecedor
    {
        public int EstoqueFornecedorId { get; set; }
        public int ProdutoFornecedorId { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
