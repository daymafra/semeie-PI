using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
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

    // Método para adicionar produto à sacola do lado do servidor
    [WebMethod]
    public static void AdicionarProdutoNaSacola(string nome, string preco, string quantidade)
    {
        try
        { // Lógica para adicionar o produto à sacola
          // Aqui você pode usar sessão, cookies ou qualquer outra abordagem que preferir
          // Neste exemplo, estou usando sessão
            List<ProdutoSistema> sacola = (List<ProdutoSistema>)HttpContext.Current.Session["SacolaDeCompras"] ?? new List<ProdutoSistema>();
            sacola.Add(new ProdutoSistema { Nome = nome, Preco = preco, Quantidade = quantidade });
            HttpContext.Current.Session["SacolaDeCompras"] = sacola;
        }
        catch (Exception ex)
        {
            // Registre a exceção para fins de depuração
            Console.WriteLine($"Erro ao adicionar produto à sacola: {ex.Message}");
            throw; // Re-throw para que o AJAX possa capturar o erro
        }
    }

}