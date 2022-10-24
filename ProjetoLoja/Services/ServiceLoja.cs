using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceLoja : IServiceLoja
    {
        public readonly IRepositorioLoja _repositorio;

        public ServiceLoja(IRepositorioLoja repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Lojas> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Lojas BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }

        public void AlterarLoja(Lojas loja)
        {
            _repositorio.AlterarLoja(loja);
        }

        public void InserirLoja(Lojas loja)
        {
            _repositorio.InserirLoja(loja);
        }
    }
}
