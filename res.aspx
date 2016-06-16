<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="res.aspx.cs" Inherits="res" Title="查询结果 " %>

<%@ Register Src="FriendLinks.ascx" TagName="FriendLinks" TagPrefix="uc3" %>
<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
<div id="top">
        <span></span><strong>全部文章</strong></div>
    <ul class="list">
        <asp:DataList ID="DataListArticleList" runat="server">
            <ItemTemplate>
                <li>[<%# Eval("posttime","{0:d}") %>] - <a href="article.aspx?aid=<%# Eval("aid") %>">
                    <%# Eval("title") %>
                </a>(评论:<span style="color:#ff6600"><%# Eval("countcomment") %></span>)</li>
            </ItemTemplate>
        </asp:DataList>
        <uc1:Pagination ID="Pagination1" runat="server" />
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
       <uc3:FriendLinks ID="FriendLinks1" runat="server" />
</asp:Content>

