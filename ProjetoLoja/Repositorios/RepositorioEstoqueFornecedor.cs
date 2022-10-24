using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{

    


    public class RepositorioEstoqueFornecedor : IRepositorioEstoqueFornecedor
    {
        public List<EstoqueFornecedor> BuscarTodos()
        {
            EstoqueFornecedor EF = null;
            List<EstoqueFornecedor> ListEF = new List<EstoqueFornecedor>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select EstoqueFornecedorId, ProdutoFornecedorId, QuantidadeEstoque from EstoqueFornecedor", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EF = new EstoqueFornecedor();
                    EF.EstoqueFornecedorId = Convert.ToInt32(dr["EstoqueFornecedorId"].ToString());
                   // EF.ProdutoFornecedorId = Convert.ToInt32(dr["ProdutoFornecedorId"].ToString());
                    EF.QuantidadeEstoque = Convert.ToInt32(dr["QuantidadeEstoque"].ToString());

                    ListEF.Add(EF);
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
            return ListEF;
        }

        public EstoqueFornecedor BuscarId(int Id)
        {
            EstoqueFornecedor EF = new EstoqueFornecedor();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select EstoqueFornecedorId, ProdutoFornecedorId, QuantidadeEstoque from EstoqueFornecedor", _conn);
                cmd.Parameters.AddWithValue("@EstoqueFornecedorId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EF.EstoqueFornecedorId = Convert.ToInt32(dr["EstoqueFornecedorId"].ToString());
                    EF.ProdutoFornecedorId = Convert.ToInt32(dr["ProdutoFornecedorId"].ToString());
                    EF.QuantidadeEstoque = Convert.ToInt32(dr["QuantidadeEstoque"].ToString());
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
            return EF;
        }

        public void AlterarEstoque(EstoqueFornecedor estoque)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update EstoqueFornecedor set ProdutoFornecedorId= @ProdutoFornecedorId, QuantidadeEstoque =@QuantidadeEstoque where EstoqueFornecedorId= @EstoqueFornecedorId", _conn);
                cmd.Parameters.AddWithValue("@ProdutoFornecedorId", estoque.ProdutoFornecedorId.ToString());
                cmd.Parameters.AddWithValue("@QuantidadeEstoque", estoque.QuantidadeEstoque.ToString());
                cmd.Parameters.AddWithValue("@EstoqueFornecedorId", estoque.EstoqueFornecedorId.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public void InserirEstoque(EstoqueFornecedor estoque)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into EstoqueFornecedor ( QuantidadeEstoque, ProdutoFornecedorId, EstoqueFornecedorId) values ( @QuantidadeEstoque, @ProdutoFornecedorId, @EstoqueFornecedorId)", _conn);
                cmd.Parameters.AddWithValue("@EstoqueFornecedorId", estoque.EstoqueFornecedorId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoFornecedorId", estoque.ProdutoFornecedorId.ToString());
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
