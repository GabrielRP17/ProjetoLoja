using Microsoft.Azure.Storage.Shared.Protocol;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceCartao : IServiceCartao
    {
        public readonly IRepositorioCartao _repositorio;

        public ServiceCartao(IRepositorioCartao repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Cartao> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Cartao BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }

        public void AlterarCartao(Cartao cartao)
        {
            _repositorio.AlterarCartao(cartao);
        }

        public void InserirCartao(Cartao cartao)
        {


            //string Card = IsValidLuhnn()
            //cartao.NumeroCartao = Card; 


            //string data = FormatoData("");
            //cartao.CartaoDataValidade = data;


            _repositorio.InserirCartao(cartao);
        }



        public static bool IsValidLuhnn(string val)
        {
            int currentDigit;
            int ValSum = 0;
            int currentProcNum = 0;

            for (int i = val.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(val.Substring(i, 1), out currentDigit))
                    return false;

                currentProcNum = currentDigit << (1 + i & 1);

                ValSum += (currentProcNum > 9 ? currentProcNum - 9 : currentProcNum);
            }
            return (ValSum > 0 && ValSum % 10 == 0);

        }

        public static bool isValidCreditCardNumber(string cc)
        {

            if (cc.All(Char.IsDigit) == false)
            {
                return false;
            }

            if (12 > cc.Length || cc.Length > 19)
            {
                return false;
            }

            return IsValidLuhnn(cc);

        }

        public void ValidarData(string valida)
        {
            DateTime dataValida;

            if (DateTime.TryParse("Valor Data", out dataValida))
            {
            }
        }

        //public string FormatoData(string data)
        //{
        //    var cartao = new Cartao();
        //    data = DateTime.Now.ToString(cartao.CartaoDataValidade).Replace("-", "/");

        //    return data;
        //}
    }
}
