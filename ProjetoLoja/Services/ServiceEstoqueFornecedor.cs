using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceEstoqueFornecedor : IServiceEstoqueFornecedor
    {
        public readonly IRepositorioEstoqueFornecedor _repositorio;
        public ServiceEstoqueFornecedor(IRepositorioEstoqueFornecedor repositorio)
        {
            _repositorio = repositorio;
        }

        public List<EstoqueFornecedor> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }
        public EstoqueFornecedor BuscarId(int Id)
        {
            return _repositorio.BuscarId(Id);
        }
        public void AlterarEstoque(EstoqueFornecedor estoque)
        {
            _repositorio.AlterarEstoque(estoque);
        }
        public void InserirEstoque(EstoqueFornecedor estoque)
        {
            _repositorio.InserirEstoque(estoque);
        }
    }
}
