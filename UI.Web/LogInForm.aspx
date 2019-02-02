<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInForm.aspx.cs" Inherits="UI.Web.LogInForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" placeholder="Usuario" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Campo requerido (usuario)" ControlToValidate="txtUser">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" TabIndex="2" type="password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvClave" runat="server" ErrorMessage="Campo requerido (contraseña)" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Ingresar" style="float:right" OnClick="btnLogin_Click"/>
                        <asp:LinkButton ID="btnRegistro" runat="server" Text="Registrarse" style="float:left" Font-Size="Smaller" CausesValidation="False" OnClick="btnRegistro_Click"/>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="vsumLogIn" runat="server" />
            <asp:ListBox ID="lbRegistro" runat="server" Visible="False">
                <asp:ListItem Text="Envíe un mail a algún admin con sus datos para crear la cuenta" />
            </asp:ListBox>
</asp:Content>
