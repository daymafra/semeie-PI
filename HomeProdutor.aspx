<%@ Page Title="Semeie" Language="C#" MasterPageFile="~/MasterProdutor.master" AutoEventWireup="true" CodeFile="HomeProdutor.aspx.cs" Inherits="HomeProdutor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <%--cabeça~ho com infos da banca--%>
    <header>
        <section class="header-info-seller">
            <!-- left -->
            <div class="info-seller-left">
                <!-- img -->
                <div class="seller-img">
                    <img src="assets/img_produtor/userpic.jpg" alt="" id="sellerImg">
                </div>
                <!-- info text -->
                <div class="info-seller-text">
                    <div class="info-top">
                        <span id="sellerName" runat="server"> </span>
                        <span id="sellerLocal">Cunha, SP</span>
                    </div>
                    <div class="info-bottom">
                        <div class="seller-ctgFrete">
                            <span id="sellerCtg">Frutas</span>
                            <!-- circle div -->
                            <div>
                                <svg xmlns="http://www.w3.org/2000/svg" width="4" height="4" viewBox="0 0 4 5" fill="none">
                                    <circle cx="2" cy="2.5" r="2" fill="#161621" fill-opacity="0.5" />
                                </svg>
                            </div>
                            <span id="sellerFrete">R$7,50</span>
                        </div>

                        <div class="seller-pix">
                            <img src="assets/img_produtor/pix.png" />
                            <span id="sellerPix">@chavepix</span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- right-->
            <div class="info-seller-right">
                <button id="allOrders" class="headerbtn" type="button">
                    <i class='bx bx-note'></i>
                    Todos os pedidos
                </button>
                <button id="myOffers" class="headerbtn" type="button">
                    <i class='bx bxs-offer'></i>
                    Minhas ofertas
                </button>
            </div>
        </section>

    </header>

    <!-- modal todos os pedidos -->
    <div class="modal-allOrder" id="modalAllOrders">
        <!-- content -->
        <div class="modal-content">
            <!-- header -->
            <div class="content-top">
                <div class="order-header-info">
                    <h3>Pedidos</h3>
                    <p>Todos os pedidos recebidos</p>
                </div>
                <button class="close-modal-all">
                    <i class="bx bx-x-circle"></i>
                </button>
            </div>

            <!-- Tab links -->
            <div class="tab">
                <button type="button" class="tablinks" onclick="openTabFilter(event, 'tabPendentOrders')" id="defaultOpen">Pedidos pendentes</button>
                <button type="button" class="tablinks" onclick="openTabFilter(event, 'tabOrdersConfirmed')">Confirmados</button>
                <button type="button" class="tablinks" onclick="openTabFilter(event, 'tabOrdersFinalized')">Finalizados</button>
            </div>

            <!-- Tab content -->
            <!-- todos os pedidos -->
            <div id="tabPendentOrders" class="tabcontent">
                <div class="order-tab-item">
                    <div class="order-info-top">
                        <span>#0033</span>
                        <p>de <span>@username</span></p>
                    </div>

                    <div class="order-numItem-total">
                        <div class="order-num-itens">
                            <p><span>3</span> produtos</p>
                        </div>

                        <div class="order-total">
                            <p>Total</p>
                            <span css="orderTotalValue">R$36,50</span>
                        </div>
                    </div>
                    <button type="button" class="btnOrderStatus">Pendente</button>
                </div>
            </div>

            <!-- tab pedido confirmado -->
            <div id="tabOrdersConfirmed" class="tabcontent">
                <div class="order-tab-item">
                    <div class="order-info-top">
                        <span>#0032</span>
                        <p>de <span>@username</span></p>
                    </div>

                    <div class="order-numItem-total">
                        <div class="order-num-itens">
                            <p><span id="orderNumItens">2</span> produtos</p>
                        </div>

                        <div class="order-total">
                            <p>Total</p>
                            <span css="orderTotalValue">R$26,50</span>
                        </div>
                    </div>

                    <button type="button" class="btnOrderStatus" id="statusConfirm">Confirmado</button>
                </div>
            </div>

            <!-- tab pedido finalizado -->
            <div id="tabOrdersFinalized" class="tabcontent">
                <div class="order-tab-item">
                    <div class="order-info-top">
                        <span>#0031</span>
                        <p>de <span>@username</span></p>
                    </div>

                    <div class="order-numItem-total">
                        <div class="order-num-itens">
                            <p><span>2</span> produtos</p>
                        </div>

                        <div class="order-total">
                            <p>Total</p>
                            <span css="orderTotalValue">R$26,50</span>
                        </div>
                    </div>

                    <button type="button" class="btnOrderStatus" id="statusFinalized">Finalizado</button>
                </div>
            </div>

        </div>
    </div>

    <main>
        <!-- pedidos -->
        <section class="section">
            <div class="title-section">
                <div class="title-left">
                    <h3 class="title">Pedidos</h3>
                    <p class="subtitle">Pedidos recebidos recentemente</p>
                </div>

                <div class="title-right">
                    <a>Ver todos os pedidos</a>
                </div>
            </div>

            <div class="itens-sections">
                <div class="noOrder">
                    Você ainda não tem nenhum pedido
                </div>
                <!-- card order 01 -->
                <div class="order-card">
                    <div class="order-status">
                        <div id="statusMsg"></div>
                        <div id="statusIcon"></div>
                    </div>
                    <div class="order-info-top">
                        <span id="orderId">#0033</span>
                        <p>de <span>@username</span></p>
                    </div>

                    <div class="order-num-itens">
                        <p><span>3</span> produtos</p>
                    </div>

                    <div class="order-total">
                        <p>Total</p>
                        <span id="">R$36,50</span>
                    </div>
                    
                    <button type="button" id="verOrderDetails">Ver detalhes</button>
                </div>
            </div>
        </section>

        <!-- modal ver pedido -->
        <div class="modal-view-order" id="modal-viewOrder">
            <!-- content -->
            <div class="modal-content">
                <!-- header -->
                <div class="content-top">
                    <div class="order-header-info">
                        <h3>Pedido <span>#0033</span></h3>
                        <p>de <span>@username</span></p>
                    </div>

                    <button type="button" class="close-modal-viewOrder">
                        <i class="bx bx-x-circle"></i>
                    </button>
                </div>

                <!-- itens order -->
                <div class="content-itens">
                    <!-- item 01 -->
                    <div class="order-item">
                        <div class="item-info-left">
                            <div class="item-qtdUn">
                                <p>2</p>
                                <p>Kg</p>
                            </div>
                            <!-- circle div -->
                            <div>
                                <svg xmlns="http://www.w3.org/2000/svg" width="4" height="4" viewBox="0 0 4 5" fill="none">
                                    <circle cx="2" cy="2.5" r="2" fill="#161621" fill-opacity="0.5" />
                                </svg>
                            </div>
                            <div css="itemName">Uva verde</div>

                        </div>
                        <div css="itemPrice">R$20,36</div>
                    </div>
                    <!-- item 02 -->
                    <div class="order-item">
                        <div class="item-info-left">
                            <div class="item-qtdUn">
                                <p id="itemQtd">1</p>
                                <p id="itemUn">Un</p>
                            </div>
                            <!-- circle div -->
                            <div>
                                <svg xmlns="http://www.w3.org/2000/svg" width="4" height="4" viewBox="0 0 4 5" fill="none">
                                    <circle cx="2" cy="2.5" r="2" fill="#161621" fill-opacity="0.5" />
                                </svg>
                            </div>
                            <div id="itemName">Maça</div>

                        </div>
                        <div id="itemPrice">R$4,32</div>
                    </div>
                </div>

                <!-- order desc -->
                <div class="content-desc">
                    <p class="info-label">Descrição do pedido</p>
                    <!-- o texto daqui deve vir do consumidor -->
                    <div class="desc-text">Lorem ipsum dolor sit amet consectetur adipisicing elit. Ducimus voluptates, velit cumque nesciunt assumenda amet!</div>
                </div>

                <!-- order price -->
                <div class="content-price">
                    <p class="info-label">Valor total</p>
                    <div class="price-box">
                        <span>R$</span>
                        <div id="orderTotalValue">24,68</div>
                    </div>
                </div>

                <!-- meio pag + entrega -->
                <div class="content-pay-delivery">
                    <!-- pagamento -->
                    <div class="content-payment">
                        <p class="info-label">Pagamento</p>
                        <div class="form-payment" id="formPayment">
                            Pix
                        </div>
                    </div>
                    <!-- entrega -->
                    <div class="content-delivery">
                        <p class="info-label">Entrega</p>
                        <div class="form-delivery" id="formDelivery">
                            Retirado no local
                        </div>
                    </div>
                </div>

                <!-- btn confirmar / rejeitar -->
                <div class="content-btns">
                    <button type="button" id="rejectOrder">Rejeitar pedido</button>
                    <button type="button" id="confirmOrder">Confirmar pedido</button>
                    <button type="button" id="endOrder">Finalizar pedido</button>
                </div>
            </div>
        </div>

        <!-- ********** -->
        <!--  minhas ofertas -->
        <section class="section">
            <div class="title-section">
                <div class="title-left">
                    <h3 class="title">Ofertas</h3>
                    <p class="subtitle">Gerenciar minhas ofertas ativas</p>
                </div>
            </div>

            <div class="itens-sections offer-section">
                <div class="noOrder">
                    Você ainda não fez nenhuma oferta
                </div>
                <!-- card order 01 -->
                <div class="offer-card">
                    <button type="button" id="editOffer">
                        <i class="bx bx-edit"></i>
                    </button>

                    <div class="offer-info">
                        <div class="offer-info-img">
                            <img src="assets/img_produtor/itensimg/itempic.png" alt="">
                        </div>

                        <div class="offer-info-text">
                            <div class="offer-top-info">
                                <p id="offerItemName" class="offer-item-name">Goiaba vermelha</p>
                                <p class="offer-deatail">Disponivel até <span id="offerDateDispo">26/10/23</span></p>
                            </div>

                            <div class="offer-bottom-info">
                                <p class="prev-text">de <span id="itemPricePrev">R$5,69</span></p>
                                <p id="itemPriceNext" class="next-text">R$ 2,30</p>
                            </div>
                        </div>
                    </div>
                </div>

                <button type="button" class="new-offer">
                    <i class="bx bx-plus"></i>
                </button>
            </div>
        </section>

        <!-- ********** -->
        <!--  meus produtos populares-->
        <section class="section">
            <div class="title-section">
                <div class="title-left">
                    <h3 class="title">Meus produtos populares</h3>
                    <p class="subtitle">Produtos mais pedidos e de melhor avaliação</p>
                </div>
            </div>

            <div class="itens-sections">
                <div class="noOrder" id="noItemCard">
                    Você ainda não tem nenhum
                </div>
                <!-- card order 01 -->
                <div class="popular-item-card">
                    <button type="button" id="editItem">
                        <i class="bx bx-edit"></i>
                    </button>

                    <div class="pop-info">
                        <div class="pop-info-img">
                            <img src="assets/img_produtor/itensimg/itempic2.png" alt="">
                        </div>

                        <div class="pop-info-text">
                            <div class="pop-top-info">
                                <p id="popItemName" class="pop-item-name">Morango</p>
                                <p class="pop-item-price" id="ItemPrice">R$9,56</p>
                            </div>

                            <div class="pop-bottom-info">
                                <div class="rating">
                                    <img class="rating-icon" src="assets/img_produtor/Star.png" alt="">
                                    <span class="rating-num">4.6</span>
                                </div>
                                <!-- circle div -->
                                <div>
                                    <svg xmlns="http://www.w3.org/2000/svg" width="4" height="4" viewBox="0 0 4 5" fill="none">
                                        <circle cx="2" cy="2.5" r="2" fill="#161621" fill-opacity="0.5" />
                                    </svg>
                                </div>
                                <div class="univenda">
                                    Kg
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- ********** -->
        <!--  meus clientes frequentes-->
        <section class="section">
            <div class="title-section">
                <div class="title-left">
                    <h3 class="title">Clientes frequentes</h3>
                    <p class="subtitle">Clientes que fazem pedidos com frequencia</p>
                </div>
            </div>

            <div class="itens-sections client-section">
                <!-- card cliente 01 -->
                <div class="client-card">
                    <div class="client-info">
                        <p id="clientName" class="client-name">Maria Souza</p>
                        <p id="clientLocal" class="client-local">Cunha</p>
                    </div>
                    <button type="button" class="client-chat">
                        <i class='bx bxs-message-square-dots'></i>
                    </button>
                </div>
            </div>
        </section>
    </main>

</asp:Content>

