<%--esse arquivo é uma pagina de controle para o card do produto--%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCard.ascx.cs" Inherits="WebApplication.ProductCard" %>
<%@ Import Namespace="System.Data" %>

<div class="result-card-item">
    <!-- item img -->
    <div class="result-item-img">
        <asp:Image ID="ProductImageURL" runat="server" AlternateText="Product Image" />
    </div>

    <!-- iten info -->
    <div class="result-item-info">
        <!-- nome + preço -->
        <div class="result-item-info-top">
            <p id="item-name" runat="server"></p>
            <p id="item-price" runat="server"></p>
        </div>

        <!-- avaliação + kg -->
        <div class="result-item-info-bottom">
            <div class="item-avaliacao">
                <asp:Image ID="imgStar" runat="server" ImageUrl="~/assets/img/result imgs/Star.png" AlternateText="Star Image" />
                <span id="Span1" runat="server"></span>
            </div>

            <img class="circle-divider" src="../assets/img/result imgs/circledivider.png" alt="">

            <div class="item-un-venda">
                <span>Kg</span>
            </div>
        </div>

        <!-- qtd + btn card -->
        <div class="result-item-info-qtdCart">
            <!-- qtd -->
            <div class="result-item-qtdBtn">
                <asp:Button ID="btnQtdMin" runat="server" OnClientClick="decreaseQuantity(); return false;">
                    <i class="bx bx-minus"></i>
                </asp:Button>

                <span class="numQtd" id="quantity" runat="server">1</span>

                <asp:Button ID="btnQtdMax" runat="server" OnClientClick="increaseQuantity(); return false;">
                    <i class="bx bx-plus"></i>
                </asp:Button>
            </div>

            <!-- btn cart -->
            <asp:Button ID="btnAddToCart" runat="server" CssClass="result-item-btnCart" OnClick="btnAddToCart_Click">
                <i class="bx bx-shopping-bag"></i>
            </asp:Button>
        </div>
    </div>
</div>

