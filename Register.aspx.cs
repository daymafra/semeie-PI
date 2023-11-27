using System;
using System.Data;
using System.Drawing;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msgErro.Visible = false;
    }

    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        limparCamposBordas();

        if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtTelefone.Text) && string.IsNullOrEmpty(txtCpf.Text) && string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtSenha.Text) && string.IsNullOrEmpty(txtConfSenha.Text))
        {
            //Se todos os campos forem vazios exibe em tela uma mensagem de erro
            //aqui é o que vem escrito na mensagem
            msgErro.Text = "<span style='color: red;'>Necessário preencher todos os campos para o cadastro</span>";
            //aqui eu torno visible a mensagem
            msgErro.Visible = true;
            txtNome.BorderColor = Color.Red;
            txtTelefone.BorderColor = Color.Red;
            txtCpf.BorderColor = Color.Red;
            txtEmail.BorderColor = Color.Red;
            txtSenha.BorderColor = Color.Red;
            txtConfSenha.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtNome.Text))
        {
            msgErro.Text = "<span style='color: red;'>Nome é um Campo Obrigatório!</span>";
            msgErro.Visible = true;
            txtNome.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtTelefone.Text))
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>Telefone é um Campo Obrigatório!</span>";
            txtTelefone.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtCpf.Text))
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>CPF é um Campo Obrigatório!</span>";
            txtCpf.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>Email é um campo Obrigatório!</span>";
            txtEmail.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtSenha.Text))
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>Senha é um Campo Obrigatório!</span>";
            txtSenha.BorderColor = Color.Red;
        }
        else if (txtSenha.Text.Length < 6)
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>A senha deve ter pelo menos 6 caracteres!</span>";
            txtSenha.BorderColor = Color.Red;
        }
        else if (string.IsNullOrEmpty(txtConfSenha.Text))
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>Por favor, confirme sua senha!</span>";
            txtConfSenha.BorderColor = Color.Red;
        }
        else if (txtSenha.Text != txtConfSenha.Text)
        {
            msgErro.Visible = true;
            msgErro.Text = "<span style='color: red;'>As senhas devem ser iguais!</span>";
            txtConfSenha.BorderColor = Color.Red;
            txtSenha.BorderColor = Color.Red;
        }
        else if (!checkCon.Checked && !checkVen.Checked)
        {
            msgErro.Text = "<span style='color: red;'>Informe se você é vendedor ou consumidor!</span>";
            msgErro.Visible = true;
        }
        else
        {
            int resultado = CadastrarBanco();

            if (resultado >= 0)
            {
                mostrarPopPupSucesso();
            }
            else
            {
                mostrarPopPupFracasso();
            }
        }  
    }

    public void limparCamposBordas()
    {
        txtNome.BorderColor = Color.Empty;
        txtTelefone.BorderColor = Color.Empty;
        txtCpf.BorderColor = Color.Empty;
        txtEmail.BorderColor = Color.Empty;
        txtSenha.BorderColor = Color.Empty;
        txtConfSenha.BorderColor = Color.Empty;
    }

    public int CadastrarBanco()
    {
        string tpUsuario = userType.Value; // Obtém o valor do HiddenField
        TipoUsuario tipoUsuarioEnum;

        if (Enum.TryParse(tpUsuario, true, out tipoUsuarioEnum))
        {
            string query = "INSERT INTO usu_usuarios(usu_nome, usu_telefone, usu_cpf, usu_email, usu_senha, usu_confSenha, usu_tipoUser) " +
                           "VALUES('" + txtNome.Text + "','" + txtTelefone.Text + "','" + txtCpf.Text + "','" +
                           txtEmail.Text + "','" + Funcoes.BaseCodifica(txtSenha.Text) + "','" + Funcoes.BaseCodifica(txtConfSenha.Text) + "','" + tipoUsuarioEnum + "')";

            IDbConnection con = MapeamentoBD.Conexao();
            IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con);
            cmd.CommandTimeout = 200;

            if (con.State != ConnectionState.Open)
                con.Open();
            var process = cmd.ExecuteNonQuery();
            int result = Convert.ToInt32(process);
            return result;
        }
        else
        {
            return -1;
        }
    }

    public void limparTextBox()
    {
        txtNome.Text = string.Empty;
        txtTelefone.Text = string.Empty;
        txtCpf.Text = string.Empty;
        txtEmail.Text = string.Empty;
        txtSenha.Text = string.Empty;
        txtConfSenha.Text = string.Empty;
        checkCon.Checked = false;
        checkVen.Checked = false;
        msgErro.Visible = false;
    }

    public void mostrarPopPupSucesso()
    {
        string tpUsuario = userType.Value; // Obtém o valor do HiddenField 
        // Determina a página inicial com base no tipo de usuário
        string paginaInicial = (tpUsuario == "Consumidor") ? "HomeConsumidor.aspx" : "HomeProdutor.aspx";
        Response.Write("<script>alert('Cadastro Realizado Com Sucesso!');</script>");
        // Adiciona um script para redirecionar imediatamente para a página inicial após o alerta
        Response.Write($"<script>setTimeout(function(){{ window.location.href = '{paginaInicial}'; }}, 0);</script>");
    }

    public void mostrarPopPupFracasso()
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
            "swal('Cadastro Falhou!','Verifique sua conexão com a internet. Se a conexão estiver normal entre em contato com o suporte!','error')", true);
    }

}