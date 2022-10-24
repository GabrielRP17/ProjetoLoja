using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioProdutoFornecedor : IRepositorioProdutoFornecedor
    {
        public List<ProdutoFornecedor> BuscarTodos()
        {
            ProdutoFornecedor PF = new ProdutoFornecedor();
            ProdutoLoja P = new ProdutoLoja();
            Cliente Cli = new Cliente();
            List<ProdutoFornecedor> ListPF = new List<ProdutoFornecedor>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select FornecedorId, ProdutoLojaId,ValorProduto, DescricaoProduto from ProdutoFornecedor", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PF = new ProdutoFornecedor();
                    PF.FornecedorId = Convert.ToInt32(dr["FornecedorId"].ToString());
                    PF.ProdutoLojaId = Convert.ToInt32(dr["ProdutoLojaId"].ToString());
                    PF.ValorProduto = Convert.ToDecimal(dr["ValorProduto"].ToString());
                    PF.DescricaoProduto = dr["DescricaoProduto"].ToString();

                    ListPF.Add(PF);

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
            return ListPF;

        }

        public ProdutoFornecedor BuscarId(int id)
        {
            ProdutoLoja Prod = new ProdutoLoja();
            Cliente Cli = new Cliente();
            ProdutoFornecedor PF = new ProdutoFornecedor();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand("select C.ClienteNome, P.NomeProduto, P.Preco, PF.DescricaoProduto from ProdutoFornecedor PF INNER JOIN Produto P ON PF.FornecedorId  = P.ProdutoId Inner join Cliente C on C.clienteId = PF.FornecedorId ", _conn);
                cmd.Parameters.AddWithValue("@ProdutoFornecedor", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    Prod.NomeProdutoLoja = dr["NomeProduto"].ToString();
                    Prod.preco = Convert.ToDecimal(dr["Preco"].ToString());
                    PF.DescricaoProduto = dr["DescricaoProduto"].ToString();
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
            return PF;
        }

        public void AlterarProdutoFornecedor(ProdutoFornecedor ProdFornecedor)
        {
            throw new NotImplementedException();
        }

        public void InserirProdutoFornecedor(ProdutoFornecedor ProdFornecedor)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into ProdutoFornecedor (ValorProduto, DescricaoProduto)values(@ValorProduto, @DescricaoProduto)", _conn);

                cmd.Parameters.AddWithValue("@ValorProduto", ProdFornecedor.ValorProduto.ToString());
                cmd.Parameters.AddWithValue("@DescricaoProduto", ProdFornecedor.DescricaoProduto.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
