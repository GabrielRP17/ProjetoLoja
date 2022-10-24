using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceCompra : IServiceCompra
    {
        public readonly IRepositorioCompra _repositorio;

        public ServiceCompra(IRepositorioCompra repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Compra> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Compra BuscarId(int Id)
        {
            return _repositorio.BuscarId(Id);
        }

        public void AlterarCompra(Compra compra)
        {
            _repositorio.AlterarCompra(compra);
        }


        public void InserirCompra(Compra compra)
        {
            _repositorio.InserirCompra(compra);
        }
    }
}
