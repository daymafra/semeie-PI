using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de ProductCard
/// </summary>
public class ProductCard
{
    //informações de cada card de produto
    public string ImageProduct { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public string Unit { get; set; }
}