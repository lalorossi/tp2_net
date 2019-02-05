<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <h4 id="HeaderFiltros" onclick="SwitchFiltros()" style="cursor: pointer; width:max-content;">Filtros <span id="SpanArrow" style="font-family: 'Wingdings 3'">q</span></h4>
        <asp:Panel ID="PanelFiltros" runat="server" style="display: none">
            <asp:Table ID="TableFiltros" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Activar</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Filtro</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="chkFiltroEstado" runat="server" Text="Filtrar por Estado" Enabled="False" OnCheckedChanged="chkFiltroEstado_CheckedChanged" AutoPostBack="true" EnableTheming="False" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dropFiltroEstado" runat="server" OnSelectedIndexChanged="dropFiltroEstado_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Filtrar por estado" />
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="chkFiltroAño" runat="server" Text="Filtrar por Año" Enabled="False" OnCheckedChanged="chkFiltroAño_CheckedChanged" AutoPostBack="true" EnableTheming="False" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dropFiltroAño" runat="server" OnSelectedIndexChanged="dropFiltroAño_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Filtrar por año" />
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:CheckBox ID="chkFiltroComision" runat="server" Text="Filtrar por Comision" Enabled="False" OnCheckedChanged="chkFiltroComision_CheckedChanged" AutoPostBack="true" EnableTheming="False" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dropFiltroComision" runat="server" OnSelectedIndexChanged="dropFiltroComision_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Filtrar por comisión" />
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </asp:Panel>
        <asp:GridView ID="gridViewCursos" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor = "Black"
        SelectedRowStyle-ForeColor = "White"
        DataKeyNames = "ID" OnRowDataBound="gridViewCursos_DataBound">
            <Columns>
                <%-- Año, Comisión, Materia, Profesor, Estado, Nota, Fecha de Modificacion --%>
                <asp:BoundField HeaderText="Año de Cursado" DataField="IDCurso" />
                <asp:BoundField HeaderText="Comision" DataField="IDCurso" />
                <asp:BoundField HeaderText="Materia" DataField="IDCurso" />
                <asp:TemplateField HeaderText="Profesor"></asp:TemplateField>
                <asp:BoundField HeaderText="Estado" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
                <asp:BoundField HeaderText="Fecha de Modificación" DataField="FechaCambio" />
                <asp:CommandField SelectText="" ShowSelectButton="True"/>
                <%-- No tiene texto porque selecciona filas tocando en cualquier lugar de la fila, y no puedo sacar el commandField --%>
            </Columns>
        </asp:GridView>
        <div style="text-align: center">
            <h3 id="HeaderTitulo" runat="server" style="position: center">
                <span id="SpanTitulo" runat="server">Promedio total: </span>
            </h3>
            <label id="lblFiltrosAplicados" runat="server">Sin filtros aplicados</label>
        </div>
        <%-- 
        <asp:Panel ID="gridActionPanel" runat="server">
            <asp:LinkButton ID="verCursoLinkButton" runat="server" OnClick="verCursoLinkButton_Click">Ver Curso</asp:LinkButton>
        </asp:Panel>
        --%>
    </asp:Panel>
    <%-- 
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
            </Columns>
        </asp:GridView>
        
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="habilitarEdicionButton" runat="server" OnClick="habilitarEdicionButton_Click">Editar Notas</asp:LinkButton>
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" Visible="False" Enabled="False">Aceptar</asp:LinkButton>
            <br />
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CausesValidation="False">Atrás</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
    --%>

    <script type="text/javascript">
        function SwitchFiltros() {
            bodyContentPlaceHolder1_TableFiltros
            if(document.getElementById("SpanArrow").innerHTML == "q"){
                document.getElementById("SpanArrow").innerHTML = "p";
                document.getElementById("bodyContentPlaceHolder1_PanelFiltros").style.display = "block";
            }
            else{
                document.getElementById("SpanArrow").innerHTML = "q";
                document.getElementById("bodyContentPlaceHolder1_PanelFiltros").style.display = "none";
            }
        }
    </script>

</asp:Content>
