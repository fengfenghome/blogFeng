using System;
using System.Data.OleDb;

public class MyClass
{

    private int _cid;
    private string _cname;
    private string _description;
    private int _articlecount;

    public int cid
    {
        get { return this._cid; }
        set { this._cid = value; }
    }
    public string cname
    {
        get { return this._cname; }
        set { this._cname = value; }
    }

    public string description
    {
        get { return this._description; }
        set { this._description = value; }
    }

    public int articlecount
    {
        get { return this._articlecount; }
        set { this._articlecount = value; }
    }


    public MyClass()
    {
       
    }

    public MyClass(int cid,string cname)
    {
        this._cid = cid;
        this._cname = cname;
    }

    public MyClass(string classname, string classdescription)
    {
        this._cname = classname;
        this._description = classdescription;
    }

    public MyClass(OleDbDataReader dr)
    {
        this._cid = Convert.ToInt32(dr["cid"]);
        this._cname = Convert.ToString(dr["cname"]);
        this._description = Convert.ToString(dr["description"]);
        this._articlecount = Convert.ToInt32(dr["articlecount"]);
    }

}
