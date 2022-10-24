using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceEstoqueLoja : IServiceEstoqueLoja
    {
        public readonly IRepositorioEstoqueLoja _repositorio;

        public ServiceEstoqueLoja(IRepositorioEstoqueLoja repositorio)
        {
            _repositorio = repositorio;
        }

        public List<EstoqueLoja> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public EstoqueLoja BuscarId(int Id)
        {
            return _repositorio.BuscarId(Id);
        }

        public void AlterarEstoque(EstoqueLoja estoque)
        {
            _repositorio.AlterarEstoque(estoque);
        }

        public void InserirEstoque(EstoqueLoja estoque)
        {
            _repositorio.InserirEstoque(estoque);
        }
    }
}
