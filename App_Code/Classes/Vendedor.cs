/// <summary>
/// Descrição resumida de Vendedor
/// </summary>
public class Vendedor : Usuario
{
    public Vendedor(TipoUsuario tipoUsuario) : base(tipoUsuario) { }

    private int _ven_id;
    private string _ven_nomeCorporativo;
    private string _ven_cnpj;
    private bool _ven_fazEntrega;
    private decimal _ven_valorFrete;
    private string _ven_chavePix;
    private string _ven_descricao;

    public int VendedorId { get => _ven_id; set => _ven_id = value; }
    public string NomeCorporativo { get => _ven_nomeCorporativo; set => _ven_nomeCorporativo = value; }
    public string CNPJ { get => _ven_cnpj; set => _ven_cnpj = value; }
    public bool FazEntrega { get => _ven_fazEntrega; set => _ven_fazEntrega = value; }
    public decimal ValorFrete { get => _ven_valorFrete; set => _ven_valorFrete = value; }
    public string ChavePix { get => _ven_chavePix; set => _ven_chavePix = value; }
    public string Descricao { get => _ven_descricao; set => _ven_descricao = value; }
}