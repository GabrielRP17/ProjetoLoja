using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceHistoricoCompra : IServiceHistoricoCompra
    {
        public readonly IRepositorioHistoricoCompra _repositorio;

        public ServiceHistoricoCompra(IRepositorioHistoricoCompra repositorio)
        {
            _repositorio = repositorio;
        }

        public List<HistoricoCompra> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public HistoricoCompra BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }

        public void AlterarHistoricoCompra(HistoricoCompra historico)
        {
            _repositorio.AlterarHistoricoCompra(historico);
        }

        public void InserirHistoricoCompra(HistoricoCompra historico)
        {
            _repositorio.InserirHistoricoCompra(historico);
        }


    }
}
