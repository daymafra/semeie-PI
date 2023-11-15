<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- css -->
    <link rel="stylesheet" href="assets/css/master.css">
    <link rel="stylesheet" href="assets/css/login.css">
    <link rel="shortcut icon" href="assets/img/favicon.png" type="image/x-icon">
    <title>Cadastre-se</title>
</head>
<body>


    <main>
        <div class="logo">Semeie.</div>

        <div class="main-content">
            <div class="sec-welcome">
                <div class="welcome-info">
                    <div class="welcome-text">
                        <h3>Comece a explorar a feira online agora mesmo!</h3>
                        <p>Entre com seus dados para criar sua conta</p>
                    </div>
                    <div class="welcome-img">
                        <img src="assets/img/fruit shop-amico 1.png" alt="">
                    </div>
                </div>
            </div>

            <!-- form -->
            <form id="form1" runat="server">
                <%--  controle HiddenField usado para armazenar o valor do tipo de usuário selecionado. Este controle será usado para enviar o valor para o servidor. --%>
                <asp:HiddenField ID="userType" runat="server" />
                <div class="form-header">
                    <h3>Crie sua conta!</h3>
                </div>
                <div class="col-12 text-white text-center">
                    <asp:Literal ID="msgSenha" runat="server"></asp:Literal>
                    <asp:Literal ID="msgConfSenha" runat="server"></asp:Literal>
                    <asp:Literal ID="msgErro" runat="server"></asp:Literal>
                </div>
                <!-- wrap form -->
                <div class="form-content">
                    <div class="form-content-top">
                        <div class="form-inputs">

                            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome" CssClass="form-control input" ClientIDMode="Static" TextMode="Email" required=""></asp:TextBox>

                            <asp:TextBox ID="txtTelefone" runat="server" placeholder="Telefone" CssClass="form-control input" ClientIDMode="Static" TextMode="Phone" required=""></asp:TextBox>


                            <asp:TextBox ID="txtCpf" runat="server" placeholder="CPF" CssClass="form-control input" ClientIDMode="Static" TextMode="email" required=""></asp:TextBox>

                            <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail" CssClass="form-control input" ClientIDMode="Static" TextMode="email" required=""></asp:TextBox>

                            <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" CssClass="form-control input" ClientIDMode="Static" TextMode="password" required=""></asp:TextBox>

                            <asp:TextBox ID="txtConfSenha" runat="server" placeholder="Confirmar senha" CssClass="form-control input" ClientIDMode="Static" TextMode="password" required=""></asp:TextBox>

                            <!-- type user -->
                            <div class="check-type">
                                <div class="check-type-1">
                                    <asp:CheckBox type="checkbox" ID="checkCon" name="type-1" runat="server" OnClick="checkCon_Click"></asp:CheckBox>
                                    <label for="terms">Consumidor</label>
                                </div>

                                <div class="check-type-2">
                                    <asp:CheckBox type="checkbox" ID="checkVen" name="type-2" runat="server" OnClick="checkVen_Click"></asp:CheckBox>
                                    <label for="terms">Vendedor</label>
                                </div>
                            </div>

                            <span class="line"></span>
                            <asp:LinkButton type="submit" class="btn" ID="btnCadastro" runat="server" OnClick="btnCadastro_Click">Cadastrar</asp:LinkButton>
                        </div>
                    </div>

                    <div class="form-divider">
                        <img src="assets/img/Group 198.png" alt="">
                    </div>

                    <!-- form bottom -->
                    <div class="form-content-bottom">
                        <div class="form-social-input">
                            <button type="submit">
                                <div class="btn-social-text">
                                    <img src="assets/img/google.png" alt="">
                                    <p>Google</p>
                                </div>
                            </button>
                            <button type="submit">
                                <div class="btn-social-text">
                                    <img src="assets/img/face.png" alt="">
                                    <p>Facebook</p>
                                </div>
                            </button>
                            <span class="line"></span>
                            <a href="Login.aspx">Já tem uma conta? <span>Entre</span></a>
                        </div>
                    </div>
            </form>
        </div>
    </main>

    <!-- js -->
    <script>
        const checkCon = document.getElementById('<%= checkCon.ClientID %>');
        const checkVen = document.getElementById('<%= checkVen.ClientID %>');
        const userType = document.getElementById('<%= userType.ClientID %>');

        checkCon.addEventListener('change', function () {
            if (checkCon.checked) {
                checkVen.checked = false;
                userType.value = 'Consumidor';
            }
        });

        checkVen.addEventListener('change', function () {
            if (checkVen.checked) {
                checkCon.checked = false;
                userType.value = 'Vendedor';
            }
        });
    </script>

</body>
</html>
