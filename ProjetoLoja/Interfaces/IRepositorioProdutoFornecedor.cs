using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioProdutoFornecedor
    {
        public List<ProdutoFornecedor> BuscarTodos();
        public ProdutoFornecedor BuscarId(int id);
        public void InserirProdutoFornecedor(ProdutoFornecedor ProdFornecedor);
        public void AlterarProdutoFornecedor(ProdutoFornecedor ProdFornecedor);
    }
}
