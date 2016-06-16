using System.Data;
using System.Data.OleDb;

public class ExecuteSql
{
    public static bool exec(string sql)
    {
        OleDbConnection con = ConDB.getConnection();
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.CommandType = CommandType.Text;
        if (cmd.ExecuteNonQuery() >= 0)
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

    public static DataTable execDt(string sql)
    {
        OleDbConnection con = ConDB.getConnection();
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt=new DataTable();
        da.Fill(dt);
        return dt;
    }

}
