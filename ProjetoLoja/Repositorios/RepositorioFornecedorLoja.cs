using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioFornecedorLoja : IRepositorioFornecedorLoja
    {
        public List<FornecedorLoja> BuscarTodos()
        {
            FornecedorLoja fl = null;
            List<FornecedorLoja> ListFL = new List<FornecedorLoja>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ProdutoFornecedorId, NomeProduto, Valor, FornecedorId, ProdutoLojaId from FornecedorLoja", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fl = new FornecedorLoja();
                    fl.ProdutoFornecedorId = Convert.ToInt32(dr["ProdutoFornecedorId"].ToString());
                    fl.NomeProduto = dr["NomeProduto"].ToString();
                    fl.Valor = Convert.ToDecimal(dr["Valor"].ToString());
                    fl.FornecedorId = Convert.ToInt32(dr["FornecedorId"].ToString());
                    fl.ProdutoLojaId = Convert.ToInt32(dr["ProdutoLojaId"].ToString());

                    ListFL.Add(fl);
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
            return ListFL;
        }
        public FornecedorLoja BuscarId(int Id)
        {
            FornecedorLoja FL = new FornecedorLoja();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select ProdutoFonecedorId, NomeProduto, Valor, FornecedorId, ProdutoLojaId from FornecedorLoja", _conn);
                cmd.Parameters.AddWithValue("@FornecedorLojaId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FL.ProdutoFornecedorId = Convert.ToInt32(dr["ProdutoFornecedorId"].ToString());
                    FL.NomeProduto = dr["NomeProduto"].ToString();
                    FL.Valor = Convert.ToDecimal(dr["Valor"].ToString());
                    FL.FornecedorId = Convert.ToInt32(dr["FornecedorId"].ToString());
                    FL.ProdutoLojaId = Convert.ToInt32(dr["ProdutoLojaId"].ToString());
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
            return FL;
        }
        public void AlterarFornecedorLoja(FornecedorLoja FL)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update FornecedorLoja set ProdutoFonecedorId = @ProdutoFonecedorId, NomeProduto = @NomeProduto, Valor = @Valor, FornecedorId= @FornecedorId, ProdutoLojaId= @ProdutoLojaId ", _conn);
                cmd.Parameters.AddWithValue("@ProdutoFornecedorId", FL.ProdutoFornecedorId.ToString());
                cmd.Parameters.AddWithValue("@NomeProduto", FL.NomeProduto.ToString());
                cmd.Parameters.AddWithValue("@Valor", FL.Valor.ToString());
                cmd.Parameters.AddWithValue("@FornecedorId", FL.ToString());
                cmd.Parameters.AddWithValue("ProdutoLojaId", FL.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
        public void InserirFornecedorLoja(FornecedorLoja FL)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into FornecedorLoja ( NomeProduto, Valor, FornecedorId, ProdutoLojaId) values ( @NomeProduto, @Valor, @FornecedorId, @ProdutoLojaId) ", _conn);

                //cmd.Parameters.AddWithValue("@ProdutoFornecedorId", FL.ProdutoFornecedorId.ToString());
                cmd.Parameters.AddWithValue("@NomeProduto", FL.NomeProduto.ToString());
                cmd.Parameters.AddWithValue("@Valor", FL.Valor.ToString());
                cmd.Parameters.AddWithValue("@FornecedorId", FL.FornecedorId.ToString());
                cmd.Parameters.AddWithValue("@ProdutoLojaId", FL.ProdutoLojaId.ToString());

                cmd.ExecuteNonQuery();

            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
