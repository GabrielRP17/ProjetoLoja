using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class FornecedorLoja
    {
        public int ProdutoFornecedorId { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
        public int FornecedorId { get; set; }
        public int ProdutoLojaId { get; set; }
    }
}
