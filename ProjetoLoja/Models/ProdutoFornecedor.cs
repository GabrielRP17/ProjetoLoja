using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class ProdutoFornecedor
    {
        public int FornecedorId { get; set; }
        public int ProdutoLojaId { get; set; }
        public decimal ValorProduto { get; set; }
        public string DescricaoProduto { get; set; }

        public Fornecedor fornecedor { get; set; }
        public ProdutoLoja produto { get; set; }
        
    }
}
