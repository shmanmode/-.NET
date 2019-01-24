using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DemoForget : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=SMTP;Integrated Security=True;Pooling=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select EmailAddress , Password from USerInfo  where EmailAddress = @Email";
            cmd.Parameters.AddWithValue("@Email", TextBox1.Text);
            cn.Open();
            SqlDataReader da = cmd.ExecuteReader();

            if (da.Read())
            {
                string Email7 = da["EmailAddress"].ToString();
                string password = da["Password"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("cdac@gmail.com", "Password");
                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(TextBox1.Text);
                msgobj.From = new MailAddress("cdac@gmail.com");
                msgobj.Subject = "CDAC INGENIOUS Password";
                msgobj.Body = String.Format("Hello Your Email Address and Password is \n Email " + Email7+ " \n Password : "  +password);
                client.Send(msgobj);
                Label2.Text = "Password send on " + TextBox1.Text;
                //Response.Write("msg was send successfully");
            }
            else
            {
                Label2.Text = TextBox1.Text + "  not registered Email Address";
            }
        
        }
            catch (Exception ex)
            {
               Label2.Text  = "Internal Error Occured, Try after some time ";
            }            
    }
    }
