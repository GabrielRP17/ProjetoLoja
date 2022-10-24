using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Models
{
    public class Cartao
    {
        public int ClienteId { get; set; }
        public string NumeroCartao { get; set; }
        //public string CartaoDataValidade { get; set; }
        public int CodigoSeguranca { get; set; }
    }
}
