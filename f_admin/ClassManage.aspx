<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClassManage.aspx.cs" Inherits="bob5_admin_ClassManage" Title="分类管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderMain" runat="Server">
    <div id="top">
        <span></span><strong>分类管理</strong></div>
    <br />
    <h2 class="title">
        添加分类</h2>
   
    <asp:GridView ID="GridViewClassManage" runat="server" Width="650px" AutoGenerateColumns="False"
        DataSourceID="ObjectDataSourceAdminViewClass" CssClass="sambar">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="cid" HeaderText="分类ID" SortExpression="cid" ReadOnly="True" />
            <asp:BoundField DataField="cname" HeaderText="分类名" SortExpression="cname" />
            <asp:BoundField DataField="description" HeaderText="分类描述" SortExpression="description" />
        </Columns>
        <RowStyle CssClass="list" />
    </asp:GridView>
    分类名:&nbsp;
    <asp:TextBox ID="txtCname" runat="server" CssClass="formfield" Text="" Width="182px"></asp:TextBox>
    <br />
    分类描述<asp:TextBox ID="txtDescription" runat="server" Text="" CssClass="formfield" Width="183px"></asp:TextBox>
            <br />
    <br />
    <asp:Button ID="btnCommit" runat="server" CssClass="formbutton" OnClick="btnCommit_Click"
        Text="提 交" />&nbsp; &nbsp;<input id="Reset1" class="formbutton" type="reset" value="重 置" /><br />
            <br />
            请输入SQL语句<asp:TextBox ID="txtSql" runat="server" CssClass="formfield"></asp:TextBox>
            <asp:Button ID="btnExecuteSql" runat="server" CssClass="formbutton" OnClick="btnExecuteSql_Click"
                Text="执行SQL语句" Width="93px" />
            <asp:Label ID="lblExecuteSqlState" runat="server"></asp:Label>
      
    <br />
    &nbsp;<br />
    <asp:ObjectDataSource ID="ObjectDataSourceAdminViewClass" runat="server" DataObjectTypeName="MyClass" SelectMethod="AdminViewAll" TypeName="MyClassOperate" UpdateMethod="update">
    </asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" runat="Server">
</asp:Content>
