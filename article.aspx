<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="article.aspx.cs" Inherits="article" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div id="top">
        <span></span><strong>文章内容</strong></div>
    <h2 class="title">
        <asp:Label ID="lbltitle" runat="server"></asp:Label>
    </h2>
    <p class="postdate">
        <asp:Label ID="lblposttime" runat="server"></asp:Label>
        &nbsp; &nbsp; 所属分类:<asp:HyperLink ID="hklist" runat="server">
            <asp:Label ID="lblcname" runat="server"></asp:Label></asp:HyperLink>
    </p>
    <div class="content">
        <p>
            <asp:Label ID="lblcontent" runat="server"></asp:Label>
        </p>
    </div>
    <p id="article-other">
        &laquo; &nbsp;<asp:HyperLink ID="hklastArticle" runat="server">上一篇</asp:HyperLink>
        |
        <asp:HyperLink ID="hknextArticle" runat="server">下一篇</asp:HyperLink>&nbsp; &raquo;</p>
    <h2 class="title">
        <span style="float: right; padding-bottom: 2px; font-size: 12px;">
            <asp:Label ID="lblCommet" runat="server" Text="Label"></asp:Label>
            条记录</span>访客评论</h2>
            <asp:DataList ID="DataListAllComment" runat="server">
                <ItemTemplate>
                    <p class="lesscontent">
                        <%# Eval("comment") %>
                    </p>
                    <p class="lessdate">
                        <%# Eval("cposttime","{0:R}") %><span style="display:none"><%# Eval("comid")%></span>
                    </p>
                </ItemTemplate>
            </asp:DataList>
            <h2 class="title">
                发表评论</h2>
            <div class="formbox">
                <p>
                    &nbsp;<asp:TextBox ID="txtComment" TextMode="MultiLine" runat="server" Columns="95"
                        Rows="8" TabIndex="4" Text=""></asp:TextBox>
                </p>
                &nbsp;<input id="btnCommit" type="button" value="提  交" class="formbutton" onserverclick="btnCommit_ServerClick"
                    runat="server" />
                &nbsp; &nbsp;
                <input id="btnReset" type="reset" value="重  置" class="formbutton" runat="server" />
                &nbsp;
                <asp:Label ID="lblErrorComment" runat="server" Visible="False" Width="148px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment" runat="server" ControlToValidate="txtComment"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>
