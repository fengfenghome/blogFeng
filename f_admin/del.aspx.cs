using System;

public partial class bob5_admin_del : System.Web.UI.Page
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

        int aid = Convert.ToInt32(Request.QueryString["aid"]);
        ArticleOperate aop = new ArticleOperate();
        bool b = aop.delete(aid);
        if (b)
        {
            Response.Redirect("~/refresh.aspx?msg=" + "文章删除成功!");
        }
        else {

            Response.Redirect("~/refresh.aspx?msg=" + "文章删除失败!");
        }
    }
}
