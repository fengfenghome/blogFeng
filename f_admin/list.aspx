<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="list.aspx.cs" Inherits="bob_admin_list" Title="管理文章" %>

<%@ Register Src="../Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div id="top">
        <span></span><strong>全部文章</strong></div>
    <ul class="list">
        <asp:DataList ID="DataListArticleList" runat="server">
            <ItemTemplate>
                <li>[<%# Eval("posttime","{0:d}") %>] - <a href="../article.aspx?aid=<%# Eval("aid") %>">
                    <%# Eval("title") %>
                </a>(评论:<span style="color:#ff6600"><%# Eval("countcomment") %></span>) <span><a href="modify.aspx?aid=<%# Eval("aid") %>">
                     <span style="color:Red">--- 编 辑</span></a><a href="del.aspx?aid=<%# Eval("aid") %>">
                   <span style="color:Red">-删 除</span> </a>
                   </span></li>
            </ItemTemplate>
        </asp:DataList>
        <uc1:Pagination ID="Pagination1" runat="server" />
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>
