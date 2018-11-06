<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmBoletines.aspx.cs" Inherits="ConalWeb.PanelBoletines" %>
<%@ PreviousPageType VirtualPath="~/Views/frmIniciarSesion.aspx" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- script para estilos específicos del view -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 10px; height:100px;">
        <div id="divBuscar" runat="server" style="width:100%;">
            <asp:TextBox ID="txtBuscar" CssClass="txtBoxRounded" runat="server" placeholder="Buscar perfil" Height="35px" Width="150px" ></asp:TextBox>
            <asp:ImageButton ID="imgBuscar" AlternateText="Buscar" ImageAlign="Middle" ImageUrl="~/img/lupa_icon.png" runat="server" OnClick="imgBuscar_Click"
                style="padding-right:10%"/>

            <asp:Button ID="btnMisPublicaciones" CssClass="btn bg-green-gradient" runat="server" Text="Mis publicaciones"
                OnClick="btnMisPublicaciones_Click" Height="35px" Width="150px" style="margin-top:10px;"/>
        </div>
    </div>
    
    <div id="divResultadosBusqueda" runat="server" style="margin-top:5px; text-align:center; visibility: hidden">
        <hr />
        <asp:Label ID="lblNoResultados" runat="server" Text="No hay resultados en la búsqueda"></asp:Label>
    </div>
    
    <div>
        <asp:Table ID="tblBoletines" runat="server" Width="100%" CssClass="table-responsive marginToFooter" >
            <asp:TableHeaderRow runat="server" CssClass="tableBorder">
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    
</asp:Content>
