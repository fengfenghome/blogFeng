using System;
using System.Data.OleDb;

public class Pop
{
	    private int _pid;
    private string _pname;
    private string _pcontent;
    private DateTime _posttime;
    private string _sex;
    private string _adminrev;

    public int pid
    {
        get { return this._pid; }
        set { this._pid = value; }
    }
    public string pname
    {
        get { return this._pname; }
        set { this._pname = value; }
    }
    public string pcontent
    {
        get { return this._pcontent; }
        set { this._pcontent = value; }
    }

    public DateTime posttime
    {
        get { return this._posttime; }
        set { this._posttime = value; }
    }

    public string sex
    {
        get { return this._sex; }
        set { this._sex = value; }
    }

    public string adminrev
    {
        get { return this._adminrev; }
        set { this._adminrev = value; }
    }


    public Pop()
	{
	
	}


    public Pop(string pname,string content,string sex)
    {
        this._pname = pname;
        this._pcontent = content;
        this._sex = sex;
    }
    public Pop(OleDbDataReader dr)
    {
        this._pid = Convert.ToInt32(dr["pid"]);
        this._pname=dr["pname"].ToString();
        this._pcontent = dr["pcontent"].ToString();
        this._posttime = Convert.ToDateTime(dr["posttime"]);
        this._sex = dr["sex"].ToString();
        this._adminrev = dr["adminrev"].ToString();
    }
}
