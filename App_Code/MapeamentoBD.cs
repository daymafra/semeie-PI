using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
/// <summary>
/// Classe motora de metodos a serem usados na conexão com o BD
/// </summary>
public class MapeamentoBD
{
    // 1 metodo: conexão com o bd;
    public static IDbConnection Conexao()
    {
        MySqlConnection conexaoMySQL = new MySqlConnection(ConfigurationManager.AppSettings["stringConexaoBD"]);
        conexaoMySQL.Open();  // abre a conexão com o banco

        return conexaoMySQL;
    }

    // 2 metodo: executa comando sql;
    public static IDbCommand ComandoSQL(string sql, IDbConnection Conexao)
    {
        //recebe o comando e passa a conexão
        IDbCommand Comando = Conexao.CreateCommand();
        Comando.CommandText = sql;
        return Comando;
    }

    // 3 metodo: container de dados;
    public static IDataAdapter Adapter(IDbCommand Comando)
    {
        IDbDataAdapter adapter = new MySqlDataAdapter();
        adapter.SelectCommand = Comando;
        return adapter;
    }

    // 4 metodo: parametrização;
    // C# Data: SQL Injection / XCS => Cross Script
    public static IDbDataParameter ValidarParametros(string nomeParametro, object Valor)
    {
        return new MySqlParameter(nomeParametro, Valor);
    }
}