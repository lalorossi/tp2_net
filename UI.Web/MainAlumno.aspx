<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainAlumno.aspx.cs" Inherits="UI.Web.MainAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnCursos" runat="server" Text="Cursos" onClick="btnCursos_Click"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnInscripcionCursos" runat="server" Text="Inscripción a Cursos" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnEstadoAcademico" runat="server" Text="Estado Académico" />
            </asp:TableCell>
        </asp:TableRow>
        
    </asp:Table>

</asp:Content>
