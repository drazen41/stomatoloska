<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NarucivanjeForm.aspx.cs" Inherits="Stomatoloska.Webforms.frmNarucivanje" %>

<%@ Register Assembly="Syncfusion.EJ.Web" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
            <asp:Panel ID="pnlNarucivanje" runat="server" GroupingText="Naručivanje pacijenta">
                Odabir pacijenta:<br />
                <asp:ListBox ID="lbPacijenti" runat="server" Rows="10" Width="350px"></asp:ListBox> <br /><br />
                Odabir zahvata: &nbsp;&nbsp;<asp:DropDownList ID="ddlZahvati" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZahvati_SelectedIndexChanged" > 
                         </asp:DropDownList>&nbsp;&nbsp;
            Cijena zahvata:&nbsp;&nbsp;<asp:Label ID="lblCijenaZahvata" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Trajanje: &nbsp;&nbsp;<asp:Label ID="lblTrajanjeZahvata" runat="server" ></asp:Label> <br /><br />
                <%--Prezime pacijenta: &nbsp;&nbsp; <asp:TextBox ID="txtPrezime" runat="server" AutoCompleteType="None" ></asp:TextBox><br />
                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtenderPrezime" runat="server" TargetControlID="txtPrezime" BehaviorID="AutoCompleteEX">
                </ajaxToolkit:AutoCompleteExtender>--%>
            
                <ej:DatePicker ID="Datepicker1" runat="server"></ej:DatePicker>
                
                Odabrani termin: &nbsp;&nbsp; <asp:Label ID="lblOdabraniTermin" runat="server"></asp:Label>
                
    
            </asp:Panel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
