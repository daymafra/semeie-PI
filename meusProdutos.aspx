<%@ Page Title="" Language="C#" MasterPageFile="~/MasterProdutor.master" AutoEventWireup="true" CodeFile="meusProdutos.aspx.cs" Inherits="meusProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main>

        <!-- headers buttons -->
        <section class="header-buttons">
            <button type="button" class="hd-buttons" id="cadastrarProdBtn">Cadastra novo produto</button>
            <button type="button" class="hd-buttons" id="desativarProdBtn">Desativar produtos</button>
        </section>


        <!-- modal - cadastro de produto -->
        <div class="modal-cadastro-item" id="modal-cadItem">
            <!-- content -->
            <div class="modal-content">
                <!-- header modal-->
                 <div class="content-top">
                    <div class="order-header-info">
                        <h3>Cadastre um novo produto</h3>
                        <p>Antes de cadastrar um novo item confira nosso <span class="destaque-span">guia de cadastro</span> e nossos <span class="destaque-span">termos de uso</span></p>
                    </div>

                    <button type="button" class="close-modal-cadItem">
                        <i class="bx bx-x-circle"></i>
                    </button>
                 </div>

                 <!-- form-cadastro -->
                 <div class="cad-form-content">
                    <!-- seção 1 - categoria -->
                 <div class="formCad-container">

                    <!-- progresso -->
                        <div class="formCad-stepsCad-steps">
                            <ul>
                                <li class="formCad-stepsCad-steps-item1 active">
                                    <span>1</span>
                                    <p>Categoria</p>
                                </li>
                                <li class="formCad-stepsCad-steps-item2">
                                    <span>2</span>
                                    <p>Produto</p>
                                </li>
                                <li class="formCad-stepsCad-steps-item3">
                                    <span>3</span>
                                    <p>Detalhes</p>
                                </li>
                            </ul>
                        </div>
                
                        <!-- dados do cadastro -->
                        <form action="">
                        <!-- parte 01 -->
                        <div class="formCad-page-step-1 active">
                            <div class="input-ib-form">
                                <div class="label-ib">
                                    <p class="label-ib-name">Selecione uma categoria<span id="inputReq">*</span></p>
                                    <p class="label-ib-desc">Escolha um tipo de produto</p>
                                </div>
                                <input type="text" class="input-ib" id="ctgCadastro" placeholder="Escolha" list="ctgSistema" required>
                                <!-- puxar categoria do banco -->
                                <datalist id="ctgSistema">
                                    <option value="Frutas">
                                    <option value="Hortaliças">
                                    <option value="Laticionios">
                                    <option value="Doces artesanais">
                                </datalist>
                            </div>
                        </div>
                        
                        <!-- parte 02 -->
                        <div class="formCad-page-step-2">
                            <div class="input-ib-form">
                                <div class="label-ib">
                                    <p class="label-ib-name">Selecione um produto<span id="inputReq">*</span></p>
                                    <p class="label-ib-desc">Escolha o produto que quer cadastrar</p>
                                </div>
                                <input type="text" class="input-ib" id="produtoCad" placeholder="Escolha" list="produtoSistema" required>
                                <!-- puxar do banco de acordo com a categoria escolhida -->
                                <datalist id="produtoSistema">
                                    <option value="Item 01">
                                    <option value="Item 02">
                                    <option value="Item 03">
                                    <option value="Item 04">
                                    <option value="Item 05">
                                    <option value="Item 06">
                                </datalist>
                            </div>
                        </div>
                        
                        <!-- parte 3 -->
                        <div class="formCad-page-step-3">
                          <!-- nome do produto selecionado -->
                        <div class="input-ib-form-block">
                            <div class="label-ib">
                                <p class="label-ib-name">Adicione informações do produto</p>
                                <p class="label-ib-desc-block">Coloque as informações de venda do seu produto</p>
                            </div>
                            <!-- trazer no placeholder o item escolhido -->
                            <input type="text" class="input-ib-block" id="produtoCad" placeholder="Item 01" list="produtoSistema" required>
                        </div>

                        <!-- preço + unidade de venda -->
                        <div class="ib-precounidade">
                            <!-- preço -->
                            <div class="input-ib-form">
                                <div class="label-ib">
                                    <p class="label-ib-name">Preço<span id="inputReq">*</span></p>
                                    <p class="label-ib-desc">Valor do seu produto de acordo com a unidade de venda</p>
                                </div>
                                <input type="text" class="input-ib" id="precoProdCad" placeholder="00,00" required>
                            </div>

                            <!-- unidade de venda -->
                            <div class="input-ib-form">
                                <div class="label-ib">
                                    <p class="label-ib-name">Unidade de venda<span id="inputReq">*</span></p>
                                    <p class="label-ib-desc">Unidade de venda do seu produto (Kg, Un, G)</p>
                                </div>
                                <input type="text" class="input-ib" id="unvendaProdCad" placeholder="Escolha" list="unVenda" required>
                                <!-- puxar do banco -->
                                <datalist id="unVenda">
                                    <option value="Kg">
                                    <option value="Un">
                                    <option value="G">
                                </datalist>
                            </div>
                        </div>
                        
                        <!-- descrição do item -->
                        <div class="input-ib-form">
                            <div class="label-ib">
                                <p class="label-ib-name">Descrição</p>
                                <p class="label-ib-desc">Adicione uma breve descrição sobre este produto</p>
                            </div>
                            <textarea class="input-ib" name="" id="descProdCad" cols="15" rows="5" placeholder="Sobre seu produto..."></textarea>
                        </div>

                        <!-- fotos do item -->
                        <div class="input-ib-form">
                            <div class="label-ib">
                                <p class="label-ib-name">Fotos</p>
                                <p class="label-ib-desc">Adicione fotos do seu produto</p>
                            </div>
                            <input type="image" class="input-ib" id="imgProdCad" placeholder="Suas imagens aqui" >
                        </div>
                        </div>
                        </form>
                        
                
                        <div class="formCad-btns">
                          <button type="button" class="formCad-back-btn">
                            Voltar
                          </button>
                
                          <button type="button" class="formCad-btn">
                              Proxima etapa
                              <svg width="16" height="16" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                              <g clip-path="url(#clip0_1675_1807)">
                              <path d="M10.7814 7.33312L7.20541 3.75712L8.14808 2.81445L13.3334 7.99979L8.14808 13.1851L7.20541 12.2425L10.7814 8.66645H2.66675V7.33312H10.7814Z" fill="white"/>
                              </g>
                              <defs>
                              <clipPath id="clip0_1675_1807">
                              <rect width="16" height="16" fill="white"/>
                              </clipPath>
                              </defs>
                              </svg>
                          </button>
                        </div>
                    
                  </div>
                </div>
            </div>
        </div>

        <!-- meus produtos -->
        <section class="section">
                <div class="title-section">
                    <div class="title-left">
                        <h3 class="title">Meus produtos</h3>
                        <p class="subtitle">Gerenciar produtos cadastrados</p>
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
                                <img src="assets_produtor/img/itensimg/itempic2.png" alt="" id="prodctImg">
                            </div>
                            
                            <div class="pop-info-text">
                                <div class="pop-top-info">
                                    <p id="popItemName" class="pop-item-name">Morango</p>
                                    <p class="pop-item-price" id="ItemPrice">R$9,56</p>
                                </div>

                                <div class="pop-bottom-info">
                                    <div class="rating">
                                        <img class="rating-icon" src="assets_produtor/img/Star.png" alt="">
                                        <span class="rating-num">4.6</span>
                                    </div>
                                    <!-- circle div -->
                                    <div>
                                        <svg xmlns="http://www.w3.org/2000/svg" width="4" height="4" viewBox="0 0 4 5" fill="none">
                                            <circle cx="2" cy="2.5" r="2" fill="#161621" fill-opacity="0.5"/>
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
    </main>

</asp:Content>

