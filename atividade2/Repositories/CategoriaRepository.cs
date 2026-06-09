using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using ControleEstoque.Database;
using ControleEstoque.Models;
using Microsoft.VisualBasic.FileIO;
using MySqlConnector;
namespace ControleEstoque.Repositories
{
    public class CategoriaRepository
    {
       private ConexaoBanco _conexao = new ConexaoBanco();
       public void Inserir (Categoria categoria)
        {
            using (var conexao = _conexao.ObterConexao())
            {
                String sql = "INSERT INTO CATEGORIA(nome, descricao) VALUES (@nome, @descricao)";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome",categoria.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", categoria.Descricao);
                    cmd.ExecuteNonQuery();
                } 

            }
        }
        public List<Categoria> ListarTodos()
        {
            List<Categoria> lista = new List<Categoria>();
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "SELECT * FROM CATEGORIAS";
                using (var cmd = new MySqlCommand (sql, conexao))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var c = new Categoria();
                            c.Id = reader.GetInt32("id");
                            c.Nome = reader.GetString("nome");
                            c.Descricao = reader.GetString("descricao");

                            lista.Add(c);
                        }
                    }
                }
            }
            return lista;
        }
        public Categoria BuscarPorId(int id)
        {
            Categoria categoria = null;
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "SELECT * FROM CATEGORIAS WHERE id = @Id";
                using(var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue ("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            categoria = new Categoria ();
                            categoria.Id = reader.GetInt32("id");
                            categoria.Nome = reader.GetString("nome");
                            categoria.Descricao = reader.GetString("descricao");

                        }
                    }
                }
            }
                return categoria;
        }        
            
            public void Remover (int id)
        {
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "DELETE FROM CATEGORIAS WHERE ID = @iD";
                using (var cmd = new MySqlCommand (sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}