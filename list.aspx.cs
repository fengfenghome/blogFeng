using System;
using System.Web.UI.WebControls;


public partial class list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
            try
            {
                int cid = Convert.ToInt32(Request.QueryString["cid"]);
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
                ps.DataSource = aop.viewAllByCid(cid);
                ps.AllowPaging = true;
                ps.PageSize = 20;
                ps.CurrentPageIndex = currentPage - 1;
                this.Pagination1.currentPage = currentPage;
                this.Pagination1.pageCount = ps.PageCount;
                this.Pagination1.pageUrl = "list.aspx?cid=" + cid;
                this.Pagination1.paramName = "p";
                MyClassOperate mop = new MyClassOperate();
                this.Page.Title = (mop.getByCid(cid)).cname + this.Page.Title;
                this.DataListArticleList.DataSource = ps;
                this.DataListArticleList.DataBind();
            }
            catch 
            {
                Response.Redirect("refresh.aspx?msg=" + "没有此分类的信息");
            }
        }
    }
}
