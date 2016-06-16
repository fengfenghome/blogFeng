using System;
using System.Web.UI;

public partial class bob5_admin_pop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Title + SetTitle.getTitle();
        if (Convert.ToString(Session["admin"]) == "admin")
        {
            int pid;
            try
            {
                pid = Convert.ToInt32(Request.QueryString["p"]);
            }
            catch
            {
                Response.Redirect("~/refresh.aspx?msg=" + "对不起,请选中要回复的留言");
            }
        }
        else
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能对文章进行相关的操作!");
        }
       
    }
    protected void btnCommit_ServerClick(object sender, EventArgs e)
    {
        int pid = Convert.ToInt32(Request.QueryString["p"]);
        ClientScriptManager cs = this.ClientScript;
        Pop p = new Pop();
        p.pid = pid;
        p.adminrev = this.txtPopRev.Text;
        PopOperate po = new PopOperate();
        bool b = po.update(p);
        if (b)
        {
            Response.Redirect("~/pop.aspx");

        }
        else
        {
            this.lblErrorComment.Text = "回复出错，请重新尝试";
        }
    }
}
