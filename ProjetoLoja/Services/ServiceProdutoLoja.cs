using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceProdutoLoja : IServiceProdutoLoja
    {
        public readonly IRepositorioProdutoLoja _repositorio;

        public ServiceProdutoLoja(IRepositorioProdutoLoja repositorio)
        {
            _repositorio = repositorio;
        }
        public List<ProdutoLoja> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }
        public ProdutoLoja BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }
        public void AlterarProduto(ProdutoLoja produto)
        {
            _repositorio.AlterarProduto(produto);
        }

        public void InserirProduto(ProdutoLoja produto)
        {
            _repositorio.InserirProduto(produto);
        }
    }
}
