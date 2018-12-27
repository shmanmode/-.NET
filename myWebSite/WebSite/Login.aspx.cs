using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies["LoginDetails"];
            if (cookie != null)
            {
                if (CheckUser(cookie.Values["user"], cookie.Values["password"]))
                {
                    Session["user"] = cookie.Values["user"];
                    Response.Redirect("HomePage.aspx");
                }
            }
        }
    }

    private bool CheckUser(string username, string password)
    {
        // return (username == "admin" && password == "123");
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=shubham;Integrated Security=True;Pooling=False";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select count(*) from Users Where LoginName =  '"+ username +"' and PassWord = '"+password+"'";
       
        cn.Open();
        String xc =  cmd.ExecuteScalar().ToString();
        if (xc == "1")
        {
            cn.Close();
            return true;
        }
        else
        {
            cn.Close(); 
            return false;
        }






    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckUser(txtUserName.Text, txtPassword.Text))
        {
            //Set Cookies
            if (cbRememberme.Checked)
            {

                HttpCookie cookie = new HttpCookie("LoginDetails");
                cookie.Values["user"] = txtUserName.Text;
                cookie.Values["password"] = txtPassword.Text;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

            }
            Session["user"] = txtUserName.Text;
            Response.Redirect("HomePage.aspx");
        }
        else
        {
            lbError.Text = "Invalid User Name or Password";
        }
    }

    protected void btnRegistere_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void cbRememberme_CheckedChanged(object sender, EventArgs e)
    {

    }
}