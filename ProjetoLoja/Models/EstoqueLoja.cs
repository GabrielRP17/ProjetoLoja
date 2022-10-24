using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class EstoqueLoja
    {
        public int EstoqueId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
