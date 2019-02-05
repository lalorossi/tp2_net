<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainAdmin.aspx.cs" Inherits="UI.Web.MainAdmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnCursos" runat="server" Text="Cursos" OnClick="btnCursos_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnMaterias" runat="server" Text="Planes/Materias (*)" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnEspecialidades" runat="server" Text="Especialidades" OnClick="btnEspecialidades_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnAlumnos" runat="server" Text="Alumnos (*)" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnDocentes" runat="server" Text="Docentes (*)" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnReporteCursos" runat="server" Text="Reporte Cursos" OnClick="btnReporteCursos_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnReportePlanes" runat="server" Text="Reporte Planes" OnClick="btnReportePlanes_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
