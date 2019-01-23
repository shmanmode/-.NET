using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int intId = 100;

        string strPopup = "<script language='javascript' ID='script1'>"

        // Passing intId to popup window.
        + "window.open('DemoForget.aspx?data=" + HttpUtility.UrlEncode(intId.ToString())

        + "','new window', 'top=90, left=200, width=300, height=100, dependant=no, location=0, alwaysRaised=no, menubar=no, resizeable=no, scrollbars=n, toolbar=no, status=no, center=yes')"

        + "</script>";

        ScriptManager.RegisterStartupScript((Page)HttpContext.Current.Handler, typeof(Page), "Script1", strPopup, false);
    }
}