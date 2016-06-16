using System;
using System.Data.OleDb;

public class Comment
{
    private int _comid;
    private int _aid;
    private string _comment;
    private DateTime _cposttime;

    public int comid
    {
        get { return this._comid; }
        set { this._comid = value; }
    }
    public int aid
    {
        get { return this._aid; }
        set { this._aid = value; }
    }
    public string comment
    {
        get { return this._comment; }
        set { this._comment = value; }
    }

    public DateTime cposttime
    {
        get { return this._cposttime; }
        set { this._cposttime = value; }
    }


	public Comment()
	{
		
	}
    public Comment(int aid,string comment)
    {
        this._aid = aid;
        this._comment = comment;
    }
    public Comment(OleDbDataReader dr)
    {
        this._comid = Convert.ToInt32(dr["comid"]);
        this._comment = dr["comment"].ToString();
        this._cposttime =Convert.ToDateTime(dr["cposttime"]);
    }
}
