<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainDocente.aspx.cs" Inherits="UI.Web.MainDocente" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow HorizontalAlign="Center">
            <asp:TableCell>
                <asp:Button ID="btnCursos" runat="server" Text="Cursos" onClick="btnCursos_Click"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
