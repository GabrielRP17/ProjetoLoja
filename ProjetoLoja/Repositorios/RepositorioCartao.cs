using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioCartao : IRepositorioCartao
    {

        public List<Cartao> BuscarTodos()
        {
            Cartao cartao = null;
            List<Cartao> ListCartao = new List<Cartao>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId, NumeroCartao, CodigoSeguranca from Cartao", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cartao = new Cartao();
                    cartao.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cartao.NumeroCartao = dr["NumeroCartao"].ToString();
                   // cartao.CartaoDataValidade = dr["CartaoDataValidade"].ToString();
                    cartao.CodigoSeguranca = Convert.ToInt32(dr["CodigoSeguranca"].ToString());

                    ListCartao.Add(cartao);
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
            return ListCartao;
        }
        public Cartao BuscarId(int id)
        {
            Cartao cartao = new Cartao();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ClienteId, NumeroCartao, CodigoSeguranca from Cartao", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cartao.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    cartao.NumeroCartao = dr["NumeroCartao"].ToString();
                    //cartao.CartaoDataValidade = dr["CartaoDataValidade"].ToString().Replace("/", "");
                    cartao.CodigoSeguranca = Convert.ToInt32(dr["CodigoSeguranca"].ToString());
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
            return cartao;
        }

        public void AlterarCartao(Cartao cartao)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Cartao set NumeroCartao= @NumeroCartao, CodigoSeguranca=@CodigoSeguranca where ClienteId= @ClienteId ", _conn);

                cmd.Parameters.AddWithValue("@ClienteId", cartao.ClienteId);
                cmd.Parameters.AddWithValue("@NumeroCartao", cartao.NumeroCartao);
                //cmd.Parameters.AddWithValue("@CartaoDataValidade", cartao.CartaoDataValidade);
                cmd.Parameters.AddWithValue("@CodigoSeguranca", cartao.CodigoSeguranca);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public void InserirCartao(Cartao cartao)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Cartao (NumeroCartao, CodigoSeguranca)values(@NumeroCartao, @CodigoSeguranca)", _conn);
                cmd.Parameters.AddWithValue("@NumeroCartao", cartao.NumeroCartao.ToString());
                //cmd.Parameters.AddWithValue("@CartaoDataValidade", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@CodigoSeguranca", cartao.CodigoSeguranca.ToString());
                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
