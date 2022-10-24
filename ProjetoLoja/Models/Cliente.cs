using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string ClienteRG { get; set; }
        public string ClienteCPF { get; set; }
        public string ClienteEmail { get; set; }
        public string ClienteSenha { get; set; }


        //public Cartao cartao { get; set; }
        //public Compra compra { get; set; }
        //public LoginCliente login { get; set; }


    }
}
