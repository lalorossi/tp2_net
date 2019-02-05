<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportesCursosForm.aspx.cs" Inherits="UI.Web.ReportesCursosForm" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" Style="margin-top: 5%; margin-bottom: 5%">
    <rsweb:ReportViewer ID="reportViewerCursos" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" SizeToReportContent="True" Width="400px">
        <LocalReport ReportPath="ReporteCursos.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursosPro" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoConMasAlumnos" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoConMenosAlumnos" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoMasEficiente" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoMenosEficiente" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoMayorPromedio" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetCursoMenorPromedio" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetDatosCurso" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </asp:Panel>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Business.Entities.ReporteCurso"></asp:ObjectDataSource>
</asp:Content>
