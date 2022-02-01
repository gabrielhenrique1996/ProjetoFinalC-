using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaPerolaNegra
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=sisperolanegra");
        public string mensagem;
        public DataTable listaMercadoria()
        {
            MySqlCommand cmd = new MySqlCommand("lista_mercadorias", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch(MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally 
            {
                conexao.Close();
            }

        }
        public bool insereMercadoria(mercadoria m)
        {
            MySqlCommand cmd = new MySqlCommand("insere_mercadoria", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("produto", m.Produto);
            cmd.Parameters.AddWithValue("categoria", m.Categoria);
            cmd.Parameters.AddWithValue("quantidade", m.Quantidade);
            cmd.Parameters.AddWithValue("tamanho", m.Tamanho);
            try 
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally 
            {
                conexao.Close();
            }
        }
        public bool alteraMercadoria(mercadoria m,int id)
        {
            MySqlCommand cmd = new MySqlCommand("altera_mercadoria", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("produto", m.Produto);
            cmd.Parameters.AddWithValue("categoria", m.Categoria);
            cmd.Parameters.AddWithValue("quantidade", m.Quantidade);
            cmd.Parameters.AddWithValue("tamanho", m.Tamanho);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        public bool deleteMercadoria(int idmercadoria)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_mercadoria", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idmercadoria", idmercadoria);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
