using System;
using System.Web.UI;

public partial class bob5_admin_ClassManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
        }
        if (Convert.ToString(Session["admin"]) != "admin")
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能对文章进行相关的操作!");
            return;
        }
    }
    protected void btnCommit_Click(object sender, EventArgs e)
    {
        MyClass mc = new MyClass();
        mc.cname = this.txtCname.Text.Trim();
        mc.description = this.txtDescription.Text.Trim();
        MyClassOperate mop = new MyClassOperate();
        if (mop.insert(mc))
        {
            Response.Redirect("ClassManage.aspx");
            Page.DataBind();
        }
        else
        {
            this.lblExecuteSqlState.Text = "添加失败!";
        }

    }
    protected void btnExecuteSql_Click(object sender, EventArgs e)
    {
        if (ExecuteSql.exec(this.txtSql.Text.Trim()))
        {
            this.lblExecuteSqlState.Text = "执行成功!";
            Page.DataBind();
        }
        else
        {
            this.lblExecuteSqlState.Text = "执行失败!";
        }
        this.txtSql.Text = "";
    }
}
