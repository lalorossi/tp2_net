<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CursosDocente.aspx.cs" Inherits="UI.Web.CursosDocente" %>

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
                <asp:BoundField HeaderText="Año de Cursado" DataField="AnioCalendario" />
                <asp:BoundField HeaderText="Materia" DataField="IDMateria" />
                <asp:BoundField HeaderText="Comision" DataField="IDComision" />
                <asp:BoundField HeaderText="Alumnos" DataField="Cupo" />
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tocando en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>

        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="verCursoLinkButton" runat="server" OnClick="verCursoLinkButton_Click">Ver Curso</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="formPanel" visible="false" runat="server">
        <asp:GridView ID="gridViewAlumnos" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor = "Black"
        SelectedRowStyle-ForeColor = "White"
        DataKeyNames = "ID" OnRowDataBound="gridViewAlumnos_OnRowDataBound">
            <Columns>
                <asp:BoundField HeaderText="Apellido" DataField="IDAlumno" />
                <asp:BoundField HeaderText="Nombre" DataField="IDAlumno" />
                <asp:BoundField HeaderText="Legajo" DataField="IDAlumno" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:BoundField HeaderText="Condicion" DataField="Condicion" />
                <asp:TemplateField HeaderText="Nota">
                    <ItemTemplate>
                        <asp:DropDownList ID="dropNotas" runat="server"  Enabled="false" AutoPostBack="false"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="IDAlumno" DataField="IDAlumno"/>
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tocando en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="habilitarEdicionButton" runat="server" OnClick="habilitarEdicionButton_Click">Editar Notas</asp:LinkButton>
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" Visible="False" Enabled="False">Aceptar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Atrás</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>


</asp:Content>
