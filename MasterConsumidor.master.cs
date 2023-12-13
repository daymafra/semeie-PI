using System;
using System.Collections.Generic;

public partial class MasterConsumidor : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        return sacola ?? new List<ProdutoSistema>();
    }
}
