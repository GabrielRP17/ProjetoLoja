using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioEstoqueLoja : IRepositorioEstoqueLoja
    {
        public List<EstoqueLoja> BuscarTodos()
        {
            EstoqueLoja estoque = null;
            List<EstoqueLoja> ListEstoq = new List<EstoqueLoja>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select QuantidadeEstoque from EstoqueLoja", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    estoque = new EstoqueLoja();

                    // estoque.ProdutoId = Convert.ToInt32(dr["ProdutoId"].ToString());
                    estoque.QuantidadeEstoque = Convert.ToInt32(dr["QuantidadeEstoque"].ToString());

                    ListEstoq.Add(estoque);
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
            return ListEstoq;

        }
        public EstoqueLoja BuscarId(int Id)
        {
            EstoqueLoja estoque = new EstoqueLoja();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select  ProdutoId, QuantidadeEstoque from Estoque", _conn);
                cmd.Parameters.AddWithValue("@EstoqueId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    estoque.QuantidadeEstoque = Convert.ToInt32(dr["QuantidadeEstoque"].ToString());
                    //estoque.ProdutoId = Convert.ToInt32(dr["ProdutoId"].ToString());
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
            return estoque;
        }

        public void AlterarEstoque(EstoqueLoja estoque)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Estoque set ProdutoId=@ProdutoId, QuantidadeEstoque= @QuantidadeEstoque where EstoqueId=@EstoqueId", _conn);

                //cmd.Parameters.AddWithValue("ProdutoId", estoque.ProdutoId.ToString());
                cmd.Parameters.AddWithValue("QuantidadeEstoque", estoque.QuantidadeEstoque.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }

        }

        public void InserirEstoque(EstoqueLoja estoque)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Estoque (  QuantidadeEstoque) values (  @QuantidadeEstoque)", _conn);
                //cmd.Parameters.AddWithValue("@ProdutoId", estoque.ProdutoId.ToString());
                cmd.Parameters.AddWithValue("@QuantidadeEstoque", estoque.QuantidadeEstoque.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }


        }
    }
}
