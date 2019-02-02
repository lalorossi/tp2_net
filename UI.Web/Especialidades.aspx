<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor = "Black"
        SelectedRowStyle-ForeColor = "White"
        DataKeyNames = "ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" OnRowDataBound="gridView_OnRowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Materias" DataField="Descripcion" />
                <%-- Este campo debería ser un contador de materias --%>
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tocando en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>

        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" visible="false" runat="server">
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" controlToValidate="descripcionTextBox" ErrorMessage="Campo requerido (descripcion)" Text="*"></asp:RequiredFieldValidator>
        <br/>
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsumUsuario" runat="server" HeaderText="Corrija los siguientes campos" />

</asp:Content>
