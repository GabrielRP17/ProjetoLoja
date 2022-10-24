using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IServiceFornecedorLoja
    {
        public List<FornecedorLoja> BuscarTodos();
        public FornecedorLoja BuscarId(int id);
        public void InserirFornecedoLoja(FornecedorLoja FL);
        public void AlterarFornecedorLoja(FornecedorLoja FL);


    }
}
