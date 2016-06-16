using System;
using System.Web.UI.WebControls;

public partial class res : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
            string s;
            try
            {
                s = Request.QueryString["s"].ToString();
                if (s.Length > 20)
                {
                    s = s.Substring(0, 20);
                }
                ArticleOperate aop = new ArticleOperate();
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
                PagedDataSource ps = new PagedDataSource();
                ps.DataSource = aop.search(s);
                ps.AllowPaging = true;
                ps.PageSize = 20;
                ps.CurrentPageIndex = currentPage - 1;
                this.Pagination1.pageCount = ps.PageCount;
                this.Pagination1.paramName = "p";
                this.Pagination1.currentPage = currentPage;
                this.Pagination1.pageUrl = "res.aspx?s="+s;
                this.DataListArticleList.DataSource = ps;
                this.DataListArticleList.DataBind();
            }
            catch
            {
                Response.Redirect("refresh.aspx?msg=" + "输入要查询的关键字!");
            }
        }
    }
}
