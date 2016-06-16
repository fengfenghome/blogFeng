using System;
using System.Collections.Generic;
using System.Data.OleDb;

public class ArticleOperate
{
    private OleDbConnection con = null;
    private OleDbCommand cmd = null;

    public ArticleOperate()
    {
        this.con = ConDB.getConnection();
    }

    public bool insert(Article at)
    {
        con.Open();
        cmd = new OleDbCommand("insert into bob_article(cid,title,content,posttime) values(@cid,@title,@content,@posttime)", con);
        cmd.Parameters.Add(new OleDbParameter("@cid", at.cid));
        cmd.Parameters.Add(new OleDbParameter("@title", at.title));
        cmd.Parameters.Add(new OleDbParameter("@content", at.content));
        cmd.Parameters.Add(new OleDbParameter("@posttime", System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
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

    public Article getByAid(int aid)
    {
        con.Open();
        cmd = new OleDbCommand("select * from bob_article_view where aid=" + aid, con);
        OleDbDataReader dr = cmd.ExecuteReader();
        Article ac = null;
        while (dr.Read())
        {
            ac = new Article(dr);
        }
        con.Close();
        return ac;
    }

    public bool delete(int aid)
    {
        con.Open();
        cmd = new OleDbCommand("delete from bob_article where aid=" + aid, con);
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
    public List<Article> viewAll()
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new OleDbCommand("select * from bob_article_view order by posttime desc", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
            ac.aid = Convert.ToInt32(sdr["aid"]);
            ac.cid = Convert.ToInt32(sdr["cid"]);
            ac.title = sdr["title"].ToString();
            ac.content = sdr["content"].ToString();
            if (ac.content.Length > 200)
            {
                ac.content = ac.content.Substring(0, 200);
            }
            ac.posttime = Convert.ToDateTime(sdr["posttime"]);
            ac.countcomment = Convert.ToInt32(sdr["countcomment"]);
            ac.cname = sdr["cname"].ToString();
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public List<Article> viewAllByCid(int cid)
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new OleDbCommand("select aid,title,posttime,countcomment from bob_article_view where cid=" + cid + " order by posttime desc", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
            ac.aid = Convert.ToInt32(sdr["aid"]);
            ac.title = sdr["title"].ToString();
            ac.posttime = Convert.ToDateTime(sdr["posttime"]);
            ac.countcomment = Convert.ToInt32(sdr["countcomment"]);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public List<Article> viewList()
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new OleDbCommand("select aid,title,posttime,countcomment from bob_article_view order by posttime desc", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
            ac.aid = Convert.ToInt32(sdr["aid"]);
            ac.title = sdr["title"].ToString();
            ac.posttime = Convert.ToDateTime(sdr["posttime"]);
            ac.countcomment = Convert.ToInt32(sdr["countcomment"]);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public List<Article> search(string s)
    {
        List<Article> list = new List<Article>();
        con.Open();
        cmd = new OleDbCommand("select aid,title,posttime,countcomment from bob_article_view where title like '%" + s + "%' order by posttime desc", con);
        OleDbDataReader sdr = cmd.ExecuteReader();
        Article ac;
        while (sdr.Read())
        {
            ac = new Article();
            ac.aid = Convert.ToInt32(sdr["aid"]);
            ac.title = sdr["title"].ToString();
            ac.posttime = Convert.ToDateTime(sdr["posttime"]);
            ac.countcomment = Convert.ToInt32(sdr["countcomment"]);
            list.Add(ac);
        }
        sdr.Close();
        con.Close();
        return list;
    }

    public bool update(Article ac)
    {
        con.Open();
        cmd = new OleDbCommand("update bob_article set cid=@cid,title=@title,content=@content where aid=@aid", con);
        cmd.Parameters.Add(new OleDbParameter("@cid", ac.cid));
        cmd.Parameters.Add(new OleDbParameter("@title", ac.title));
        cmd.Parameters.Add(new OleDbParameter("@content", ac.content));
        cmd.Parameters.Add(new OleDbParameter("@aid", ac.aid));
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
