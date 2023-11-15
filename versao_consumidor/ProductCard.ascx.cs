using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//indroduzir a logica de pegar as informações do banco aquiiiiiiii
public partial class ProductCard : System.Web.UI.UserControl
{

    //informações de cada card de produto
    public string ProductImageURL { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public double ProductRating { get; set; }
    public string ProductUnit { get; set; }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        item-name.InnerText = ProductName;
        item-price.InnerText = ProductPrice;
        item-rating.InnerText = ProductRating;
    }
}

