using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioEstoqueFornecedor
    {
        public List<EstoqueFornecedor> BuscarTodos();
        public EstoqueFornecedor BuscarId(int Id);
        public void InserirEstoque(EstoqueFornecedor estoque);
        public void AlterarEstoque(EstoqueFornecedor estoque);
    }
}
