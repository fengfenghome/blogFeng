using System;
using System.Web.Security;

public partial class MD5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title = Title + SetTitle.getTitle();
        }
    }
    protected void btnCastMd5_Click(object sender, EventArgs e)
    {
        this.lblMd5.Text=FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtCastMd5.Text.Trim(), "MD5");
    }
}
