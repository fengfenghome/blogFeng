using System;
using System.Web.UI;

public partial class modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["admin"]) != "admin")
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能对文章进行相关的操作!");
            return;
        }
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
            MyClassOperate mop = new MyClassOperate();
            this.DropDownListClass.DataSource = mop.getAllCidCname();
            this.DropDownListClass.DataTextField = "cname";
            this.DropDownListClass.DataValueField = "cid";
            this.DropDownListClass.DataBind();
            try
            {
                int aid = Convert.ToInt32(Request.QueryString["aid"]);
                Article at = (new ArticleOperate()).getByAid(aid);
                if (at == null || at.Equals(null))
                {
                    this.lblcontext.Text = "对不起,此文章不存在,或被管理员删除";
                }
                else
                {
                    this.txtTitle.Text = at.title;
                    Page.Title = at.title + Title;
                    this.DropDownListClass.SelectedValue = at.cid.ToString();
                    this.txtBody.Value = at.content;
                }
            }
            catch
            {
                Response.Redirect("~/refresh.aspx?msg=" + "此文章不存在,或被管理员删除,请见谅!");
            }
        }
       
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int aid = Convert.ToInt32(Request.QueryString["aid"]);
        string title = this.txtTitle.Text.ToString();
        int cid = Convert.ToInt32(this.DropDownListClass.SelectedValue);
        string content = this.txtBody.Value;
        ArticleOperate aop = new ArticleOperate();
        Article ac = new Article(aid, cid, title, content);
        bool b = aop.update(ac);
        if (b)
        {
            Response.Redirect("~/refresh.aspx?msg=" + "恭喜你,更新成功!");
        }
        else
        {
            this.lblMsg.Text = "很遗憾,更新失败,请重新尝试!";
        }

    }
}
