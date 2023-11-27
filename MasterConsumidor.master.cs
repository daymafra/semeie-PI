using System;

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

    protected void CartCloseButton_Click(object sender, EventArgs e)
    {
        
    }

    protected void SellerChatButton_Click(object sender, EventArgs e)
    {
        
    }
}
