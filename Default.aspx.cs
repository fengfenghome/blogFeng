using System;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = SetTitle.getTitle();
            dataListDatabind();
        }
    }


    private void dataListDatabind()
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
        ps.DataSource = aop.viewAll();
        ps.AllowPaging = true;
        ps.PageSize = 8;
        ps.CurrentPageIndex = currentPage - 1;
        this.Pagination1.pageCount = ps.PageCount;
        this.Pagination1.currentPage = currentPage;
        this.Pagination1.pageUrl = "Default.aspx";
        this.Pagination1.paramName = "p";
        this.DataListViewAllArticle.DataSource = ps;
        this.DataListViewAllArticle.DataBind();
    }
}
