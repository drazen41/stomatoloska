<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNarucivanje.aspx.cs" Inherits="Stomatoloska.Webforms.frmNarucivanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Calendar ID="calNarucivanje" runat="server" SelectionMode="DayWeek" OnSelectionChanged="calNarucivanje_SelectionChanged"></asp:Calendar>
    <asp:Panel ID="pnlDnevni" runat="server" >
        <asp:Table ID="tblDnevni" runat="server" >
            <asp:TableHeaderRow runat="server" ID="thrDnevni" >
                
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="pnlTjedni" runat="server" >
        <asp:GridView ID="GridView1" runat="server" DataSourceID="EntityDataSource1">
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>

    </asp:Panel>
</asp:Content>
