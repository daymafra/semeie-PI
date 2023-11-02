/// <summary>
/// Descrição resumida de Usuario
/// </summary>
public class Usuario
{
    private int _usu_id;
    private string _usu_nome;
    private string _usu_email;
    private string _usu_telefone;
    private string _usu_cpf;
    private string _usu_senha;
    private string _usu_confSenha;
    private TipoUsuario _usu_tipoUser;
    private string _usu_endereco;
    private string _usu_cep;
    private string _usu_numCasa;
    private string _usu_endComplemento;

    public Usuario(TipoUsuario tipoUsuario)
    {
        TipoUsuario = tipoUsuario;
    }

    public int UsuarioId { get => _usu_id; set => _usu_id = value; }
    public string Nome { get => _usu_nome; set => _usu_nome = value; }
    public string Email { get => _usu_email; set => _usu_email = value; }
    public string Telefone { get => _usu_telefone; set => _usu_telefone = value; }
    public string CPF { get => _usu_cpf; set => _usu_cpf = value; }
    public string Senha { get => _usu_senha; set => _usu_senha = value; }
    public string ConfSenha { get => _usu_confSenha; set => _usu_confSenha = value; }
    public TipoUsuario TipoUsuario { get => _usu_tipoUser; set => _usu_tipoUser = value; }
    public string Endereco { get => _usu_endereco; set => _usu_endereco = value; }
    public string CEP { get => _usu_cep; set => _usu_cep = value; }
    public string NumeroCasa { get => _usu_numCasa; set => _usu_numCasa = value; }
    public string EnderecoComplemento { get => _usu_endComplemento; set => _usu_endComplemento = value; }
}

public enum TipoUsuario
{
    Consumidor,
    Vendedor
}