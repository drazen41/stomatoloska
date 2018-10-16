<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNarucivanje.aspx.cs" Inherits="Stomatoloska.Webforms.frmNarucivanje" %>
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
            
               
                
                Odabrani termin: &nbsp;&nbsp; <asp:Label ID="lblOdabraniTermin" runat="server"></asp:Label>
                
                <asp:Calendar ID="calNarucivanje" runat="server" SelectionMode="DayWeek" OnSelectionChanged="calNarucivanje_SelectionChanged" FirstDayOfWeek="Monday" 
                    SelectedDate="10/16/2018 12:10:15"></asp:Calendar>
                <DayPilot:DayPilotCalendar ID="DayPilotCalendar" runat="server" BusinessBeginsHour="7" 
                    BusinessEndsHour="21" style="top: 0px; left: 0px" ViewType="Day"
                     DataStartField="Start" DataEndField="End" DataTextField="Name" DataValueField="Id" OnEventClick="DayPilotCalendar_EventClick" TimeFormat="Clock24Hours" />
    
            </asp:Panel>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
