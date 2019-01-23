using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class Email : System.Web.UI.Page
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
            cmd.CommandText = "select EmailAddress from USerInfo";
            string email;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                email = dr[0].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("cdac.ingenious@gmail.com", "Password888");
                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(email);
                msgobj.From = new MailAddress("cdac.ingenious@gmail.com");
                msgobj.Subject = "Interview Schedule";
                msgobj.Body = " Hello ,\n\n    Your resume has been shortlisted for Reliance Jio,Your Interview is scheduled on " + DateTime.Today.AddDays(5).ToString("dd-MM-yyyy")+ " at 10:00 AM Sharp \n at Mahape,Navi-Mumbai. Your package is 7 LPA"+" \n\n\n HR ADMIN,\n CDAC";
                client.Send(msgobj);
                //Response.Write("Mail send successfully");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('message has been sent successfully');", true);
            }
         }
        catch (Exception ex)
        {
            Response.Write("Could not send Email" + ex.Message); 
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //SMS Sending------------------------------------------------------
        String Mobile = "9757374616";
        String Password = "Shivam@97";
        String Message = "Succesfull Registration";
        String No = TxtPhone.Text;
        String Key = "panwaTcrCPf0GvZ8Uhgikj7xbo";
        String URL = "https://smsapi.engineeringtgr.com/send/?Mobile=" + Mobile + "&Password=" + Password + "&Key=" + Key + "&Message=" + Message + "&To=" + No + "";

        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.ContentLength = 0;
        try
        {
                 //SMTP MAIL----------------------------------------------------------------------------------------------
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("cdac.ingenious@gmail.com", "Password888");
                MailMessage msgobj = new MailMessage();
                msgobj.To.Add(To.Text);
                msgobj.From = new MailAddress("cdac.ingenious@gmail.com");
                msgobj.Subject = "CDAC-IGNENIOUS";
                msgobj.Body = TxtUserName.Text +" registered successfully to CDAC-INGENIOUS ";
                client.Send(msgobj);
                //Response.Write("Mail send successfully");
                
            //SMS----------------------------------------------------------------------------------------------------
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            String response = responseReader.ReadToEnd();
            Console.Out.WriteLine(response);
            responseReader.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Registered  successfully');", true);
        }
        
        catch (Exception ex)
        {
            Response.Write("Registration Failed" + ex.Message);
        }

        ////SMS Sending------------------------------------------------------
        //String Mobile = "9757374616";
        //String Password = "Shivam@97";
        //String Message = TxtUserName.Text + " registered successfully to CDAC-INGENIOUS ";
        //String No = TxtPhone.Text;
        //String Key = "panwaTcrCPf0GvZ8Uhgikj7xbo";
        //String URL = "https://smsapi.engineeringtgr.com/send/?Mobile=" + Mobile + "&Password=" + Password + "&Key=" + Key + "&Message=" + Message + "&To=" + No + "";

        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
        //request.Method = "GET";
        //request.ContentType = "application/json";
        //request.ContentLength = 0;
        //try
        //{
        //    HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
        //    Stream webStream = webResponse.GetResponseStream();
        //    StreamReader responseReader = new StreamReader(webStream);
        //    String response = responseReader.ReadToEnd();
        //    Console.Out.WriteLine(response);
        //    responseReader.Close();
        //    Label4.Text = "Successfully send";
        //}
        //catch (Exception xe)
        //{
        //    Console.Out.WriteLine("--------------");
        //    Console.Out.WriteLine(xe.Message);
        //}
    }
}
