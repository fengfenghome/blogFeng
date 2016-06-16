<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="execsql.aspx.cs" Inherits="bob5_admin_execsql" Title="÷¥––SQL”Ôæ‰" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;«Î ‰»ÎSQL”Ôæ‰<asp:TextBox id="txtSql" runat="server" CssClass="formfield"></asp:TextBox> <asp:Button id="btnExecuteSql" onclick="btnExecuteSql_Click" runat="server" CssClass="formbutton" Width="93px" Text="÷¥––SQL”Ôæ‰"></asp:Button> <asp:Label id="lblExecuteSqlState" runat="server"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gridView1" runat="server" CellPadding="4" 
                GridLines="None" Width="90%" ForeColor="#333333">
        <footerstyle backcolor="#5D7B9D" forecolor="White" Font-Bold="True" />
        <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
        <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
        <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
        <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
        <editrowstyle backcolor="#999999" />
        <alternatingrowstyle backcolor="White" forecolor="#284775" />
    </asp:GridView>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

