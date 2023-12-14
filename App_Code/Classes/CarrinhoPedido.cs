using System;
using System.Collections.Generic;
/// <summary>
/// Descrição resumida de CarrinhoPedido
/// </summary>
public class CarrinhoPedido
{
    public int IdDoPedido { get; set; }
    public string NomeDoProduto { get; set; }
    public string QuantidadeDoProduto { get; set; }
    public string DescricaoDoPedido { get; set; }
    public string MetodoPagamento { get; set; }
    public string ValorTotal { get; set; }
    public int IdDoConsumidor { get; set; }
}