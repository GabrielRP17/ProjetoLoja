
using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public List<Cliente> BuscarTodos()
        {
            Cliente cli = null;
            List<Cliente> ListCli = new List<Cliente>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("Select ClienteId, ClienteNome, ClienteRG, ClienteCPF, ClienteEmail, ClienteSenha from Cliente", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli = new Cliente();
                    cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cli.ClienteNome = dr["ClienteNome"].ToString();
                    cli.ClienteRG = dr["ClienteRG"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteCPF = dr["ClienteCPF"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteEmail = dr["ClienteEmail"].ToString();
                    cli.ClienteSenha = dr["ClienteSenha"].ToString();

                    ListCli.Add(cli);
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return ListCli;
        }

        public Cliente BuscarCliente(string email, string senha)
        {
            Cliente cliente = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteEmail, ClienteSenha, ClienteNome, ClienteCPF,ClienteRG, ClienteId from Cliente  Where ClienteEmail = @ClienteEmail and ClienteSenha=@ClienteSenha", _conn);
                cmd.Parameters.AddWithValue("@ClienteEmail", email);
                cmd.Parameters.AddWithValue("@ClienteSenha", senha);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cliente = new Cliente();
                    cliente.ClienteCPF = dr["ClienteCPF"].ToString().Replace(".", "").Replace("-", "");
                    cliente.ClienteEmail = dr["ClienteEmail"].ToString();
                    cliente.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cliente.ClienteNome = dr["ClienteNome"].ToString();
                    cliente.ClienteRG = dr["ClienteRG"].ToString().Replace(".", "").Replace("-", "");
                    cliente.ClienteSenha = dr["ClienteSenha"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return cliente;
        }

        public Cliente BuscarId(int id)
        {
            Cliente cli = new Cliente();
            //Cartao C = new Cartao();
            //Compra Co = new Compra();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                //SqlCommand cmd = new SqlCommand("SELECT  CLI.ClienteNome, CLI.ClienteCPF, l.Email , L.senha, c.NumeroCartao from Cliente Cli inner join LoginCliente L ON CLI.clienteId = L.ClienteId inner join cartao C on C.ClienteId = C.NumeroCartao From Cliente ", _conn);
                SqlCommand cmd = new SqlCommand("select ClienteId, ClienteNome, ClienteRG, ClienteCPF, ClienteEmail, ClienteSenha from Cliente", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cli.ClienteNome = dr["ClienteNome"].ToString();
                    cli.ClienteRG = dr["ClienteRG"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteCPF = dr["ClienteCPF"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteEmail = dr["ClienteEmail"].ToString();
                    cli.ClienteSenha = dr["ClienteSenha"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return cli;
        }
        public Cliente BuscarCPF(string cpf)
        {
            Cliente cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId, ClienteNome, ClienteRG, ClienteCPF, ClienteEmail, ClienteSenha from Cliente", _conn);
                cmd.Parameters.AddWithValue("@ClienteCPF", cpf);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cli.ClienteNome = dr["ClienteNome"].ToString();
                    cli.ClienteRG = dr["ClienteRG"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteCPF = dr["ClienteCPF"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteEmail = dr["ClienteEmail"].ToString();
                    cli.ClienteSenha = dr["ClienteSenha"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return cli;
        }

        public Cliente BuscarRG(string rg)
        {
            Cliente cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId, ClienteNome, ClienteRG, ClienteCPF, ClienteEmail, ClienteSenha from Cliente", _conn);
                cmd.Parameters.AddWithValue("@ClienteRG", rg);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cli.ClienteNome = dr["ClienteNome"].ToString();
                    cli.ClienteRG = dr["ClienteRG"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteCPF = dr["ClienteCPF"].ToString().Replace(".", "").Replace("-", "");
                    cli.ClienteEmail = dr["ClienteEmail"].ToString();
                    cli.ClienteSenha = dr["ClienteSenha"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return cli;
        }

        public void AlterarCliente(Cliente cli)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Cliente set ClienteNome = @ClienteNome, ClienteRG = @ClienteRG, ClienteCPF = @ClienteCPF, ClienteEmail = @ClienteEmail, ClienteSenha=@ClienteSenha where ClienteId = @ClienteId", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", cli.ClienteId);
                cmd.Parameters.AddWithValue("@ClienteNome", cli.ClienteNome);
                cmd.Parameters.AddWithValue("@ClienteRG", cli.ClienteRG.ToString().Replace(".", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@ClienteCPF", cli.ClienteCPF.ToString().Replace(".", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@ClienteEmail", cli.ClienteEmail);
                cmd.Parameters.AddWithValue("@ClienteSenha", cli.ClienteSenha);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
        public void InserirCliente(Cliente cli)
        {
            //Criando uma conexão
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                //Abrindo a conexão
                _conn.Open();
                //Iniciando o comando SQL
                SqlCommand cmd = new SqlCommand("insert into Cliente (ClienteNome, ClienteRG, ClienteCPF, ClienteId, ClienteEmail, ClienteSenha) values (@ClienteNome, @ClienteRG, @ClienteCPF, @ClienteId, @ClienteEmail, @ClienteSenha)", _conn);

                //Adicionando os parâmetros de entrada
                cmd.Parameters.AddWithValue("@ClienteId", cli.ClienteId.ToString());
                cmd.Parameters.AddWithValue("@ClienteNome", cli.ClienteNome.ToString());
                cmd.Parameters.AddWithValue("@ClienteRG", cli.ClienteRG.ToString().Replace(".", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@ClienteCPF", cli.ClienteCPF.ToString().Replace(".", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@ClienteEmail", cli.ClienteEmail.ToString());
                cmd.Parameters.AddWithValue("@ClienteSenha", cli.ClienteSenha.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public int VerificarLogin(string Email, string senha)
        {
            Cliente cli = new Cliente();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId from Cliente cli where cli.ClienteEmail = @ClienteEmail and cli.ClienteSenha = @ClienteSenha", _conn);
                cmd.Parameters.AddWithValue("@ClienteEmail", Email);
                cmd.Parameters.AddWithValue("@ClienteSenha", senha);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }

            return 1;
        }



        //public void InserirLogin(Cliente login)
        //{
        //    SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

        //    try
        //    {
        //        _conn.Open();
        //        SqlCommand cmd = new SqlCommand("insert into LoginCliente (Email , Senha) values (@Email, @Senha)", _conn);
        //        cmd.Parameters.AddWithValue("@Email", login.ClienteEmail.ToString());
        //        cmd.Parameters.AddWithValue("@Senha", login.ClienteSenha.ToString());

        //        cmd.ExecuteNonQuery();

        //    }
        //    finally
        //    {
        //        _conn.Close();
        //    }
        //}

        //public void AlterarLogin(Cliente login)
        //{
        //    SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

        //    try
        //    {
        //        _conn.Open();
        //        SqlCommand cmd = new SqlCommand("update Login set ClienteId= @ClienteId, Email= @Email, Senha=@Senha where LoginId=@LoginId", _conn);
        //        //cmd.Parameters.AddWithValue("@LoginId", login.LoginId);
        //        //cmd.Parameters.AddWithValue("@ClienteId", login.ClienteId);
        //        cmd.Parameters.AddWithValue("@Email", login.ClienteEmail);
        //        cmd.Parameters.AddWithValue("@Senha", login.ClienteSenha);

        //        cmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        _conn.Close();
        //    }
        //}
    }
}
