using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioProdutoLoja
    {
        public List<ProdutoLoja> BuscarTodos();
        public ProdutoLoja BuscarId(int id);
        public void InserirProduto(ProdutoLoja produto);
        public void AlterarProduto(ProdutoLoja produto);
    }
}
