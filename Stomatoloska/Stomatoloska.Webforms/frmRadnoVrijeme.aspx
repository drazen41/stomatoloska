<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRadnoVrijeme.aspx.cs" Inherits="Stomatoloska.Webforms.frmRadnoVrijeme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate >
                                <asp:Panel ID="pnlAzuriranje" runat="server" Width="100%" GroupingText="Unos radnog vremena">
        <br />
        Radni dani
        <asp:CheckBoxList ID="CheckBoxListRadniDan" runat="server" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="2">
            <asp:ListItem>ponedjeljak</asp:ListItem>
            <asp:ListItem>utorak</asp:ListItem>
            <asp:ListItem>srijeda</asp:ListItem>
            <asp:ListItem>četvrtak</asp:ListItem>
            <asp:ListItem>petak</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        Početak radnog vremena:&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListPocetakSat" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="DropDownListPocetakMinuta" runat="server"></asp:DropDownList><br /><br />
        Kraj radnog vremena: &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownListKrajSat" runat="server"></asp:DropDownList>
        <asp:DropDownList ID="DropDownListKrajMinuta" runat="server"></asp:DropDownList><br /><br />
        Od datuma:&nbsp;&nbsp;<asp:TextBox ID="txtOdDatuma" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <ajaxToolkit:CalendarExtender TargetControlID="txtOdDatuma" runat="server" Format="dd.MM.yyyy"  />                   
           <br /><br />                        
                                    
<asp:Button Text="Unesi radno vrijeme" ID="btnUnos" runat="server" OnClick="btnUnos_Click" CssClass="btn btn-primary" />&nbsp;&nbsp;&nbsp;&nbsp;

<asp:Button Text="Odustani" ID="btnOdustani" runat="server" CssClass="btn btn-default" Visible="false" OnClick="btnOdustani_Click"  />

    </asp:Panel>
            <hr />
    <asp:Panel ID="pnlRadnoVrijeme" runat="server" Width="100%" GroupingText="Prikaz radnog vremena">
        <h4>Aktualno radno vrijeme</h4><hr />
        <asp:Table ID="tblRadnoVrijeme" runat="server" >
            <asp:TableHeaderRow >
                <asp:TableCell Text="Radni dan" Width="200px"></asp:TableCell>
                <asp:TableCell Text="Radno vrijeme" Width="150px"></asp:TableCell>
            </asp:TableHeaderRow>
            <asp:TableRow >
                <asp:TableCell Text="Ponedjeljak"></asp:TableCell>
                <asp:TableCell Text="8-16" ID="ponRadnoVrijeme"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Text="Utorak"></asp:TableCell>
                <asp:TableCell Text="8-16" ID="utoRadnoVrijeme"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Text="Srijeda"></asp:TableCell>
                <asp:TableCell Text="8-16" ID="sriRadnoVrijeme"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Text="Četvrtak"></asp:TableCell>
                <asp:TableCell Text="8-16" ID="cetRadnoVrijeme"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell Text="Petak"></asp:TableCell>
                <asp:TableCell Text="8-16" ID="petRadnoVrijeme"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <h4>Sva radna vremena</h4><hr />
        <asp:GridView ID="gvVremena" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceVrijeme" PageSize="30" DataKeyNames="radno_vrijeme_id" OnSelectedIndexChanged="gvVremena_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField SelectText="Odaberi" ShowSelectButton="True" />
                <asp:BoundField DataField="radno_vrijeme_id" HeaderText="radno_vrijeme_id" SortExpression="radno_vrijeme_id" Visible="False" />
                <asp:BoundField DataField="radni_dan" HeaderText="Radni dan" SortExpression="radni_dan" />
                <asp:BoundField DataField="pocetak" HeaderText="Početak" SortExpression="pocetak" />
                <asp:BoundField DataField="kraj" HeaderText="Kraj" SortExpression="kraj" />
                <asp:BoundField DataField="dcr" HeaderText="dcr" SortExpression="dcr" Visible="False" />
                <asp:BoundField DataField="od_datuma" DataFormatString="{0:d}" HeaderText="Od datuma" SortExpression="od_datuma" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSourceVrijeme" runat="server" SelectMethod="PribaviRadnaVremena" TypeName="Stomatoloska.BLL.RadnoVrijemeBLL"></asp:ObjectDataSource>
    </asp:Panel>

        </ContentTemplate>
       
        </asp:UpdatePanel>

</asp:Content>
