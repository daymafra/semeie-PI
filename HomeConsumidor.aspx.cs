using System;
using System.Data;
using MySql.Data.MySqlClient;

public partial class HomeConsumidor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CarregarProdutos();
        }
    }

    protected void CarregarProdutos()
    {
        // Obtém a conexão
        IDbConnection con = MapeamentoBD.Conexao();

        // Obtém o comando
        IDbCommand cmd = MapeamentoBD.ComandoSQL("SELECT pro_nome, pro_fotoCapa, pro_preco FROM pro_produtoSistema", con);

        // Cria um adaptador e um DataTable para armazenar os resultados
        IDataAdapter adapter = new MySqlDataAdapter((MySqlCommand)cmd);
        DataSet dataSet = new DataSet();

        // Preenche o DataSet com os resultados da consulta
        adapter.Fill(dataSet);

        // Associa o DataSet ao Repeater usando a tabela específica
        productRepeater.DataSource = dataSet.Tables[0];
        productRepeater.DataBind();

        // fecha a conexão após o uso
        con.Close();
    }

}