using System;
using System.Data;
using System.Drawing;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        msgErro.Visible = false;
    }

    protected void BtnCadastro_Click(object sender, EventArgs e)
    {
        LimparCamposBordas();

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
                MostrarPopPupSucesso();
            }
            else
            {
                MostrarPopPupFracasso();
            }
        }
    }

    public void LimparCamposBordas()
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

    public void LimparTextBox()
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

    public void MostrarPopPupSucesso()
    {
        // Chama o método para recuperar o usuário recém-cadastrado
        RecuperarUsuarioRecemCadastrado();

        // Obtém os detalhes do usuário recém-cadastrado da sessão
        Usuario novoUsuario = (Usuario)Session["USUARIO"];
        string tpUsuario = userType.Value; // Obtém o valor do HiddenField 

        if (novoUsuario != null)
        {
            // Determina a página inicial com base no tipo de usuário
            string paginaInicial = (novoUsuario.TipoUsuario == TipoUsuario.Consumidor) ? "HomeConsumidor.aspx?id=" + Funcoes.BaseCodifica(tpUsuario) : "HomeProdutor.aspx";
            Response.Write("<script>alert('Cadastro Realizado Com Sucesso!');</script>");
            // Adiciona um script para redirecionar imediatamente para a página inicial após o alerta
            Response.Write($"<script>setTimeout(function(){{ window.location.href = '{paginaInicial}'; }}, 0);</script>");
        }
    }

    public void MostrarPopPupFracasso()
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert",
            "swal('Cadastro Falhou!','Verifique sua conexão com a internet. Se a conexão estiver normal entre em contato com o suporte!','error')", true);
    }

    public void RecuperarUsuarioRecemCadastrado()
    {
        string query = "SELECT * FROM usu_usuarios WHERE usu_email= '" + txtEmail.Text + "';";
        // abrir minha conexao com o banco
        IDbConnection con = MapeamentoBD.Conexao();
        // aqui eu crio o objeto que vai manipular meus comandos no banco de dados e passo o meu comando, que no caso, está contido na minha string chamada query
        IDbCommand cmd = MapeamentoBD.ComandoSQL(query, con);

        // criando uma variável para receber uma lista vazia do banco
        //  O comando ExecuteReader() executa minhha consulta no banco e o resultado vai para dentro da variável reader
        var reader = cmd.ExecuteReader();

        // Crio um objeto para pegar os dados do meu resultado da consulta. Sendo mais detalhista, aqui eu crio para pegar os valores das colunas do resultado
        Usuario usuario = null;

        // crio um while para varrer o resultado da minha consulta enquanto houver linhas, por isso o método Read(), ele está LENDO a lista
        while (reader.Read())
        {
            //Passo um new para usuario, senão o visual não deixa eu manipular meu objeto null assim criando um novo objeto usuario com o tipo de usuário determinado pelo valor da coluna usu_tipoUser do banco de dados
            usuario = new Usuario(tipoUsuario: (TipoUsuario)Enum.Parse(typeof(TipoUsuario), reader["usu_tipoUser"].ToString()));
            //Passo os valores das colunas da minha consulta para dentro dos atributos da minha classe
            usuario.UsuarioId = Convert.ToInt32(reader["usu_id"]);
            usuario.Nome = reader["usu_nome"].ToString();
            usuario.Email = reader["usu_email"].ToString();
            usuario.Telefone = reader["usu_telefone"].ToString();
            usuario.CPF = reader["usu_cpf"].ToString();
            usuario.TipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), reader["usu_tipoUser"].ToString());
        }

        //Se o meu objeto usuario for diferente de null, ou seja, se houverem resultados da minha consulta, minha Session recebe o objeto usuario e redireciona o usuário para o Perfil adequado
        // Isso acontece quando há resultados na consulta, ou seja, existe um usuário com email e senha, então o login é bem sucedido
        if (usuario != null)
        {
            // Salva o usuário na sessão
            Session["USUARIO"] = usuario;
            // Fecha a conexão com o banco de dados
            con.Close();
        }

    }
}