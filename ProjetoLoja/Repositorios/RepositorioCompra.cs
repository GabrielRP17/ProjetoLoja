using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioCompra : IRepositorioCompra
    {
        public List<Compra> BuscarTodos()
        {
            Compra compra = null;
            List<Compra> ListCompra = new List<Compra>();

            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select QuantidadeCompra, ValorCompra, CompraId, ClienteId, ProdutoId from Compra ", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    compra = new Compra();
                    compra.CompraId = Convert.ToInt32(dr["CompraId"].ToString());
                    compra.ClienteId = Convert.ToInt32(dr["ClienteId"].ToString());
                    compra.ProdutoId = Convert.ToInt32(dr["ProdutoId"].ToString());

                    compra.QuantidadeCompra = Convert.ToInt32(dr["QuantidadeCompra"].ToString());
                    compra.ValorCompra = Convert.ToDecimal(dr["ValorCompra"].ToString());

                    ListCompra.Add(compra);
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
            return ListCompra;
        }
        public Compra BuscarId(int Id)
        {
            Compra compra = new Compra();
            HistoricoCompra H = new HistoricoCompra();
            Cliente Cli = new Cliente();
            ProdutoLoja P = new ProdutoLoja();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(" select Cli.ClienteNome, P.NomeProduto, p.Preco, c.QuantidadeCompra, C.ValorCompra, from Compra C inner join Produto P on P.ProdutoId = C.ProdutoId inner join Cliente Cli on Cli.ClienteId = P.ProdutoId inner join HistoricoCompra H on H.CompraId = C.CompraId where c.CompraId = @CompraId ", _conn);
                cmd.Parameters.AddWithValue("@CompraId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cli.ClienteNome = dr["ClienteNome"].ToString();
                    P.NomeProdutoLoja = dr["NomeProduto"].ToString();
                    P.preco = Convert.ToDecimal(dr["Preco"].ToString());
                    compra.QuantidadeCompra = Convert.ToInt32(dr["QuantidadeCompra"].ToString());
                    compra.ValorCompra = Convert.ToDecimal(dr["ValorCompra"].ToString());
                    //H.DataCompra = Convert.ToDateTime(dr["DataCompra"].ToString());

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
            return compra;
        }

        public void AlterarCompra(Compra compra)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Compra set QuantidadeCompra = @QuantidadeCompra, ValorCompra=@ValorCompra, ProdutoId = @ProdutoId, ClienteId =@ClienteId where CompraId= @CompraId", _conn);
                cmd.Parameters.AddWithValue("@ClienteId", compra.ClienteId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoId", compra.ProdutoId.ToString());
                cmd.Parameters.AddWithValue("@CompraId", compra.CompraId.ToString());
                cmd.Parameters.AddWithValue("@QuantidadeCompra", compra.QuantidadeCompra.ToString());
                cmd.Parameters.AddWithValue("@ValorCompra", compra.ValorCompra.ToString());
                //cmd.Parameters.AddWithValue("@DataCompra", compra.DataCompra.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public void InserirCompra(Compra compra)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Compra (QuantidadeCompra, ValorCompra, ClienteId, ProdutoId) values (@QuantidadeCompra, @ValorCompra, @ClienteId, @ProdutoId)", _conn);

                cmd.Parameters.AddWithValue("@QuantidadeCompra", compra.QuantidadeCompra.ToString());
                cmd.Parameters.AddWithValue("@ValorCompra", Convert.ToDecimal(compra.ValorCompra.ToString()));
                cmd.Parameters.AddWithValue("@ClienteId", compra.ClienteId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoId", compra.ProdutoId.ToString());
                // cmd.Parameters.AddWithValue("@DataCompra", Convert.ToDateTime( DateTime.Today));

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
