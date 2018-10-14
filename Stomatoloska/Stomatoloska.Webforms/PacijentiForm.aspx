<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PacijentiForm.aspx.cs" Inherits="Stomatoloska.Webforms.PacijentiForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" GroupingText ="Unos i ažuriranje pacijenata">
                Prezime:<asp:TextBox ID="txtPrezime" runat="server" Width="150px"></asp:TextBox><br />
                Ime:<asp:TextBox ID="txtIme" runat="server" Width="150px"></asp:TextBox><br />
                Telefon:<asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox><br />
                Datum rođenja:<asp:TextBox ID="txtDatumRodjenja" runat="server"></asp:TextBox><br />
               
                <ajaxToolkit:CalendarExtender ID="txtDatumRodjenja_CalendarExtender" runat="server" TargetControlID="txtDatumRodjenja" Format="dd.MM.yyyy" />
               
                Adresa:<asp:TextBox ID="txtAdresa" runat="server" Width="300px"></asp:TextBox><br />
                <br /><br />
                <asp:Button ID="btnUnosPacijenta" runat="server" Text="Unos pacijenta" OnClick="btnUnosPacijenta_Click" />

            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" GroupingText ="Pregled pacijenata">
                <asp:GridView ID="gvPacijenti" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                    <Columns>
                        <asp:BoundField DataField="pacijent_id" HeaderText="pacijent_id" SortExpression="pacijent_id" Visible="False" />
                        <asp:BoundField DataField="prezime" HeaderText="Prezime" SortExpression="prezime" />
                        <asp:BoundField DataField="ime" HeaderText="Ime" SortExpression="ime" />
                        <asp:BoundField DataField="datum_rodjenja" HeaderText="Datum rođenja" SortExpression="datum_rodjenja" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="telefon" HeaderText="Telefon" SortExpression="telefon" />
                        <asp:BoundField DataField="adresa" HeaderText="Adresa" SortExpression="adresa" />
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


                <asp:ObjectDataSource ID="ObjectDataSourcePacijenti" runat="server" SelectMethod="PribaviPacijente" TypeName="Stomatoloska.BLL.PacijentBLL"></asp:ObjectDataSource>


            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
