using System;

public partial class HomeProdutor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USUARIO"] != null)
        {
            Usuario usuario = (Usuario)Session["USUARIO"];

            // Atualizar o nome da banca com o nome de usuário
            sellerName.InnerText = "Banca de " + usuario.Nome;
        }
    }
}