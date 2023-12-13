using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

public partial class MasterConsumidor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarItensNaSacola();
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];

            loginEmail.Text = usuario.Nome;
            loginEmail.ForeColor = System.Drawing.Color.FromArgb(0, 184, 96);
            loginEmail.Font.Bold = true;

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void Sair_Click(object sender, EventArgs e)
    {
        Session["USUARIO"] = null;
        Response.Redirect("Login.aspx");
    }

    // Método para obter a quantidade de itens na sacola
    public int ObterQuantidadeItensNaSacola()
    {
        // Lógica para obter a quantidade de itens na sacola usando sessão
        List<ProdutoSistema> sacola = (List<ProdutoSistema>)Session["SacolaDeCompras"];
        return sacola != null ? sacola.Count : 0;
    }

    // Método para obter os detalhes dos itens na sacola
    public List<ProdutoSistema> ObterDetalhesItensNaSacola()
    {
        // Lógica para obter os detalhes dos itens na sacola usando sessão
        List<ProdutoSistema> sacola = (List<ProdutoSistema>)Session["SacolaDeCompras"];

        // Certifica de que a lista não seja nula
        if (sacola != null)
        {
            // Verifica se cada objeto na lista possui propriedades preenchidas
            for (int i = sacola.Count - 1; i >= 0; i--)
            {
                var produto = sacola[i];

                if (string.IsNullOrEmpty(produto.Nome) || string.IsNullOrEmpty(produto.Quantidade) || string.IsNullOrEmpty(produto.Preco))
                {
                    // Remove o objeto inválido da lista
                    sacola.RemoveAt(i);
                }
            }
        }

        return sacola ?? new List<ProdutoSistema>();
    }

    // Método para vincular dados ao Repeater
    protected void CarregarItensNaSacola()
    {
        repeaterItens.DataSource = ObterDetalhesItensNaSacola();
        repeaterItens.DataBind();
    }

    protected void repeaterItens_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ExcluirItem")
        {
            int indice = e.Item.ItemIndex;

            // Obter a lista de itens da sessão
            List<ProdutoSistema> sacola = ObterDetalhesItensNaSacola();

            // Remover o item da lista com base no índice
            sacola.RemoveAt(indice);

            // Atualizar a sessão com a nova lista
            Session["SacolaDeCompras"] = sacola;

            // Recarregar o Repeater para refletir as alterações
            CarregarItensNaSacola();
        }
    }

    protected void btnSendOrder_Click(object sender, EventArgs e)
    {
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];
            string email = usuario.Email;

            int idConsumidor = ObterIdDoConsumidor(usuario);

            int result = CadastrarProdutoBanco(idConsumidor);

            if (result == 0)
            {
                Response.Write("<script>alert('Pedido enviado com sucesso! Aguarde confirmação do vendedor.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Erro ao submeter pedido. Tente novamente mais tarde');</script>");
            }
        }
    }

    public int CadastrarProdutoBanco(int idConsumidor)
    {
        if (!ConsumidorExiste(idConsumidor))
        {
            CriarConsumidor(idConsumidor);
        }

        // Obter detalhes validados dos itens na sacola
        List<ProdutoSistema> detalhesSacola = ObterDetalhesItensNaSacola();

        foreach (var produto in detalhesSacola)
        {
            // Usa os detalhes do produto para inserção no banco de dados
            string query = "INSERT INTO car_carrinho(car_nomeProduto, car_qtdProduto, car_descricaoPedido, car_pagamento, car_valorTotal, con_id) " +
                           $"VALUES('{produto.Nome}', '{produto.Quantidade}', '{orderDesc.Text}', '{orderPagamento.Text}', '{produto.Preco}', '{idConsumidor}')";

            // Executa a consulta aqui
            IDbConnection con = MapeamentoBD.Conexao();
            IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con);
            cmd.CommandTimeout = 200;

            if (con.State != ConnectionState.Open)
                con.Open();

            cmd.ExecuteNonQuery();
        }

        return 0;
    }

    private bool ConsumidorExiste(int idConsumidor)
    {
        string query = $"SELECT COUNT(*) FROM con_consumidor WHERE con_id = {idConsumidor}";

        using (IDbConnection con = MapeamentoBD.Conexao())
        using (IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con))
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }

    private void CriarConsumidor(int idConsumidor)
    {
        string query = $"INSERT INTO con_consumidor (con_id, usu_id) VALUES ({idConsumidor}, {idConsumidor})";

        using (IDbConnection con = MapeamentoBD.Conexao())
        using (IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con))
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            cmd.ExecuteNonQuery();
        }
    }

    public int ObterIdDoConsumidor(Usuario usuario)
    {

        string query = "SELECT usu_id FROM usu_usuarios WHERE usu_email = '" + usuario.Email + "';";

        IDbConnection con = MapeamentoBD.Conexao();
        IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con);

        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return Convert.ToInt32(reader["usu_id"]);
        }

        return -1;
    }
}