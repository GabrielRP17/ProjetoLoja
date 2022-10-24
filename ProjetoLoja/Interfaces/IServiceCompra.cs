using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IServiceCompra
    {
        public List<Compra> BuscarTodos();
        public Compra BuscarId(int Id);
        public void InserirCompra(Compra compra);
        public void AlterarCompra(Compra compra);
    }
}
