<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="pop.aspx.cs" Inherits="pop" Title="" %>

<%@ Register Src="search.ascx" TagName="search" TagPrefix="uc2" %>
<%@ Register Src="FriendLinks.ascx" TagName="FriendLinks" TagPrefix="uc3" %>

<%@ Register Src="Pagination.ascx" TagName="Pagination" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div id="top">
        <span></span><strong>留个脚印吧</strong></div>
    <asp:DataList ID="DataListPop" runat="server">
        <ItemTemplate>
            <div class="content">
                <div style="float: left; width: 80px">
                    <img src="../images/0002.jpg" alt=" " />
                </div>
                                <div style="float: right;width:520px">
                留言者: <%# Eval("pname")%><span style="float:right">
                    <a href="bob5_admin/pop.aspx?p=<%# Eval("pid") %>">回复</a></span>
                <hr />
                    <%# Eval("pcontent")%>
                    <p class="lessdate"> <%# Eval("posttime","{0:g}")%></p>
                 <p style="color:Red">管理员回复 :&nbsp;&nbsp;&nbsp;<%# Eval("adminrev")%></p>
                </div>
            </div>
            <hr />
        </ItemTemplate>
    </asp:DataList>
    <uc1:Pagination ID="Pagination1" runat="server" />
         <div class="formbox">
         &nbsp;
         昵称: <asp:TextBox ID="txtPname" runat="server" Text="" CssClass="formfield"></asp:TextBox>
         &nbsp; &nbsp; 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPname"
             Display="Dynamic" ErrorMessage="*" ValidationGroup="pop"></asp:RequiredFieldValidator>
         <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtPname"
             Display="Dynamic" ErrorMessage="长度大于20" OnServerValidate="CustomValidator1_ServerValidate"
             ValidationGroup="pop"></asp:CustomValidator>
         &nbsp;&nbsp; 性别:<asp:RadioButton
            ID="rbtnNan" GroupName="sex" runat="server" Text="男" Width="45px" Checked="True"/><asp:RadioButton ID="rbtnNv"  GroupName="sex" Text="女" runat="server" Width="46px" />
                <p>
                    &nbsp;<asp:TextBox ID="txtPcontent" TextMode="MultiLine" runat="server" Columns="95"
                        Rows="8" TabIndex="4" Text=""></asp:TextBox>
                </p>
                &nbsp;<input id="btnCommit" type="button" value="提  交" class="formbutton" onserverclick="btnCommit_ServerClick"
                    runat="server" validationgroup="pop" />
                &nbsp; &nbsp;
                <input id="btnReset" type="reset" value="重  置" class="formbutton" runat="server" />
                &nbsp;
                <asp:Label ID="lblErrorComment" runat="server" Visible="False" Width="148px"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorComment" runat="server" ControlToValidate="txtPcontent"
                    ErrorMessage="*" ValidationGroup="pop"></asp:RequiredFieldValidator>最好不要超过500字哦!</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
    <uc2:search ID="Search1" runat="server" />
    <uc3:FriendLinks ID="FriendLinks1" runat="server" />
</asp:Content>
