using System;
using System.Data.OleDb;

public class Article
{
    private int _aid;
    private int _cid;
    private string _title;
    private string _content;
    private DateTime _posttime;
    private int _countcomment;
    private string _cname;

    public int aid
    {
        get { return this._aid;}
        set { this._aid = value; }
    }

    public int cid
    {
        get { return this._cid; }
        set { this._cid = value; }
    }

    public string title
    {
        get { return this._title; }
        set { this._title = value; }
    }

    public string content
    {
        get { return this._content; }
        set { this._content = value; }
    }

    public DateTime posttime
    {
        get { return this._posttime; }
        set { this._posttime = value; }
    }

    public int countcomment
    {
        get { return this._countcomment; }
        set { this._countcomment = value; }
    }

    public string cname
    {
        get { return this._cname; }
        set { this._cname = value; }
    }

	public Article()
	{
		
	}

    public Article(int cid, string title, string content)
    {
        this._cid = cid;
        this._title = title;
        this._content = content;
    }

    public Article(int aid,int cid,string title,string content)
    {
        this._aid = aid;
        this._cid = cid;
        this._title = title;
        this._content = content;
    }

    public Article(OleDbDataReader dr)
    {
        this._aid = Convert.ToInt32(dr["aid"]);
        this._cid = Convert.ToInt32(dr["cid"]);
        this._title = dr["title"].ToString();
        this._content = dr["content"].ToString();
        this._posttime = Convert.ToDateTime(dr["posttime"]);
        this._countcomment = Convert.ToInt32(dr["countcomment"]);
        this._cname = dr["cname"].ToString();
    }

}
