using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //read values from earlier page

        //server.transfer
        //Label1.Text = Request.Form["txtFirstName"];

        //response.redirect with QueryString
        //Label1.Text = Request.QueryString["txtFirstName"];


        //response.redirect with Cookie
        //HttpCookie objCookie = Request.Cookies["ChocoChip"];
        //if (objCookie != null)
        //{
        //    //Label1.Text = objCookie.Value;
        //    Label1.Text = objCookie.Values["FirstName"];
        //}
        //else
        //    Label1.Text = "no cookie present";

        //response.redirect with a session variable
        //Label1.Text = Session["FirstName"].ToString();

        //using PostBackUrl property of  a button
        //Label1.Text = Request.Form["txtFirstName"];

        //if we have specific @PreviousPageType in the .aspx file
        if (PreviousPage != null)
        {
            //TextBox txtFname = (TextBox)PreviousPage.FindControl("txtFirstName");
            //Label1.Text = txtFname.Text;


            //if we have created a property on th previous page...
            Label1.Text = PreviousPage.txtFName.Text;
        }



    }
}


