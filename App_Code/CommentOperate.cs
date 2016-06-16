using System.Collections.Generic;
using System.Data.OleDb;

public class CommentOperate
{
    private OleDbConnection con = null;
    private OleDbCommand cmd = null;
    public CommentOperate()
    {
        this.con = ConDB.getConnection();
    }

    public bool insert(Comment ct)
    {
        con.Open();
        cmd = new OleDbCommand("insert into bob_comment(aid,comment,cposttime) values(@aid,@comment,@cposttime)", con);
        cmd.Parameters.Add(new OleDbParameter("@aid", ct.aid));
        cmd.Parameters.Add(new OleDbParameter("@comment", ct.comment));
        cmd.Parameters.Add(new OleDbParameter("@cposttime", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));

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

    public List<Comment> viewAllbyAid(int aid)
    {
        List<Comment> list = new List<Comment>();
        con.Open();
        cmd = new OleDbCommand("select * from bob_comment where aid=" + aid, con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Comment ac;
        while (sdr.Read())
        {
            ac = new Comment(sdr);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }
}
