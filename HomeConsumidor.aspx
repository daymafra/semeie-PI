<%@ Page Title="Semeie" Language="C#" MasterPageFile="~/MasterConsumidor.master" AutoEventWireup="true" CodeFile="HomeConsumidor.aspx.cs" Inherits="HomeConsumidor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- conteudo da home --%>
    <main>
        <!-- header -->
        <section class="main-content">
            <div class="main-content-left">
                <!-- main text -->
                <div class="main-content-text">
                    <h1>Tenha a <span>feira</span> na palma da sua mão</h1>
                    <p>Transforme sua rotina de compras com o poder da feira na palma da sua mão, faça suas compras com um clique e receba no conforto de sua casa!</p>
                </div>
                <!-- main search -->
                <div class="main-content-search">
                    <input type="search" name="mainSearch" id="" class="main-searchbar" placeholder="Procure seu produto sem sair de casa">
                    <button type="submit" class="main-btnsearch">
                        <i data-feather="search"></i>
                    </button>
                </div>

                <!-- main tags -->
                <div class="main-content-explore">
                    <h4>Explore</h4>
                    <div class="main-explore-tags">
                        <!-- tag 01 -->
                        <div class="exolore-tag-item green">
                            <div class="tag-item-img">
                                <img src="assets/img_consumidor/categoria_img/unsplash_zeFy_oCUhV8.png" />
                            </div>
                            <div class="tag-item-name">
                                <p class="ctgName">Frutas</p>
                            </div>
                        </div>

                        <!-- tag 02 -->
                        <div class="exolore-tag-item orange">
                            <div class="tag-item-img">
                                <img src="assets/img_consumidor/categoria_img/unsplash_IGfIGP5ONV0_(1).png" />
                            </div>
                            <div class="tag-item-name">
                                <p class="ctgName">Hortaliças</p>
                            </div>
                        </div>

                        <!-- tag 03 -->
                        <div class="exolore-tag-item green">
                            <div class="tag-item-img">
                                <img src="assets/img_consumidor/categoria_img/laticionios.png" />
                            </div>
                            <div class="tag-item-name">
                                <p class="ctgName">Laticínios</p>
                            </div>
                        </div>

                        <!-- more arrow -->
                        <button id="btnMoreTags">
                            <img src="assets/img_consumidor/arrowleft.png" />
                        </button>
                    </div>
                </div>
            </div>
        </section>

        <!-- ofertas -->
        <section class="offers-week-content">
            <h3>Ofertas da semana</h3>

            <div class="offers-slide">
                <!-- banner 01 -->
                <div id="banner1" class="offers-banner ">
                    <img src="#" alt="">
                </div>

                <!-- banner 02 -->
                <div id="banner2" class="offers-banner bannerActive">
                    <img src="#" alt="">
                </div>

                <!-- banner 3 -->
                <div id="banner3" class="offers-banner">
                    <img src="#" alt="">
                </div>

            </div>
        </section>

        <!-- produtos mais pediodos -->
        <section class="itens-high">
            <h3>Produtos em alta</h3>

            <!-- cards carrosseul -->
            <div class="result-group-cards">

                <!-- Utilizando o Repeater para gerar dinamicamente os produtos -->
                <asp:Repeater ID="productRepeater" runat="server">
                    <ItemTemplate>
                        <div class="result-card-item">
                            <div class="result-item-img">
                                <img src='<%# Eval("pro_fotoCapa") %>' alt='<%# Eval("pro_nome") %>' />
                            </div>
                            <div class="result-item-info">
                                <div class="result-item-info-top">
                                    <p id="item-name"><%# Eval("pro_nome") %></p>
                                    <p id="item-price"><%# Eval("pro_preco") %></p>
                                </div>
                                <!-- avaliação + kg -->
                                <div class="result-item-info-bottom">
                                    <div class="item-avaliacao">
                                        <img src="assets/img_consumidor/result_imgs/Star.png" />
                                    </div>
                                    <img class="circle-divider" src="assets/img_consumidor/result_imgs/circledivider.png" alt="">
                                    <div class="item-un-venda">
                                        <span>Kg</span>
                                    </div>
                                </div>

                                <!-- qtd + btn card -->
                                <div class="result-item-info-qtdCart">
                                    <!-- qtd -->
                                    <div class="result-item-qtdBtn">
                                        <button id="btnQtdMin">
                                            <!-- <img src="../assets/img/icons/qtnMin.png" alt=""> -->
                                            <i class="bx bx-minus"></i>
                                        </button>

                                        <span class="numQtd">1
                                        </span>
                                        <button id="btnQtdMax">
                                            <i class="bx bx-plus"></i>

                                        </button>
                                    </div>

                                    <!-- btn cart -->
                                    <button class="result-item-btnCart" title="Adicionar produto à sacola de compras?">
                                        <i class="bx bx-shopping-bag"></i>
                                    </button>
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

        <!-- produtores em alta -->
        <section class="sellers-section">
            <div class="sellers-section-content">
                <div class="sellers-section-header">
                    <h3 class="">Produtores em alta</h3>
                </div>
                <div class="sellers-cards-box">
                    <!-- card banca 01 -->
                    <div class="seller-card">
                        <div class="seller-img-prof-content">
                            <img class="seller-img-porf" src="assets/img_consumidor/result_imgs/pop01.png" alt="">
                        </div>

                        <!-- info do produtor -->
                        <div class="seller-card-info">
                            <div class="seller-card-info-text">
                                <div class="seller-card-nameCtg">
                                    <h3 class="seller-card-name">Nome da banca</h3>
                                    <p class="seller-card-categoria">Hortaliças</p>
                                </div>
                                <div class="seller-card-details">
                                    <div class="seller-card-avaliacao">
                                        <img src="assets/img_consumidor/result_imgs/Star.png" />
                                        <span>4.2</span>
                                    </div>
                                    <div class="seller-card-local">
                                        <img src="assets/img_consumidor/Location.png" />
                                        <span>Cunha, SP</span>
                                    </div>
                                </div>
                            </div>
                            <!-- btn chat -->

                            <button id="seller-card-chatBtn">
                                <i class='bx bxs-message-square-dots'></i>
                            </button>

                        </div>
                    </div>

                </div>
            </div>
        </section>


    </main>

    <!-- js -->
    <script src="https://unpkg.com/feather-icons"></script>
    <script src="https://cdn.jsdelivr.net/npm/feather-icons/dist/feather.min.js"></script>

    <script>
        feather.replace();

            // código JavaScript para manipular o clique no botão e adicionar ao carrinho
            document.addEventListener("DOMContentLoaded", function () {
                // Encontra o botão com a classe
                var addToCartButtons = document.querySelectorAll(".result-item-btnCart");

                // Adiciona um ouvinte de eventos para cada botão
                addToCartButtons.forEach(function (button) {
                    button.addEventListener("click", function () {
                        // Obtém informações do produto
                        var productName = this.closest(".result-card-item").querySelector("#item-name").innerText;
                        var productPrice = this.closest(".result-card-item").querySelector("#item-price").innerText;
                        var productQuantity = this.closest(".result-card-item").querySelector(".numQtd").innerText;

                        // Adiciona um alert para verificar se as informações do produto estão corretas
                        alert("Produto: " + productName + "\nPreço: " + productPrice + "\nQuantidade: " + productQuantity);

                        // Adiciona chamada AJAX sem jQuery para enviar informações ao servidor
                        var xhr = new XMLHttpRequest();
                        xhr.open("POST", "HomeConsumidor.aspx/AdicionarProdutoNaSacola", true);
                        xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
            
                        var data = JSON.stringify({ nome: productName, preco: productPrice, quantidade: productQuantity });
            
                        xhr.onreadystatechange = function () {
                            if (xhr.readyState === 4 && xhr.status === 200) {
                                // Atualizar dinamicamente o número de itens na sacola
                                var quantidadeItens = parseInt(document.querySelector(".qtd-itens").innerText);
                                document.querySelector(".qtd-itens").innerText = quantidadeItens + 1;

                                // Recarregar os produtos após a adição
                                CarregarProdutos();
                            } else {
                                // Lógica de erro
                            }
                        };
            
                        xhr.send(data);
                    });
                });
            });

    </script>

</asp:Content>

