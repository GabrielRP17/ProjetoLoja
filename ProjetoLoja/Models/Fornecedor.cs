using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorCNPJ { get; set; }
        public string FornecedorEndereco { get; set; }
        public string FornecedorCEP { get; set; }
        public string FornecedorCidade { get; set; }
        public string FornecedorEstado { get; set; }

        //public ProdutoFornecedor ProdFornecedor { get; set; }

    }
}
