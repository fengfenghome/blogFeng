using System;

public partial class refresh : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = Title + SetTitle.getTitle();
         string msg = Request.QueryString["msg"].ToString();
         this.Label1.Text  = msg;
    }
}
