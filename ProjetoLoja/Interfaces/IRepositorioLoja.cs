using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IRepositorioLoja
    {
        public List<Lojas> BuscarTodos();
        public Lojas BuscarId(int id);
        public void InserirLoja(Lojas loja);
        public void AlterarLoja(Lojas loja);

    }
}
