using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioHistoricoCompra : IRepositorioHistoricoCompra
    {
        public List<HistoricoCompra> BuscarTodos()
        {
            HistoricoCompra historico = null;
            Compra compra = null;

            List<HistoricoCompra> ListHistorico = new List<HistoricoCompra>();
            List<Compra> listCompra = new List<Compra>(); 
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select CompraId, Estoqueid from HistoricoCompra", _conn);

                compra.CompraId = Convert.ToInt32(dr["CompraId"].ToString());
                //historico.CompraId = Convert.ToInt32(dr["CompraId"].ToString());
                historico.EstoqueId = Convert.ToInt32(dr["EstoqueId"].ToString());

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
            return ListHistorico;

        }

        public HistoricoCompra BuscarId(int id)
        {
            HistoricoCompra historico = new HistoricoCompra();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select Compra.CompraId, estoque.EstoqueId from Compra compra inner join HistoricoCompra historico on compra.CompraId = His.CompraId inner join Estoque Estoq on estoque.Estoque= historico=EstoqueId where  CompraId = @CompraId", _conn);
                cmd.Parameters.AddWithValue("CompraId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    historico.CompraId = Convert.ToInt32(dr["CompraId"].ToString());
                    historico.EstoqueId = Convert.ToInt32(dr["EstoqueId"].ToString());
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
            return historico;
        }

        public void AlterarHistoricoCompra(HistoricoCompra historico)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update HistoricoCompra set CompraId ", _conn);
            }
            finally
            {

            }
        }

        public void InserirHistoricoCompra(HistoricoCompra historico)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into HistoricoCompra (CompraId, EstoqueId) values (@CompraId, @EstoqueId)", _conn);
                cmd.Parameters.AddWithValue("@CompraId", historico.CompraId.ToString());
                cmd.Parameters.AddWithValue("@EstoqueId", historico.EstoqueId.ToString());

                cmd.ExecuteNonQuery();

            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
