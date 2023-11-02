/// <summary>
/// Descrição resumida de Consumidor
/// </summary>
public class Consumidor : Usuario
{
    public Consumidor(TipoUsuario tipoUsuario) : base(tipoUsuario) { }

    private int _con_id;

    public int Consumidor_id { get => _con_id; set => _con_id = value; }
}
