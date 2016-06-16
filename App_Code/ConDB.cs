using System.Data.OleDb;
using System.Configuration;


public class ConDB
{
    public ConDB()
    {

    }

    //public static SqlConnection getConnection(int i)
    //{
    //    return new SqlConnection(ConfigurationManager.ConnectionStrings["blogConnectionString"].ConnectionString);
    //}

    public static OleDbConnection getConnection()
    {
        string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="  + System.Web.HttpContext.Current.Server.MapPath("~/App_Data/blogF.mdb")+ ";Persist Security Info=false";
        //string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["blogMdbPath"].ConnectionString) + ";Persist Security Info=False";

        return new OleDbConnection(connstring);
    }
}
