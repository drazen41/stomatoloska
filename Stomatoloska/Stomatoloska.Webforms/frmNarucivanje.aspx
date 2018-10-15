<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNarucivanje.aspx.cs" Inherits="Stomatoloska.Webforms.frmNarucivanje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
            <asp:Panel ID="pnlNarucivanje" runat="server" GroupingText="Naručivanje pacijenta">
                Odabir zahvata: &nbsp;&nbsp;<asp:DropDownList ID="ddlZahvati" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZahvati_SelectedIndexChanged" > 
                         </asp:DropDownList>&nbsp;&nbsp;
            Cijena zahvata:&nbsp;&nbsp;<asp:Label ID="lblCijenaZahvata" runat="server" ></asp:Label><br /><br />
                <%--Prezime pacijenta: &nbsp;&nbsp; <asp:TextBox ID="txtPrezime" runat="server" AutoCompleteType="None" ></asp:TextBox><br />
                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtenderPrezime" runat="server" TargetControlID="txtPrezime" BehaviorID="AutoCompleteEX">
                </ajaxToolkit:AutoCompleteExtender>--%>
            Odabir pacijenta:<br />
                <asp:ListBox ID="lbPacijenti" runat="server" Rows="10" Width="350px"></asp:ListBox> <br /><br />
                
                
                
                <asp:Calendar ID="calNarucivanje" runat="server" SelectionMode="DayWeek" OnSelectionChanged="calNarucivanje_SelectionChanged"></asp:Calendar>
    <asp:Panel ID="pnlDnevni" runat="server" >
        <asp:Table ID="tblDnevni" runat="server" >
            <asp:TableHeaderRow runat="server" ID="thrDnevni" >
                
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <asp:Panel ID="pnlTjedni" runat="server" >
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </asp:Panel>
            </asp:Panel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
