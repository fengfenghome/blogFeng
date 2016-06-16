<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Description="chenzz's personal website" %>

<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc2" %>
<%@ Register Src="FriendLinks.ascx" TagName="FriendLinks" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div id="top">
        <span></span><strong>全部文章</strong></div>
    <asp:DataList ID="DataListViewAllArticle" runat="server">
        <ItemTemplate>
            <h2 class="posttitle">
                <a href="article.aspx?aid=<%# Eval("aid") %>">
                    <%# Eval("title") %>
                </a>
            </h2>
            <p class="postdate">
                <%# Eval("posttime","{0:R}") %>
            </p>
            <div class="content"><p>
                <%# Eval("content") %></p>
                <p>
                    &raquo; <a href="article.aspx?aid=<%# Eval("aid") %>">马上阅读</a></p>
            </div>
            <p class="postmetadata">
                &nbsp; 分类: <a href="list.aspx?cid=<%# Eval("cid") %>">
                    <%# Eval("cname") %>
                </a>| <a href="">评论</a>:<%# Eval("countcomment") %>
            </p>
        </ItemTemplate>
    </asp:DataList>
    <uc2:Pagination ID="Pagination1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
   
    <uc1:FriendLinks ID="FriendLinks1" runat="server" />
</asp:Content>
