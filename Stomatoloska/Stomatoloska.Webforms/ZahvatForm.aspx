<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ZahvatForm.aspx.cs" Inherits="Stomatoloska.Webforms.ZahtvatForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
        <ContentTemplate>
            <asp:Panel runat="server" GroupingText="Unos i ažuriranje zahvata">
                 Šifra: &nbsp;&nbsp;
                 <asp:TextBox runat="server" ID="txtSifra"></asp:TextBox>                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorSifra" runat="server" ErrorMessage="Šifra je obavezna" ControlToValidate="txtSifra" ForeColor="Red">*</asp:RequiredFieldValidator>
<br />
            Naziv: &nbsp;&nbsp;
                 <asp:TextBox runat="server" ID="txtNaziv"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorNaziv" runat="server" ErrorMessage="Naziv zahvata je obavezan" ControlToValidate="txtNaziv" ForeColor="Red">*</asp:RequiredFieldValidator><br />
            Cijena:&nbsp;&nbsp;
                 <asp:TextBox runat="server" ID="txtCijena"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCijena" runat="server" ErrorMessage="Cijena je obavezna" ControlToValidate="txtCijena" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidatorCijena" runat="server" ErrorMessage="Cijena je u formatu X,XX" OnServerValidate="CustomValidatorCijena_ServerValidate" ControlToValidate="txtCijena" ForeColor="Red">*</asp:CustomValidator>
                <br />
            Potrebno vrijeme:&nbsp;&nbsp;<asp:DropDownList runat="server" ID="ddlVrijeme">
                <asp:ListItem Text="30 minuta" Value="30"></asp:ListItem>
                <asp:ListItem Text="60 minuta" Value="60"></asp:ListItem>
                <asp:ListItem Text="120 minuta" Value="120"></asp:ListItem>
                                         </asp:DropDownList><br /><br />
                            <asp:Button runat="server" ID="btnUnos" Text="Unesi zahvat" OnClick="btnUnos_Click" />&nbsp;&nbsp;<asp:Button ID="btnCancel" runat="server" visible="false" OnClick="btnCancel_Click" Text="Odustani" />
                <asp:ValidationSummary ID="ValidationSummaryZahvat" runat="server" ForeColor="Red" />
            </asp:Panel>
<asp:Panel runat="server" GroupingText="Pregled zahvata">
    <asp:GridView runat="server" ID="gvZahvati" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="sifra" OnSelectedIndexChanged="gvZahvati_SelectedIndexChanged" OnPreRender="gvZahvati_PreRender" OnRowDeleting="gvZahvati_RowDeleting">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Odaberi" ShowSelectButton="True" />
            <asp:BoundField DataField="sifra" HeaderText="Šifra" SortExpression="sifra" />
            <asp:BoundField DataField="naziv" HeaderText="Naziv" SortExpression="naziv" />
            <asp:BoundField DataField="cijena" HeaderText="Cijena" SortExpression="cijena" />
            <asp:BoundField DataField="trajanje_minuta" HeaderText="Trajanje minuta" SortExpression="trajanje_minuta" />
            <asp:BoundField DataField="dcr" HeaderText="dcr" SortExpression="dcr" Visible="False" />
            <asp:CommandField ButtonType="Button" DeleteText="Obriši" ShowDeleteButton="True" />
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
    <asp:ObjectDataSource ID="ObjectDataSourceZahvat" runat="server" SelectMethod="PribaviZahvate" TypeName="Stomatoloska.BLL.ZahvatBLL"></asp:ObjectDataSource>
</asp:Panel>           


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
