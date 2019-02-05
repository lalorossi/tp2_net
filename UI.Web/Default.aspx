<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" Runat="Server">
	<link rel="stylesheet" href="bootstrap/projection/assets/css/main.css" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    <h2>
        Bienvenido al Sistema Académico de la UTN Facultad Regional de Rosario
    </h2>
    <asp:panel runat="Server" style="text-align: center; margin-top: 5%; margin-bottom: 5%">
        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/utn.png" style=""/>
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click"/>
    </asp:panel>
</asp:Content>
