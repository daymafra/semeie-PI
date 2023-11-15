<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- css -->
    <link rel="stylesheet" href="assets/css/master.css">
    <link rel="stylesheet" href="assets/css/login.css">
    <link rel="shortcut icon" href="assets/img/favicon.png" type="image/x-icon">
    <title>Login</title>
</head>
<body>

    <main>
        <div class="logo">Semeie.</div>

        <div class="main-content">
            <div class="sec-welcome">
                <div class="welcome-info">
                    <div class="welcome-text">
                        <h3>Comece a explorar a feira online agora mesmo!</h3>
                        <p>Entre com seus dados para acessar sua conta</p>
                    </div>
                    <div class="welcome-img">
                        <img src="assets/img/fruit shop-amico 1.png" alt="">
                    </div>
                </div>
            </div>

            <!-- form -->
            <form id="form1" runat="server">
                <div class="form-header">
                    <h3>Bem vindo!</h3>
                </div>
                <div class="col-12 text-white text-center">
                    <asp:Literal ID="msgErro" runat="server"></asp:Literal>
                </div>
                <!-- wrap form -->
                <div class="form-content">
                    <div class="form-content-top">
                        <div class="form-inputs">
                            <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail" CssClass="form-control input" ClientIDMode="Static" TextMode="email" required=""></asp:TextBox>
                            <asp:TextBox ID="txtSenha" runat="server" placeholder="Senha" CssClass="form-control input" ClientIDMode="Static" TextMode="password" required=""></asp:TextBox>
                            <span class="line"></span>
                            <asp:LinkButton type="submit" class="btn" ID="btnEntrar" runat="server" OnClick="btnEntrar_Click">Entrar</asp:LinkButton>
                            <span class="line"></span>
                            <a href="#">Esqueceu a senha? <span>Clique aqui</span></a>
                        </div>
                    </div>
                </div>

                <div class="form-divider">
                    <img src="assets/img/Group 198.png" alt="">
                </div>


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
                        <a href="Register.aspx">Não tem uma conta? <span>Cadastre-se</span></a>
                    </div>
                </div>

            </form>
        </div>

    </main>

    <%--<script src="assets/js/login.js"></script>--%>
</body>
</html>
