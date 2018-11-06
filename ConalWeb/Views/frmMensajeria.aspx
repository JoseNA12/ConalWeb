<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="frmMensajeria.aspx.cs" Inherits="ConalWeb.frmMensajeriaCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownList_comunidades" runat="server" Width="185px">
                <asp:ListItem Selected="True">Comunidad 1</asp:ListItem>
                <asp:ListItem>Comunidad 2</asp:ListItem>
                <asp:ListItem>Comunidad 3</asp:ListItem>
                <asp:ListItem>Comunidad 4</asp:ListItem>
                <asp:ListItem>Comunidad 5</asp:ListItem>

            </asp:DropDownList>
        </div>

        <br/>

        <asp:Button ID="btn_ingresarSala" runat="server" Text="Ingresar a sala" OnClick="btnIngresarSalaChat_Click" />
    </form>
</body>
</html>

