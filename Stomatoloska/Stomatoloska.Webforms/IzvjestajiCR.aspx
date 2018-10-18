<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IzvjestajiCR.aspx.cs" Inherits="Stomatoloska.Webforms.IzvjestajiCR" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" GroupingText ="Odabir izvještaja">
       Odaberite izvještaj:&nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlIzvjestaji" AutoPostBack="True" OnSelectedIndexChanged="ddlIzvjestaji_SelectedIndexChanged"></asp:DropDownList> <br />
      
        
   </asp:Panel>
   <asp:Panel ID="pnlIzvjestaji" runat="server" GroupingText="Izvještaji" >
       <CR:CrystalReportViewer ID="CrystalReportViewerStomatoloska" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSourceStomatoloska" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" ToolPanelView="None" />
      
        
       <CR:CrystalReportSource ID="CrystalReportSourceStomatoloska" runat="server">
           
       </CR:CrystalReportSource>
      
        
   </asp:Panel>
</asp:Content>
