using System.Collections.Generic;
using System.Data.OleDb;

public class PopOperate
{
    private OleDbConnection con = null;
    private OleDbCommand cmd = null;

    public PopOperate()
    {
        this.con = ConDB.getConnection();
    }

    public bool insert(Pop pop)
    {
        con.Open();
        cmd = new OleDbCommand("insert into bob_pop(pname,pcontent,posttime,sex) values(@pname,@pcontent,@posttime,@sex)", con);
        cmd.Parameters.Add(new OleDbParameter("@pname", pop.pname));
        cmd.Parameters.Add(new OleDbParameter("@pcontent", pop.pcontent));
        cmd.Parameters.Add(new OleDbParameter("@posttime", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
        cmd.Parameters.Add(new OleDbParameter("@sex", pop.sex));
        if (cmd.ExecuteNonQuery() > 0)
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

    public List<Pop> viewAll()
    {
        List<Pop> list = new List<Pop>();
        con.Open();
        cmd = new OleDbCommand("select * from bob_pop order by posttime desc", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Pop ac;
        while (sdr.Read())
        {
            ac = new Pop(sdr);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public bool update(Pop p)
    {
        con.Open();
        cmd = new OleDbCommand("update bob_pop set adminRev=? where pid=?", con);
        cmd.Parameters.Add(new OleDbParameter("@adminRev", p.adminrev));
        cmd.Parameters.Add(new OleDbParameter("@pid", p.pid));
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
}
