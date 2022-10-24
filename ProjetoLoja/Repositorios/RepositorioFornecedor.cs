using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja.Repositorios
{
    public class RepositorioFornecedor : IRepositorioFornecedor
    {
        public List<Fornecedor> BuscarTodos()
        {
            Fornecedor fornecedor = null;
            List<Fornecedor> ListForn = new List<Fornecedor>();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select FornecedorId, FornecedorNome, FornecedorCNPJ, FornecedorEndereco, FornecedorCEP, FornecedorCidade, FornecedorEstado from Fornecedor", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fornecedor = new Fornecedor();
                    fornecedor.FornecedorId = Convert.ToInt32(dr["FornecedorId"].ToString());
                    fornecedor.FornecedorNome = dr["FornecedorNome"].ToString();
                    fornecedor.FornecedorCNPJ = dr["FornecedorCNPJ"].ToString();
                    fornecedor.FornecedorEndereco = dr["FornecedorEndereco"].ToString();
                    fornecedor.FornecedorCEP = dr["FornecedorCEP"].ToString();
                    fornecedor.FornecedorCidade = dr["FornecedorCidade"].ToString();
                    fornecedor.FornecedorEstado = dr["FornecedorEstado"].ToString();

                    ListForn.Add(fornecedor);
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
            return ListForn;


        }
        public Fornecedor BuscarId(int Id)
        {
            Fornecedor fornecedor = new Fornecedor();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");
            SqlDataReader dr = null;

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select FornecedorId, FornecedorNome, FornecedorCNPJ, FornecedorEndereco, FornecedorCEP, FornecedorCidade, FornecedorEstado from Fornecedor", _conn);
                cmd.Parameters.AddWithValue("@FornecedorId", Id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fornecedor.FornecedorId = Convert.ToInt32(dr["FornecedorId"].ToString());
                    fornecedor.FornecedorNome = dr["FornecedorNome"].ToString();
                    fornecedor.FornecedorCNPJ = dr["FornecedorCNPJ"].ToString();
                    fornecedor.FornecedorEndereco = dr["FornecedorEndereco"].ToString();
                    fornecedor.FornecedorCEP = dr["FornecedorCEP"].ToString();
                    fornecedor.FornecedorCidade = dr["FornecedorCidade"].ToString();
                    fornecedor.FornecedorEstado = dr["FornecedorEstado"].ToString();
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
            return fornecedor;


        }
        public void AlterarFornecedor(Fornecedor fornecedor)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Fornecedor set FornecedorNome= @FornecedorNome, FornecedorCNPJ = @FornecedorCNPJ, FornecedorEndereco= @FornecedorEndereco, FornecedorCEP= @FornecedorCEP, FornecedorCidade= @FornecedorCidade, FornecedorEstado=@FornecedorEstado where FornecedorId=FornecedorId", _conn);
                cmd.Parameters.AddWithValue("@FornecedorNome", fornecedor.FornecedorNome.ToString());
                cmd.Parameters.AddWithValue("@FornecedorCNPJ", fornecedor.FornecedorCNPJ.ToString().Replace(".", "").Replace("/", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@FornecedorEndereco", fornecedor.FornecedorEndereco.ToString());
                cmd.Parameters.AddWithValue("@FornecedorCEP", fornecedor.FornecedorCEP.ToString().Replace("-", ""));
                cmd.Parameters.AddWithValue("@FornecedorCidade", fornecedor.FornecedorCidade.ToString());
                cmd.Parameters.AddWithValue("@FornecedorEstado", fornecedor.FornecedorEstado.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }

        }

        public void InserirFornecedor(Fornecedor fornecedor)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Loja;Integrated Security=True");

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Fornecedor(FornecedorNome, FornecedorCNPJ, FornecedorEndereco, FornecedorCEP, FornecedorCidade, FornecedorEstado) values (@FornecedorNome, @FornecedorCNPJ, @FornecedorEndereco, @FornecedorCEP, @FornecedorCidade, @FornecedorEstado)", _conn);
                cmd.Parameters.AddWithValue("@FornecedorNome", fornecedor.FornecedorNome.ToString());
                cmd.Parameters.AddWithValue("@FornecedorCNPJ", fornecedor.FornecedorCNPJ.ToString().Replace(".", "").Replace("/", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("@FornecedorEndereco", fornecedor.FornecedorEndereco.ToString());
                cmd.Parameters.AddWithValue("@FornecedorCEP", fornecedor.FornecedorCEP.ToString().Replace("-", ""));
                cmd.Parameters.AddWithValue("@FornecedorCidade", fornecedor.FornecedorCidade.ToString());
                cmd.Parameters.AddWithValue("@FornecedorEstado", fornecedor.FornecedorEstado.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }

        }
    }
}
