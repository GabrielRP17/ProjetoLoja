using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoLoja.Services
{
    public class ServiceCliente : IServiceCliente
    {
        public readonly IRepositorioCliente _repositorio;

        public ServiceCliente(IRepositorioCliente repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Cliente> BuscarTodos()
        {
            return _repositorio.BuscarTodos();

        }
        public Cliente BuscarId(int id)
        {
            return _repositorio.BuscarId(id);
        }

        public Cliente BuscarCliente(string email, string senha)
        {
            string has = GerarMD5Hash(senha);
            senha = has;

            return _repositorio.BuscarCliente(email, senha);
        }

        public void AlterarCliente(Cliente cli)
        {
            string has = GerarMD5Hash(cli.ClienteSenha);
            cli.ClienteSenha = has;
            _repositorio.AlterarCliente(cli);
        }

        public void InserirCliente(Cliente cli)
        {
            string has = GerarMD5Hash(cli.ClienteSenha);
            cli.ClienteSenha = has;
            _repositorio.InserirCliente(cli);
        }

        public Cliente BuscarCPF(string cpf)
        {
            return _repositorio.BuscarCPF(cpf);

            //if (validaCPF(cpf))
            //{
            //    return null;
            //}
            //else
            //{
            //    return null;
            //}

        }

        public Cliente BuscarRG(string rg)
        {
            return _repositorio.BuscarRG(rg);
        }

        private bool validaDados(Cliente cli)
        {
            bool valida = true;

            if (cli.ClienteNome == string.Empty)
            {
                valida = false;
            }

            return valida;
        }

        private bool validaCPF(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, };
            string TempCpf;
            string digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCpf = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            TempCpf = TempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return CPF.EndsWith(digito);
        }

        private bool validarRG(string RG)
        {
            try
            {

                RG = RG.Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "").Trim();
                int n1 = int.Parse(RG.Substring(0, 1));
                int n2 = int.Parse(RG.Substring(1, 1));
                int n3 = int.Parse(RG.Substring(2, 1));
                int n4 = int.Parse(RG.Substring(3, 1));
                int n5 = int.Parse(RG.Substring(4, 1));
                int n6 = int.Parse(RG.Substring(5, 1));
                int n7 = int.Parse(RG.Substring(6, 1));
                int n8 = int.Parse(RG.Substring(7, 1));

                string Dv = RG.Substring(8, 1);

                int soma = n1 * 2 + n2 * 3 + n3 * 4 + n4 * 5 + n5 * 6 + n6 * 7 + n7 * 8 + n8 * 9;

                string DigitoVerificador = Convert.ToString(soma % 11);

                if (DigitoVerificador == "1")
                {
                    DigitoVerificador = "X";
                }
                else if (DigitoVerificador == "0")
                {
                    DigitoVerificador = "0";
                }
                else
                {
                    DigitoVerificador = (11 - int.Parse(DigitoVerificador)).ToString();
                }

                if (DigitoVerificador == Dv)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }

        private bool validaEmail(string email)
        {

            string StrRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
               @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
               @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex re = new Regex(StrRegex);

            if (re.IsMatch(email))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public int VerificarLogin(string email, string senha)
        {
            string senhaCriptografada = GerarMD5Hash(senha);
            return _repositorio.VerificarLogin(email, senhaCriptografada);
        }

        public static string GerarMD5Hash(string texto)
        {
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] ValorHash = MD5Provider.ComputeHash(Encoding.Default.GetBytes(texto));
            StringBuilder str = new StringBuilder();
            for (int contador = 0; contador < ValorHash.Length; contador++)
            {
                str.Append(ValorHash[contador].ToString("x2"));
            }
            return str.ToString();
        }

        static bool VerificarMD5Hash(string texto, string ValorHashArmazenamento)
        {
            string ValorHash2 = GerarMD5Hash(texto);
            StringComparer strcomparer = StringComparer.OrdinalIgnoreCase;
            if (strcomparer.Compare(ValorHash2, ValorHashArmazenamento).Equals(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
