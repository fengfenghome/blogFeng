<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="search" %>
<div class="sambar">

    <br />
   &nbsp; <asp:TextBox ID="txtSearch" runat="server" CssClass="formfield" Width="110px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorSearch" runat="server" ControlToValidate="txtSearch"
        Display="Dynamic" ErrorMessage="*" ValidationGroup="search"></asp:RequiredFieldValidator>
    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="formbutton" ValidationGroup="search" OnClick="btnSearch_Click" />
</div>
