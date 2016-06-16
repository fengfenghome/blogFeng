using System;
using System.Collections.Generic;
using System.Data.OleDb;


public class MyClassOperate
{
    private OleDbConnection con = null;
    private OleDbCommand cmd = null;

    public MyClassOperate()
    {
        this.con = ConDB.getConnection();
    }

    public bool insert(MyClass mc)
    {
        con.Open();
        cmd = new OleDbCommand("insert into bob_class(cname,description) values(@cname,@description)", con);
        cmd.Parameters.Add(new OleDbParameter("@cname", mc.cname));
        cmd.Parameters.Add(new OleDbParameter("@description", mc.description));
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


    public List<MyClass> getAllCidCname()
    {
        List<MyClass> list = new List<MyClass>();
        con.Open();
        cmd = new OleDbCommand("select cid,cname from bob_class", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        MyClass myclass;
        while (sdr.Read())
        {
            myclass = new MyClass(Convert.ToInt32(sdr["cid"]), sdr["cname"].ToString());
            list.Add(myclass);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public List<MyClass> viewAll()
    {
        List<MyClass> list = new List<MyClass>();
        con.Open();
        cmd = new OleDbCommand("select * from bob_class_view", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        MyClass myclass;
        while (sdr.Read())
        {
            myclass = new MyClass(sdr);
            list.Add(myclass);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public MyClass getByCid(int cid)
    {

        con.Open();
        cmd = new OleDbCommand("select * from bob_class where cid=" + cid, con);
        OleDbDataReader dr = cmd.ExecuteReader();
        MyClass mc = null;
        while (dr.Read())
        {
            mc = new MyClass();
            mc.cid = Convert.ToInt32(dr["cid"]);
            mc.cname = dr["cname"].ToString();
            mc.description = dr["description"].ToString();
        }
        con.Close();
        return mc;
    }

    public List<MyClass> AdminViewAll()
    {
        List<MyClass> list = new List<MyClass>();
        con.Open();
        cmd = new OleDbCommand("select * from bob_class", con);
        OleDbDataReader dr = cmd.ExecuteReader();
        MyClass mc = null;
        while (dr.Read())
        {
            mc = new MyClass();
            mc.cid = Convert.ToInt32(dr["cid"]);
            mc.cname = dr["cname"].ToString();
            mc.description = dr["description"].ToString();
            list.Add(mc);
        }
        con.Close();
        return list;

    }


    public bool update(MyClass mc)
    {
        con.Open();
        cmd = new OleDbCommand("update bob_class set cname=@cname,description=@description where cid=@cid", con);
        cmd.Parameters.Add(new OleDbParameter("@cname", mc.cname));
        cmd.Parameters.Add(new OleDbParameter("@description", mc.description));
        cmd.Parameters.Add(new OleDbParameter("@cid", mc.cid));
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
}
