<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMensajeria.aspx.cs" Inherits="ConalWeb.frmMensajeriaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- estilos específicos del view -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="float:left; width:60%">
        <h1>Mensajes</h1>

        <div style="margin-left:30px; margin-top:30px">
            <asp:TextBox ID="txtMensajes" runat="server" TextMode="MultiLine" Height="250px" Width="100%"></asp:TextBox>
        </div>

        <div style="margin-left:30px; margin-top:30px">
            <asp:TextBox ID="TextBox1" runat="server" Height="50px" Width="80%" style="font-size: large" placeholder="Ingrese su comentario"></asp:TextBox>
            <asp:Button ID="btnEnviar" CssClass="btn bg-orange" runat="server" Text="Enviar" style="margin-left:5px; width:15%; height:50%" />
        </div>
    </div>
    <div id="divComunidades" runat="server" style="float:right; width:35%">
        <h1>Comunidades</h1>

        <asp:ListBox ID="lbxComunidades" runat="server" Height="350px" Width="90%" style="margin-top:10px"></asp:ListBox>
    </div>
    
    
</asp:Content>
