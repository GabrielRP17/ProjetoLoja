using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceProdutoFornecedor : IServiceProdutoFornecedor
    {
        public readonly IRepositorioProdutoFornecedor _repositorio;

        public ServiceProdutoFornecedor(IRepositorioProdutoFornecedor repositorio)
        {
            _repositorio = repositorio;
        }

        public List<ProdutoFornecedor> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public ProdutoFornecedor BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }

        public void AlterarProdutoFornecedor(ProdutoFornecedor ProdFornecedor)
        {
            _repositorio.AlterarProdutoFornecedor(ProdFornecedor);
        }

        public void InserirProdutoFornecedor(ProdutoFornecedor ProdFornecedor)
        {
            _repositorio.InserirProdutoFornecedor(ProdFornecedor);
        }
    }
}
