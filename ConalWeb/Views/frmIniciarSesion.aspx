<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIniciarSesion.aspx.cs" Inherits="ConalWeb.Views.IniciarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
<meta http-equiv="content-type" content="text/html; charset=utf-8"  />
    <title> ConalWeb </title>
    <link href="//maxcdn.bootstrapcdn.com/bootswatch/3.3.1/css/bootstrap.min.css" rel="stylesheet"  />
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/AdminLTE.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="form-box" id="login-box" >
        <div style="text-align:center">
            <img src="~/img/conalapp_logo.png" runat="server" />
        </div>
        <div class="header bg-blue">Iniciar Sesión</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                    <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtContrasena" CssClass="form-control" TextMode="Password" runat="server" Height="30px" Width="100%"></asp:TextBox>
                </div>
            </div>
            <div class="footer bg-gray">
                <asp:Button ID="btnIniciarSesion" CssClass="btn bg-blue-gradient" Height="35px" Width="100%" runat="server" Text="Ingresar" OnClick="btnIniciarSesion_Click" />
            </div>
        </form>
    </div>
    
</body>
</html>
