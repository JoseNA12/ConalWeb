<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/MasterPage.Master" CodeBehind="frmMensajeria.aspx.cs" Inherits="ConalWeb.frmMensajeriaCliente" %>

<%@ PreviousPageType VirtualPath="~/Views/frmIniciarSesion.aspx" %> 
<asp:Content ID="Content_reuniones_1" ContentPlaceHolderID="head" runat="server">
    <!-- script para estilos específicos del view -->
</asp:Content>

<asp:Content ID="Content_mensajeria" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style="text-align:center;">
            
            <asp:Label ID="Label1" runat="server" Text="Seleccione una comunidad para ingresar al chat"></asp:Label>
            <br/>
            <br/>
            <asp:DropDownList ID="DropDownList_comunidades" runat="server" Width="295px"></asp:DropDownList>
            <br/>
            <br/>
        <br/>

        <asp:Button ID="btn_ingresarSala" CssClass="btn bg-green-gradient" runat="server" Text="Ingresar a sala" Height="35px" Width="150px" OnClick="btnIngresarSalaChat_Click" />
     </div>
</asp:Content>

