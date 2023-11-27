using System;
using System.Data;
using System.Drawing;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Toda vez em que a página de login é recarregada eu deixo como null a minha session
        Session["USUARIO"] = null;
        txtEmail.BorderColor = Color.Empty;
        msgErro.Visible = false;
    }

    protected void BtnEntrar_Click(object sender, EventArgs e)
    {
        //Verifica se o email e senha são vazios 
        if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtSenha.Text))
        {
            //Se o email e senha forem vazios exibe em tela uma mensagem de erro
            //aqui é o que vem escrito na mensagem
            msgErro.Text = "<span style='color: red;'>Email e Senha não podem ser nulos!</span>";
            //aqui eu torno visible a mensagem
            msgErro.Visible = true;
            txtEmail.BorderColor = Color.Red;
            txtSenha.BorderColor = Color.Red;
        }

        //Verifica se a senha estiver vazia
        else if (string.IsNullOrEmpty(txtSenha.Text))
        {
            //Se a senha for vazia exibe em tela uma mensagem de erro
            //aqui é o que vem escrito na mensagem
            msgErro.Text = "<span style='color: red;'>Por favor, informe sua senha!</span>";
            //aqui eu torno visible a mensagem
            msgErro.Visible = true;
            txtSenha.BorderColor = Color.Red;
        }

        // Verifico se o email estiver vazio
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            // Se o email for vazio exibe em tela uma mensagem de erro
            msgErro.Text = "<span style='color: red;'>Por favor, informe seu email!</span>";
            // aqui eu torno visivel a mensagem
            msgErro.Visible = true;
            txtEmail.BorderColor = Color.Red;
        }
        else
        {
            // crio o texto da minha consulta no banco
            txtSenha.Text = Funcoes.BaseCodifica(txtSenha.Text);
            string query = "SELECT * FROM usu_usuarios WHERE usu_senha = '" + txtSenha.Text + "' AND usu_email= '" + txtEmail.Text + "';";
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
                usuario.Senha = reader["usu_senha"].ToString();
                usuario.TipoUsuario = (TipoUsuario)Enum.Parse(typeof(TipoUsuario), reader["usu_tipoUser"].ToString());
                usuario.Endereco = reader["usu_endereco"].ToString();
                usuario.CEP = reader["usu_cep"].ToString();
                usuario.NumeroCasa = reader["usu_numCasa"].ToString();
                usuario.EnderecoComplemento = reader["usu_endComplemento"].ToString();

            }

            //Se o meu objeto usuario for diferente de null, ou seja, se houverem resultados da minha consulta, minha Session recebe o objeto usuario e redireciona o usuário para o Perfil adequado
            // Isso acontece quando há resultados na consulta, ou seja, existe um usuário com email e senha, então o login é bem sucedido
            if (usuario != null)
            {
                // Salva o usuário na sessão
                Session["USUARIO"] = usuario;
                // Fecha a conexão com o banco de dados
                con.Close();
                // Converte o ID do usuário para uma string
                string id = Convert.ToString(usuario.UsuarioId);

                // Verifica o tipo de usuário e redireciona para a página correspondente
                if (usuario.TipoUsuario == TipoUsuario.Consumidor)
                {
                    // Redireciona para a página do consumidor
                    Response.Redirect("HomeConsumidor.aspx?id=" + Funcoes.BaseCodifica(id));
                }
                else if (usuario.TipoUsuario == TipoUsuario.Vendedor)
                {
                    // Redireciona para a página do vendedor
                    Response.Redirect("HomeProdutor.aspx");
                }
            }

            //Se o meu objeto usuario for igual a null, ou seja, se não houverem resultados da minha consulta, minha Session continua null e mensagens de erro aparecem na tela,
            //sendo os campos senha e email limpos
            else
            {
                msgErro.Text = "<span style='color: red;'>Falha ao tentar logar! Verifique se o email ou senha estão corretos e tente novamente!</span>";
                msgErro.Visible = true;
                txtEmail.BorderColor = Color.Red;
                txtSenha.Text = null;
            }
        }
    }
}