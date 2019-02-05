<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>

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
                <asp:BoundField HeaderText="Materia" DataField="IDMateria" />
                <asp:BoundField HeaderText="Comision" DataField="IDComision" />
                <asp:BoundField HeaderText="Año de Cursado" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tocando en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>

        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
            <br />
            <asp:LinkButton ID="verCursoLinkButton" runat="server" OnClick="verCursoLinkButton_Click" Visible="False" Enabled="False">Ver Curso</asp:LinkButton>
            <br />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" visible="false" runat="server">
        <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="dropMaterias" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvMateria" runat="server" controlToValidate="dropMaterias" ErrorMessage="Campor requerido (materia)">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="comisionLabel" runat="server" Text="Comision: "></asp:Label>
        <asp:DropDownList ID="dropComisiones" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvComision" runat="server" controlToValidate="dropComisiones" ErrorMessage="Campo requerido (comision)">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="anioCursadoLabel" runat="server" Text="AnioCursado: "></asp:Label>
        <asp:TextBox ID="anioCursadoTextBox" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAnioCursado" runat="server" controlToValidate="anioCursadoTextBox" ErrorMessage="Campo requerido (año de cursado)" Text="*"></asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server" type="number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCupo" runat="server" controlToValidate="cupoTextBox" ErrorMessage="Campo requerido (cupo)">*</asp:RequiredFieldValidator>
        <br/>
        <asp:Label ID="docenteLabel" runat="server" Text="Docente: "></asp:Label>
        <asp:DropDownList ID="dropDocente" runat="server"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvDocente" runat="server" controlToValidate="dropDocente" ErrorMessage="Campo requerido (docente)">*</asp:RequiredFieldValidator>
        <br/>
        <br />
        <br />
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsumUsuario" runat="server" HeaderText="Corrija los siguientes campos" />

</asp:Content>
