﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNarucivanje.aspx.cs" Inherits="Stomatoloska.Webforms.frmNarucivanje" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate >
            <asp:Panel ID="pnlNarucivanje" runat="server" GroupingText="Naručivanje pacijenta">
                Odabir pacijenta:<br />
                <asp:ListBox ID="lbPacijenti" runat="server" Rows="10" Width="350px"></asp:ListBox> <br /><br />
                <asp:HiddenField ID="HiddenFieldPacijent" runat="server" />
                Odabir zahvata: &nbsp;&nbsp;<asp:DropDownList ID="ddlZahvati" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZahvati_SelectedIndexChanged" > 
                         </asp:DropDownList>&nbsp;&nbsp;
            Cijena zahvata:&nbsp;&nbsp;<asp:Label ID="lblCijenaZahvata" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;Trajanje: &nbsp;&nbsp;<asp:Label ID="lblTrajanjeZahvata" runat="server" ></asp:Label> <br /><br />
                <%--Prezime pacijenta: &nbsp;&nbsp; <asp:TextBox ID="txtPrezime" runat="server" AutoCompleteType="None" ></asp:TextBox><br />
                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtenderPrezime" runat="server" TargetControlID="txtPrezime" BehaviorID="AutoCompleteEX">
                </ajaxToolkit:AutoCompleteExtender>--%>
            
               
                
                
                <asp:Calendar ID="calNarucivanje" runat="server" SelectionMode="DayWeek" OnSelectionChanged="calNarucivanje_SelectionChanged" FirstDayOfWeek="Monday" 
                    SelectedDate="10/16/2018 12:10:15"></asp:Calendar> 
                
                                <h3>Spremanje termina</h3>

                <DayPilot:DayPilotCalendar ID="DayPilotCalendar" runat="server" BusinessBeginsHour="7" 
                    BusinessEndsHour="21" style="top: 0px; left: 0px" ViewType="Day"
                     DataStartField="Start" DataEndField="End" DataTextField="Name" DataValueField="Id" OnEventClick="DayPilotCalendar_EventClick" TimeFormat="Clock24Hours" TimeRangeSelectedHandling="PostBack" EventClickHandling="PostBack" OnTimeRangeSelected="DayPilotCalendar_TimeRangeSelected" />
    
            </asp:Panel>
            
<%-- **************** Modal popup **************************** --%>
            <div id="modal">
  <style type="text/css">
      /*  modal popup */
      .modalBackground {
        background-color:Gray;
        filter:alpha(opacity=70);
        opacity:0.7;
      }

      .modalPopup {
        background-color:#ffffff;
        border-width:3px;
        border-style:solid;
        border-color:Gray;
        padding:3px;
        width:250px;
      }    
  </style>


  <asp:Button ID="ButtonDummyCreate" runat="server" Style="display: none" />

  <ajaxToolkit:ModalPopupExtender ID="ModalPopupCreate" runat="server" TargetControlID="ButtonDummyCreate"
      PopupControlID="PanelPopupCreate" BackgroundCssClass="modalBackground" />
  <asp:Panel ID="PanelPopupCreate" runat="server" CssClass="modalPopup" style="display:none" Width="500px">
      <asp:UpdatePanel ID="UpdatePanelCreate" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
              <asp:Panel runat="server" CssClass="form-group">
                  <h2>Kreiranje termina</h2>
          <div class="col-md-12"  >
              Pacijent:<br />
              <asp:TextBox ID="TextBoxPacijent" runat="server" Enabled ="false" CssClass="form-control "></asp:TextBox>
          </div>
         
          <div class="col-xs-12">
              Naziv:<br />
              <asp:TextBox ID="TextBoxCreateName" runat="server" Enabled ="false" CssClass="form-control"  ></asp:TextBox>
          </div>

          <div class="col-xs-12">
              Start:<br />
              <asp:TextBox ID="TextBoxCreateStart" runat="server" Enabled="false" CssClass="form-control "  ></asp:TextBox>
          </div>

          <div class="col-xs-12">
              End:<br />
              <asp:TextBox ID="TextBoxCreateEnd" runat="server" Enabled="false"  CssClass="form-control " ></asp:TextBox>
          </div><br />
             
          <asp:Button id="ButtonCreateSave" runat="server" Text="Spremi" OnClick="ButtonCreateSave_Click"  CssClass="btn btn-primary col-xs-3"/>&nbsp;&nbsp;
          <asp:Button id="ButtonCreateCancel" runat="server" Text="Odustani" OnClick="ButtonCreateCancel_Click" CssClass="btn btn-default" />

              </asp:Panel>
          
          </ContentTemplate>
      </asp:UpdatePanel>
  </asp:Panel>


  <asp:Button ID="ButtonDummyEdit" runat="server" Style="display: none" />
  <ajaxToolkit:ModalPopupExtender ID="ModalPopupEdit" runat="server" TargetControlID="ButtonDummyEdit"
      PopupControlID="PanelPopupEdit" BackgroundCssClass="modalBackground" />
  <asp:Panel ID="PanelPopupEdit" runat="server" CssClass="modalPopup" style="display:none" Width="500px">
      <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
          <h2>Ažuriranje termina</h2>
          <asp:Panel runat="server" CssClass="form-group" >
              <div class="col-xs-12">
                  Pacijent:<br />
              <asp:TextBox ID="TextBoxPacijentEdit" runat="server" Enabled="false" CssClass="form-control " ></asp:TextBox>
          </div>
          <div class="col-xs-12">
              Zahvat:<br />
              <asp:TextBox ID="TextBoxEditName" runat="server" Enabled="false" CssClass="form-control "  ></asp:TextBox>
          </div>

          <div class="col-xs-12">
              Start:<br />
              <asp:TextBox ID="TextBoxEditStart" runat="server" Enabled ="false" CssClass="form-control " ></asp:TextBox>
          </div>

          <div class="col-xs-12">
              End:<br />
              <asp:TextBox ID="TextBoxEditEnd" runat="server" Enabled="false" CssClass="form-control "  ></asp:TextBox>
          </div>
        <div class="col-md-6">
            Odabir statusa:<br />
             <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control "></asp:DropDownList><br />
          </div><div class="clearfix"></div>
          <asp:HiddenField ID="HiddenEditId" runat="server" />
       
              <div class="col-md-6">
                  <asp:Button id="ButtonEditSave" runat="server" Text="Spremi" OnClick="ButtonEditSave_Click" CssClass="btn btn-primary"/>&nbsp;&nbsp;
          <asp:LinkButton id="ButtonEditCancel" runat="server" Text="Odustani" OnClick="ButtonEditCancel_Click" CssClass="btn btn-default" />
              </div>
          

          </asp:Panel>
              
          </ContentTemplate>
      </asp:UpdatePanel>
  </asp:Panel>
</div>
<%-- ********************** End modal popup ***************************** --%>



        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
