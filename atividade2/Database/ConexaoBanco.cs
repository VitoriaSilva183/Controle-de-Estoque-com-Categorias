using MySqlConnector;

namespace ControleEstoque.Database
{
    public class ConexaoBanco
    {
        private const string _stringConexao = "Server=localhost;Database=controle_estoque;User=root;Password=;";
        public MySqlConnection ObterConexao()
        {
            MySqlConnection conexao = new MySqlConnection(_stringConexao);
            conexao.Open();
            return conexao;
        }
    }
}