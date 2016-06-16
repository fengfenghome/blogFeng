using System;

public partial class article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = SetTitle.getTitle();
            try
            {
                int aid = Convert.ToInt32(Request.QueryString["aid"]);
                Article at = (new ArticleOperate()).getByAid(aid);
                if (at == null || at.Equals(null))
                {
                    this.Page.Title = "此文章不存在,或被管理员删除" + " " + Title;
                    this.lblcontent.Text = "此文章不存在,或被管理员删除";

                    this.txtComment.Text = "此文章不存在,无法发表评论";
                    this.txtComment.Enabled = false;
                    this.btnCommit.EnableTheming = false;
                }
                else
                {
                    this.lbltitle.Text = at.title;
                    this.Page.Title = at.title + " " + Title;
                    this.lblposttime.Text = at.posttime.ToString();
                    this.lblcontent.Text = at.content;
                    this.lblcname.Text = at.cname;
                    this.hklist.NavigateUrl = "list.aspx?cid=" + at.cid.ToString();
                    this.hklastArticle.NavigateUrl = "article.aspx?aid=" + (at.aid - 1).ToString();
                    this.hknextArticle.NavigateUrl = "article.aspx?aid=" + (at.aid + 1).ToString();
                    this.lblCommet.Text = at.countcomment.ToString();
                    CommentOperate cop = new CommentOperate();
                    this.DataListAllComment.DataSource = cop.viewAllbyAid(aid);
                    this.DataListAllComment.DataBind();
                }
            }
            catch
            {
                Response.Redirect("refresh.aspx?msg=" + "此文章不存在,或被管理员删除!");
            }
        }
    }
    protected void btnCommit_ServerClick(object sender, EventArgs e)
    {
        int aid = Convert.ToInt32(Request.QueryString["aid"]);
        CommentOperate cp = new CommentOperate();
        string comment = Server.HtmlEncode(this.txtComment.Text.ToString());
        if (comment.Length > 250)
        {
            comment = comment.Substring(0, 250);
        }
        Comment ct = new Comment(aid, comment);
        bool b = cp.insert(ct);
        if (b)
        {
            this.lblErrorComment.Visible = false;
            this.DataListAllComment.DataBind();
            Response.Redirect("article.aspx?aid=" + aid);
        }
        else
        {
            this.lblErrorComment.Visible = true;
            this.lblErrorComment.Text = "评论发表失败,请重新尝试!";
        }
    }
}
