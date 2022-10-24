using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioFornecedorLoja
    {
        public List<FornecedorLoja> BuscarTodos();
        public FornecedorLoja BuscarId(int Id);
        public void InserirFornecedorLoja(FornecedorLoja FL);
        public void AlterarFornecedorLoja(FornecedorLoja FL);


    }
}
