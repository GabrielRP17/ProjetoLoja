using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IServiceEstoqueLoja
    {
        public List<EstoqueLoja> BuscarTodos();
        public EstoqueLoja BuscarId(int Id);
        public void InserirEstoque(EstoqueLoja estoque);
        public void AlterarEstoque(EstoqueLoja estoque);
    }
}
