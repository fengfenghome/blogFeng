using System;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {


       
        if (!Page.IsPostBack)
        {
            MyClassOperate mco = new MyClassOperate();
          
        }
        if (Convert.ToString(Session["admin"]) == "admin")
        {
            this.txtUsername.Visible = false;
            this.txtPassword.Visible = false;
            this.btnLogin.Visible = false;
            this.Label1.Visible = true;
            this.btnRevLogin.Visible = false;
            this.Label1.Text = "see you again!";
            this.pnLogin.Visible = true;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.txtUsername.Visible = false;
        this.txtPassword.Visible = false;
        this.btnLogin.Visible = false;
        this.Label1.Visible = true;
        string name = this.txtUsername.Text.ToString();
        string pwd = txtPassword.Text.ToString();
        bool b = AdminLogin.Login(name, pwd);
        if (b)
        {
            Session["admin"] = "admin";
            this.Label1.Text = "see you again!";
            this.pnLogin.Visible = true;
        }
        else
        {
            this.Label1.Text = "登陆失败!";
            this.btnRevLogin.Visible = true;
        }

    }
    protected void btnRevLogin_Click(object sender, EventArgs e)
    {
        this.txtUsername.Visible = true;
        this.txtPassword.Visible = true;
        this.btnLogin.Visible = true;
        this.Label1.Visible = false;
        this.btnRevLogin.Visible = false;
    }
    protected void btnLoginOut_Click(object sender, EventArgs e)
    {
        Session["admin"] = "";
        this.txtUsername.Visible = true;
        this.txtPassword.Visible = true;
        this.txtUsername.Text = "";
        this.txtPassword.Text = "";
        this.btnLogin.Visible = true;
        this.Label1.Visible = false;
        this.pnLogin.Visible = false;
    }
}
