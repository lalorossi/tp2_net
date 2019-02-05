<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor = "Black"
        SelectedRowStyle-ForeColor = "White"
        DataKeyNames = "ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowDataBound="gridView_OnRowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="EMail" DataField="EMail" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tacnado en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>

        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <br />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" controlToValidate="nombreTextBox" ErrorMessage="Campor requerido (Nombre)">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" controlToValidate="apellidoTextBox" ErrorMessage="Campo requerido (apellido)">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" controlToValidate="emailTextBox" ErrorMessage="Campo requerido (email)" Text="*"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" controlToValidate="nombreUsuarioTextBox" ErrorMessage="Campo requerido (nombre de usaurio)">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server" type="password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfcClave" runat="server" 
             ErrorMessage="Campo requerido(clave)" 
             ControlToValidate="claveTextBox" Text="*"/>
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server" type="password"></asp:TextBox>
        <asp:CompareValidator ID="cmpvClave" runat="server" 
             ControlToValidate="repetirClaveTextBox"
             ControlToCompare="claveTextBox"
             ErrorMessage="Las claves no coinciden" Text="*" />

        <asp:RequiredFieldValidator ID="rfvRepetirClave" runat="server" 
             ErrorMessage="Campo requerido(repetir clave)" 
             ControlToValidate="repetirClaveTextBox" Text="*"/>
        <br />
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>


    <asp:ValidationSummary ID="vsumUsuario" runat="server" HeaderText="Corrija los siguientes campos" />

</asp:Content>
