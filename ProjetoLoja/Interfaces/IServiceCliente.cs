using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Interfaces
{
    public interface IServiceCliente
    {
        public List<Cliente> BuscarTodos();
        public int VerificarLogin(string email, string senha);
        public Cliente BuscarId(int id);
        public Cliente BuscarCPF(string cpf);
        public Cliente BuscarRG(string rg);
        public Cliente BuscarCliente(string email, string senha);
        public void InserirCliente(Cliente cli);
        public void AlterarCliente(Cliente cli);

    }
}
