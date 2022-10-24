using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioHistoricoCompra
    {
        public List<HistoricoCompra> BuscarTodos();
        public HistoricoCompra BuscarId(int id);
        public void InserirHistoricoCompra(HistoricoCompra historico);
        public void AlterarHistoricoCompra(HistoricoCompra historico);
    }
}
