<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PregledNarudzbi.aspx.cs" Inherits="Stomatoloska.Webforms.PregledNarudzbi" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
            <asp:Panel ID="pnlNarucivanje" runat="server" GroupingText="Pregled narudžbi">
               
            
               
                
                
                <asp:Calendar ID="calNarucivanje" runat="server" SelectionMode="DayWeek" OnSelectionChanged="calNarucivanje_SelectionChanged" FirstDayOfWeek="Monday" 
                    SelectedDate="10/16/2018 12:10:15"></asp:Calendar> 
                
                                <h3>Pregled termina</h3>

                <DayPilot:DayPilotCalendar ID="DayPilotCalendar" runat="server" BusinessBeginsHour="7" 
                    BusinessEndsHour="21" style="top: 0px; left: 0px" ViewType="Day"
                     DataStartField="Start" DataEndField="End" DataTextField="Name" DataValueField="Id" 
                    OnEventClick="DayPilotCalendar_EventClick" TimeFormat="Clock24Hours" TimeRangeSelectedHandling="PostBack" 
                    EventClickHandling="PostBack" OnTimeRangeSelected="DayPilotCalendar_TimeRangeSelected" DayFontSize="12pt" 
                    DurationBarColor="Blue" OnBeforeEventRender="DayPilotCalendar_BeforeEventRender"  />
    
            </asp:Panel>
            



        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
