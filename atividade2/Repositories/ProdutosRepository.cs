
using ControleEstoque.Database;
using ControleEstoque.Models;
using MySqlConnector;
namespace ControleEstoque.Repositories
{
    public class ProdutoRepository
    {
       private ConexaoBanco _conexao = new ConexaoBanco();
       public void Inserir (Produto produto)
        {
            using (var conexao = _conexao.ObterConexao())
            {
                String sql = "INSERT INTO PRODUTOS (nome, preco, quantidade, categoria_id) VALUES (@Nome, @Preco, @Quantidade, @CategoriaId)";
                using (var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome",produto.Nome);
                    cmd.Parameters.AddWithValue("@Preco", produto.Preco);
                    cmd.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                    cmd.Parameters.AddWithValue("@CategoriaId",produto.CategoriaId);

                    cmd.ExecuteNonQuery();
                } 

            }
        }
        public List<Produto> ListarTodos()
        {
            List<Produto> lista = new List<Produto>();
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "SELECT * FROM PRODUTOS";
                using (var cmd = new MySqlCommand (sql, conexao))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Produto();
                            p.Id = reader.GetInt32("id");
                            p.Nome = reader.GetString("nome");
                            p.Preco = reader.GetDecimal("preco");
                            p.Quantidade = reader.GetInt32("quantidade");
                            p.CategoriaId = reader.GetInt32("categoria_id");

                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }
        public Produto BuscarPorId(int id)
        {
            Produto produto = null;
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "SELECT * FROM PRODUTOS WHERE id = @Id";
                using(var cmd = new MySqlCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue ("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new Produto ();
                            produto.Id = reader.GetInt32("id");
                            produto.Nome = reader.GetString("nome");
                            produto.Preco = reader.GetDecimal("preco");
                            produto.Quantidade = reader.GetInt32("quantidade");
                            produto.CategoriaId = reader.GetInt32("categoria_id");


                        }
                    }
                }
            }
                return produto;
        }        
            
            public void Remover (int id)
        {
            using (var conexao = _conexao.ObterConexao())
            {
                string sql = "DELETE FROM PRODUTOS WHERE ID = @iD";
                using (var cmd = new MySqlCommand (sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}