<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMensajeria.aspx.cs" Inherits="ConalWeb.frmMensajeriaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- estilos específicos del view -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-box" id="login-box" >
        
        <div class="header bg-blue">Salas de Chats</div>
        
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:Label ID="lblComunidades" runat="server" Text="Seleccione una comunidad"></asp:Label>
                    <asp:DropDownList ID="DropDownList_comunidades" AppendDataBoundItems="true" runat="server" Height="30px" Width="100%"> 
                        <asp:ListItem Text="Comunidad 1" Value="Comunidad 1" />
                        <asp:ListItem Text="Comunidad 2" Value="Comunidad 2" />
                        <asp:ListItem Text="Comunidad 3" Value="Comunidad 3" />
                        <asp:ListItem Text="Comunidad 4" Value="Comunidad 4" />
                    </asp:DropDownList>
                    
                </div>
            </div>
            <div class="footer bg-gray">
                <asp:Button ID="btnIngresarSalaChat" CssClass="btn bg-blue-gradient" Height="35px" Width="100%" runat="server" Text="Ingresar" OnClick="btnIngresarSalaChat_Click" />
            </div>
    </div>
    
</asp:Content>
