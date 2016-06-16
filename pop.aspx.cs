using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
            int currentPage;
            try {
                currentPage =Convert.ToInt32(Request.QueryString["p"]);
            }
            catch {
                currentPage = 1;
            }
            if (currentPage == 0)
            {
                currentPage = 1;
            }
            PagedDataSource ps = new PagedDataSource();
            PopOperate op = new PopOperate();
            ps.DataSource = op.viewAll();
            ps.AllowPaging = true;
            ps.CurrentPageIndex = currentPage - 1;
            ps.PageSize = 6;
            this.Pagination1.pageCount = ps.PageCount;
            this.Pagination1.currentPage = currentPage;
            this.Pagination1.pageUrl = "pop.aspx";
            this.Pagination1.paramName = "p";
            this.DataListPop.DataSource = ps;
            this.DataListPop.DataBind();
        }
    }
    protected void btnCommit_ServerClick(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string sex = "1";
            if (this.rbtnNv.Checked)
            {
                sex = "2";
            }
            string pcontent = this.txtPcontent.Text;
            if (pcontent.Length > 500)
            {
                pcontent = pcontent.Substring(0, 500);
            }
            PopOperate po = new PopOperate();
            Pop op = new Pop(Server.HtmlEncode(this.txtPname.Text),Server.HtmlEncode(pcontent), sex);
            if (po.insert(op))
            {
                Response.Redirect("pop.aspx");
            }
            else
            {
                this.lblErrorComment.Text = "呜呜呜，发表失败";
            }
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (this.txtPname.Text.Length > 20)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
}
