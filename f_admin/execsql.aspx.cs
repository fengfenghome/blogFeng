using System;
using System.Data;

public partial class bob5_admin_execsql : System.Web.UI.Page
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
    protected void btnExecuteSql_Click(object sender, EventArgs e)
    {
        string sql = this.txtSql.Text.Trim();

        if (sql.ToUpper().StartsWith("SELECT"))
        {
            try
            {
                DataTable dt = ExecuteSql.execDt(sql);
                this.gridView1.Visible = true;
                this.gridView1.DataSource = dt;
                this.gridView1.DataBind();
                this.lblExecuteSqlState.Text = "执行成功!";
            }
            catch(Exception ex)
            {
                this.lblExecuteSqlState.Text = ex.Message;
            }
        }
        else
        {
            this.gridView1.Visible = false;
            if (ExecuteSql.exec(sql))
            {
                this.lblExecuteSqlState.Text = "执行成功!";
            }
            else
            {
                this.lblExecuteSqlState.Text = "执行失败!";

            }
        }
        this.txtSql.Text = "";
    }
}
