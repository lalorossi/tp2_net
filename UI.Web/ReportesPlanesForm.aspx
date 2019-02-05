<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportesPlanesForm.aspx.cs" Inherits="UI.Web.ReportesPlanes" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel ID="Panel1" runat="server" Style="margin-top: 5%; margin-bottom: 5%">
    
        <rsweb:ReportViewer ID="reportViewerPlanes" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" SizeToReportContent="True" Width="400px">
            <LocalReport ReportPath="ReportePlanes.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetPlanes" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSetMasComisiones" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSetMenosComisiones" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSetMasMaterias" />
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource5" Name="DataSetMenosMaterias" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" TypeName="Business.Entities.ReportePlanes"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" TypeName="Business.Entities.ReportePlanes"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" TypeName="Business.Entities.ReportePlanes"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" TypeName="Business.Entities.ReportePlanes"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="Business.Entities.ReportePlanes"></asp:ObjectDataSource>

    </asp:Panel>

</asp:Content>
