using System.Data.OleDb;
using System.Web.Security;
public class AdminLogin
{

    public AdminLogin()
    {

    }

    public static bool Login(string admin_name, string admin_pwd)
    {
        string name = FormsAuthentication.HashPasswordForStoringInConfigFile(admin_name.Trim(), "MD5");
        string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(admin_pwd.Trim(), "MD5");
        bool b = false;
        OleDbConnection con = ConDB.getConnection();
        try
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select admin_pwd from bob_admin where admin_name='" + name + "'", con);
            string db_pwd = cmd.ExecuteScalar().ToString().Trim();
            b = pwd.Equals(db_pwd);
            if (b)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        catch
        {
            con.Close();
            return false;
        }
    }

}
