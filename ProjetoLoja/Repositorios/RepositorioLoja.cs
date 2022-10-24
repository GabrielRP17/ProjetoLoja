using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioLoja : IRepositorioLoja
    {
        public List<Lojas> BuscarTodos()
        {
            Lojas loja = null;
            List<Lojas> ListLoja = new List<Lojas>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ProdutoId, ClienteId from Lojas", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    loja = new Lojas();
                    loja.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    loja.ProdutoId = Convert.ToInt32(dr["ProdutoId"].ToString());

                    ListLoja.Add(loja);
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
            return ListLoja;
        }

        public Lojas BuscarId(int id)
        {
            Lojas loja = new Lojas();
            Cliente C = new Cliente();
            ProdutoLoja P = new ProdutoLoja();
            ProdutoFornecedor PF = new ProdutoFornecedor();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select loja.ClienteId p.NomeProduto, PF.DescricaoProduto, P.Preco, P.ProdutoId from Lojas L inner join Produto P on P.ProdutoId = L.ProdutoId inner join ProdutoFornecedor PF on PF.ProdutoId = L.ProdutoId where loja.ProdutoId= @loja.ProdutoId", _conn);
                cmd.Parameters.AddWithValue("@loja.ProdutoId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    C.ClienteNome = dr["C.ClienteNome"].ToString();
                    P.NomeProdutoLoja = dr["p.NomeProdutoLoja"].ToString();
                    PF.DescricaoProduto = dr["PF.DescricaoProduto"].ToString();
                    P.preco = Convert.ToDecimal(dr["P.Preco"].ToString());
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
            return loja;
        }

        public void AlterarLoja(Lojas loja)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Lojas Set ClienteId= @ClienteId, ProdutoId= @ProdutoId", _conn);

                cmd.Parameters.AddWithValue("@ClienteId", loja.ClienteId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoId", loja.ProdutoId.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }

        }

        public void InserirLoja(Lojas loja)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Lojas (ClienteId, ProdutoId)values(@ClienteId, @ProdutoId)", _conn);

                cmd.Parameters.AddWithValue("@Login", loja.ClienteId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoId", loja.ProdutoId.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
