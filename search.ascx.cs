using System;

public partial class search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string s = this.txtSearch.Text;
        Response.Redirect("res.aspx?s="+s);
    }
}
