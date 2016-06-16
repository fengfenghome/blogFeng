<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MD5.aspx.cs" Inherits="MD5" Title="MD5加密" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <asp:UpdatePanel id="UpdatePanelMD5" runat="server">
        <contenttemplate>
输入要加密的字符:<asp:TextBox id="txtCastMd5" runat="server" CssClass="formfield" Width="313px"></asp:TextBox> <br /><br /><asp:Label id="lblMd5" runat="server"></asp:Label><br /><br /><asp:Button id="btnCastMd5" onclick="btnCastMd5_Click" runat="server" CssClass="formbutton" Text="MD5"></asp:Button> 
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>
