using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    public TextBox txtFName
    {
        get { return txtFirstName; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //if(this.IsPostBack)
        //if(this.Page.IsPostBack)
        //if(Page.IsPostBack)
        //if(base.IsPostBack)
        //if(base.Page.IsPostBack)

        if (IsPostBack == false)
        {
            Label1.Text = "Page load for the 1st time";
            ViewState["ctr"] = 0;
        }
        else
        {
            Label1.Text = "Page has been posted back";
            ViewState["ctr"] = ((int)ViewState["ctr"] )+ 1;
        }
        Label5.Text = "Page has been posted back " + ViewState["ctr"].ToString() + " times ";
        Label6.Text = "total visitors" + Application["visitors"].ToString() ;

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "Hello World";
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //server controls
        //txtFullName.Text = txtFirstName.Text + txtLastName.Text;
        //txtFullName.Text = Request.Form["txtFirstName"] + Request.Form["txtLastName"];

        //html control
        //txtFullName.Text = Request.Form["Text1"] + Request.Form["Text2"];

        //html control with runat ="server"
        //txtFullName.Text = Request.Form["Text3"] + Request.Form["Text4"];
        txtFullName.Text = Text3.Value + Text4.Value;

    }


    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default2.aspx");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Default2.aspx?txtFirstName=" + txtFirstName.Text);
        Response.Redirect("Default2.aspx?txtFirstName=" + txtFirstName.Text + "&txtLastName=" + txtLastName.Text);
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        HttpCookie objCookie = new HttpCookie("ChocoChip");
        //objCookie.Value = txtFirstName.Text;

        objCookie.Values["FirstName"] = txtFirstName.Text;
        objCookie.Values["LastName"] = txtLastName.Text;


        objCookie.Expires = DateTime.Now.AddDays(1);
        Response.Cookies.Add(objCookie);

        Response.Redirect("Default2.aspx");
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["FirstName"] = txtFirstName.Text;
        Response.Redirect("Default2.aspx");

    }
}