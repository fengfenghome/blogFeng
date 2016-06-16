<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pop.aspx.cs" Inherits="bob5_admin_pop" Title="回复留言" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
  <h2 class="title">
               管理员回复留言</h2>
            <div class="formbox">
                <p>
                    &nbsp;<asp:TextBox ID="txtPopRev" TextMode="MultiLine" runat="server" Columns="95"
                        Rows="8" TabIndex="4" Text=""></asp:TextBox>
                </p>
                &nbsp;<input id="btnCommit" type="button" value="提  交" class="formbutton" onserverclick="btnCommit_ServerClick"
                    runat="server" />
                &nbsp; &nbsp;
                <input id="btnReset" type="reset" value="重  置" class="formbutton" runat="server" />
                &nbsp;
                <asp:Label ID="lblErrorComment" runat="server" Visible="False" Width="148px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment" runat="server" ControlToValidate="txtPopRev"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>

