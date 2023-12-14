using MySql.Data.MySqlClient;
using System;
using System.Data;

public partial class HomeProdutor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarPedidos();
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];

            // Atualizar o nome da banca com o nome de usuário
            sellerName.InnerText = "Banca de " + usuario.Nome;
        }
    }

    // método para carregar pedidos dos clientes/consumidores
    protected void CarregarPedidos()
    {
        // Obtém a conexão
        IDbConnection con = MapeamentoBD.Conexao();

        // Obtém o comando
        IDbCommand cmd = MapeamentoBD.ComandoSQL("select car_id, car_nomeCliente, car_nomeProduto, car_qtdProduto, car_descricaoPedido, car_pagamento, car_valorTotal from car_carrinho;", con);

        // Cria um adaptador e um DataTable para armazenar os resultados
        IDataAdapter adapter = new MySqlDataAdapter((MySqlCommand)cmd);
        DataSet dataSet = new DataSet();

        // Preenche o DataSet com os resultados da consulta
        adapter.Fill(dataSet);

        // Associa o DataSet ao Repeater usando a tabela específica
        pedidosRepeater.DataSource = dataSet.Tables[0];
        pedidosRepeater.DataBind();

        // fecha a conexão após o uso
        con.Close();
    }
}