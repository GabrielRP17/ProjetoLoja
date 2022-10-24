using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceFornecedorLoja : IServiceFornecedorLoja
    {
        public readonly IRepositorioFornecedorLoja _repositorio;
        public ServiceFornecedorLoja(IRepositorioFornecedorLoja repositorio)
        {
            _repositorio = repositorio;
        }
        public List<FornecedorLoja> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }
        public FornecedorLoja BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }
        public void AlterarFornecedorLoja(FornecedorLoja FL)
        {
            _repositorio.AlterarFornecedorLoja(FL);
        }
        public void InserirFornecedoLoja(FornecedorLoja FL)
        {
            _repositorio.InserirFornecedorLoja(FL);
        }
    }
}
