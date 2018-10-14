<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRadnoVrijeme.aspx.cs" Inherits="Stomatoloska.Webforms.frmRadnoVrijeme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
        <ContentTemplate >
                                <asp:Panel ID="pnlAzuriranje" runat="server" Width="50%" GroupingText="Unos radnog vremena">
        <br />
        Radni dani
        <asp:CheckBoxList ID="CheckBoxListRadniDan" runat="server" RepeatDirection="Horizontal">
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
        <asp:DropDownList ID="DropDownListKrajMinuta" runat="server"></asp:DropDownList>
                                    
                                    <br /><br />
<asp:Button Text="Unesi radno vrijeme" ID="btnUnos" runat="server" OnClick="btnUnos_Click" />


    </asp:Panel>
            <hr />
    <asp:Panel ID="pnlRadnoVrijeme" runat="server" Width="50%" GroupingText="Prikaz radnog vremena">
        <br />
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
    </asp:Panel>

        </ContentTemplate>
       
        </asp:UpdatePanel>

</asp:Content>
