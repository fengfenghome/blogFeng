using System;

public partial class post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["admin"]) != "admin")
        {
            Response.Redirect("~/refresh.aspx?msg=" + "对不起,只有管理员才能登陆发表文章!");
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
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string title = this.txtTitle.Text.ToString();
        int cid = Convert.ToInt32(this.DropDownListClass.SelectedValue);
        string content = this.txtBody.Value;
        ArticleOperate aop = new ArticleOperate();
        Article ac = new Article(cid, title, content);
        bool b = aop.insert(ac);
        if(b)
        {
            Response.Redirect("~/refresh.aspx?msg="+"恭喜你,发表成功!"); 
        }
        else{
            this.lblMsg.Text = "很遗憾,发表失败,请重新尝试!";
        }
    }
}
