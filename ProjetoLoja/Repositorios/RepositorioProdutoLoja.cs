using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioProdutoLoja : IRepositorioProdutoLoja
    {
        public List<ProdutoLoja> BuscarTodos()
        {
            ProdutoLoja produto = null;
            List<ProdutoLoja> ListProd = new List<ProdutoLoja>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select NomeProdutoLoja, Preco, EstoqueId, ProdutoLojaId from ProdutoLoja", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    produto = new ProdutoLoja();
                    //cli.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    produto.EstoqueId = Convert.ToInt32(dr["EstoqueId"].ToString());
                    produto.NomeProdutoLoja = dr["NomeProdutoLoja"].ToString();
                    produto.preco = Convert.ToDecimal(dr["Preco"].ToString());
                    produto.ProdutoLojaId = Convert.ToInt32(dr["ProdutoLojaId"].ToString());

                    ListProd.Add(produto);
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
            return ListProd;
        }

        public ProdutoLoja BuscarId(int id)
        {
            ProdutoLoja prod = new ProdutoLoja();
            Compra C = new Compra();
            EstoqueLoja E = new EstoqueLoja();
            ProdutoFornecedor PF = new ProdutoFornecedor();
            ProdutoFornecedor fornecedor = new ProdutoFornecedor();
            EstoqueLoja estoque = new EstoqueLoja();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select P.NomeProdutoLoja, P.Preco , C.QuantidadeCompra, E.QuantidadeEstoque, PF.DescricaoProduto from ProdutoLoja P inner join Compra C on P.ProdutoLojaId = C.ProdutoLojaId inner join Estoque E on P.ProdutoLojaId = E.ProdutoLojaId inner join ProdutoFornecedor PF on P.ProdutoId = PF.ProdutoLojaId where P.ProdutoLojaId= @ProdutoLojaId", _conn);
                cmd.Parameters.AddWithValue("@ProdutoId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    prod.ProdutoLojaId = Convert.ToInt32(dr["P.ProdutoLojaId"].ToString());
                    prod.NomeProdutoLoja = dr["P.NomeProdutoLoja"].ToString();
                    prod.preco = Convert.ToDecimal(dr["P.Preco"].ToString());
                    C.QuantidadeCompra = Convert.ToInt32(dr["C.QuantidadeCompra"].ToString());
                    E.QuantidadeEstoque = Convert.ToInt32(dr["E.QuantidadeEstoque"].ToString());
                    PF.DescricaoProduto = dr["PF.DescricaoProduto"].ToString();

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
            return prod;
        }

        public void AlterarProduto(ProdutoLoja produto)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(" update ProdutoLoja set NomeProdutoLoja  = @NomeProdutoLoja, Preco= @Preco, EstoqueId= @EstoqueId where ProdutoLojaId=@ProdutoLojaId", _conn);
                cmd.Parameters.AddWithValue("@NomeProduto", produto.NomeProdutoLoja.ToString());
                cmd.Parameters.AddWithValue("@Preco", produto.preco.ToString());
                cmd.Parameters.AddWithValue("@ProdutoLojaId", produto.ProdutoLojaId.ToString());
                cmd.Parameters.AddWithValue("@EstoqueId", produto.EstoqueId.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public void InserirProduto(ProdutoLoja produto)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into ProdutoLoja (NomeProdutoLoja, Preco)values(@NomeProdutoLoja, @Preco)", _conn);

                cmd.Parameters.AddWithValue("@NomeProdutoLoja", produto.NomeProdutoLoja.ToString());
                cmd.Parameters.AddWithValue("@Preco", produto.preco.ToString());
                //cmd.Parameters.AddWithValue("@ProdutoId", produto.ProdutoId.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
