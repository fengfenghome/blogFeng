using System;
using System.Data;
using System.Web.UI;

public partial class FriendLinks : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet dt = new DataSet();
            dt.ReadXml(Server.MapPath("FriendsLink.xml"));
            this.DataListFriendsLinks.DataSource = dt;
            this.DataListFriendsLinks.DataBind();
           
        }
    }

}
