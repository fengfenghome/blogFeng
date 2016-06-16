using System;
using System.Web.UI.WebControls;

public partial class bob_admin_list : System.Web.UI.Page
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
            try
            {
                int currentPage;
                try
                {
                    currentPage = Convert.ToInt32(Request.QueryString["p"]);
                }
                catch
                {
                    currentPage = 1;
                }
                if (currentPage == 0)
                {
                    currentPage = 1;
                }
                ArticleOperate aop = new ArticleOperate();
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = aop.viewList();
                ps.AllowPaging = true;
                ps.PageSize = 20;
                ps.CurrentPageIndex = currentPage - 1;
                this.Pagination1.pageCount = ps.PageCount;
                this.Pagination1.currentPage = currentPage;
                this.Pagination1.pageUrl = "list.aspx";
                this.Pagination1.paramName = "p";
                this.DataListArticleList.DataSource = ps;
                this.DataListArticleList.DataBind();
            }
            catch
            {
                Response.Redirect("~/refresh.aspx?msg=" + "显示出错,请稍候尝试!");
            }
        }
    }
}
