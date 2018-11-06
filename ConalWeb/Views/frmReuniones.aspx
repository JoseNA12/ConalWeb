<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmReuniones.aspx.cs" Inherits="ConalWeb.PanelReuniones" %>
<%@ PreviousPageType VirtualPath="~/Views/frmIniciarSesion.aspx" %> 
<asp:Content ID="Content_reuniones_1" ContentPlaceHolderID="head" runat="server">
    <!-- script para estilos específicos del view -->
</asp:Content>

<asp:Content ID="Content_reuniones_2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin-top: 10px; height:60px;">
            <asp:Button ID="btnMisPublicaciones" CssClass="btn bg-green-gradient" runat="server" Text="Mis publicaciones"
                OnClick="btnMisPublicaciones_Click" Height="35px" Width="150px" style="margin-top:10px;" />
    </div>
    
    <div id="divResultadosBusqueda" runat="server" style="margin-top:5px; text-align:center; visibility: hidden">
        <hr />
        <asp:Label ID="lblNoResultados" runat="server" Text="No hay resultados en la búsqueda"></asp:Label>
    </div>
    
    <div>
        <asp:Table ID="tblBoletines" runat="server" Width="100%" CssClass="marginToFooter" >
            <asp:TableHeaderRow runat="server" CssClass="tableBorder">
            </asp:TableHeaderRow>
        </asp:Table>
    </div>

    
</asp:Content>
