<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false"
    AutoEventWireup="true" CodeFile="modify.aspx.cs" Inherits="modify" Title="编辑文章" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <h2 class="title">
        编辑文章</h2>
    <div class="formbox">
        <p>
            文章标题:
            <asp:TextBox ID="txtTitle" runat="server" Text="" CssClass="formfield" Width="315px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="txtTitle"
                Display="Dynamic" ErrorMessage="*" ValidationGroup="content"></asp:RequiredFieldValidator></p>
        <p>
            文章分类:
            <asp:DropDownList ID="DropDownListClass" runat="server" Width="143px" CssClass="formfield">
            </asp:DropDownList>
            &nbsp; (请选择合适的分类)<asp:Label ID="lblcontext" runat="server" Width="103px"></asp:Label></p>
        <p>
            文章内容:
        <br/>
            &nbsp;
<fck:FCKeditor id="txtBody" runat="server" BasePath="~/Assistant/FCKeditor/" ToolbarStartExpanded="false" Height="380px" />
        <p><br/>
            <asp:Button ID="btnSubmit" runat="server" CssClass="formbutton" OnClick="btnSubmit_Click"
                Text="提 交" ValidationGroup="content" />&nbsp;
            <button name="reset" id="reset" type="reset" class="formbutton">
                重 置</button>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="txtBody"
                Display="Dynamic" ErrorMessage="*" ValidationGroup="content"></asp:RequiredFieldValidator>
            <asp:Label ID="lblMsg" runat="server" Width="106px"></asp:Label></p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>
