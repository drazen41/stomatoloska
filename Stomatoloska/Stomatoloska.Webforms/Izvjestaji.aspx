<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Izvjestaji.aspx.cs" Inherits="Stomatoloska.Webforms.Izvjestaji" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" GroupingText ="Odabir izvještaja">
       Odaberite izvještaj:&nbsp;&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlIzvjestaji" AutoPostBack="True" OnSelectedIndexChanged="ddlIzvjestaji_SelectedIndexChanged"></asp:DropDownList> <br />
      
        
   </asp:Panel>
   <asp:Panel ID="pnlIzvjestaji" runat="server" GroupingText="Izvještaji" Height="700px" Width="700px">
        <rsweb:ReportViewer ID="ReportViewerStomatoloska" runat="server" Height="100%" ProcessingMode="Local" >
          
       </rsweb:ReportViewer>
   </asp:Panel>
</asp:Content>
