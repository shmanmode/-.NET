using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["user"] != null)
            {
                Label1.Text = "Welcome " + Session["user"];
            }
            else
            {
                Response.Redirect("WebForm.aspx");
            }


        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["LoginDetails"];
        if (cookie != null)
        {

            cookie.Expires = DateTime.Now.AddDays(-2);
            Response.Cookies.Add(cookie);
        }
        Session.Abandon();
        Response.Redirect("WebForm.aspx");

    }
}