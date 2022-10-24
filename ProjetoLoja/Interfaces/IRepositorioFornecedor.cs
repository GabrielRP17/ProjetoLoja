using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioFornecedor
    {
        public List<Fornecedor> BuscarTodos();
        public Fornecedor BuscarId(int Id);
        public void InserirFornecedor(Fornecedor fornecedor);
        public void AlterarFornecedor(Fornecedor fornecedor);

    }
}
