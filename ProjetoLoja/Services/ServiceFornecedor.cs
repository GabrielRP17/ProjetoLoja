using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceFornecedor : IServiceFornecedor
    {
        public readonly IRepositorioFornecedor _repositorio;

        public ServiceFornecedor(IRepositorioFornecedor repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Fornecedor> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public Fornecedor BuscarId(int Id)
        {
            return _repositorio.BuscarId(Id);
        }

        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            _repositorio.AlterarFornecedor(fornecedor);
        }

        public void InserirFornecedor(Fornecedor fornecedor)
        {
            _repositorio.InserirFornecedor(fornecedor);
        }

        private bool ValidaDados(Fornecedor fornecedor)
        {
            bool valida = true;

            if (fornecedor.FornecedorEndereco.Length > 5)
            {
                valida = false;
            }
            //if (fornecedor. .Length > 10)
            //{
            //	valida = false;
            //}
            else if (!ValidaCEP(fornecedor.FornecedorCEP))
            {
                valida = false;
            }
            return valida;
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string Digito;
            string tempCnpj;


            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)

                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;
            Digito = resto.ToString();
            tempCnpj = tempCnpj + Digito;
            soma = 0;




            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;
            Digito = Digito + resto.ToString();


            return cnpj.EndsWith(Digito);





        }

        private bool ValidaCEP(string cep)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9{5}-[0,9]{3}"));
        }
    }

}

