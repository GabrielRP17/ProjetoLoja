using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IServiceCartao
    {
        public List<Cartao> BuscarTodos();
        public Cartao BuscarId(int id);
        public void InserirCartao(Cartao cartao);
        public void AlterarCartao(Cartao cartao);
    }
}
