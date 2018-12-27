using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //SqlConnection cn1 = new SqlConnection();

        //cn1.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=shubham;Integrated Security=True;Pooling=False";
        //SqlCommand cmd = new SqlCommand();
        //cmd.Connection = cn1;
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = "select Cityid from Cities Where CityName  =  '" + DropDownList1.Text + "' ";

        //cn1.Open();
        //String xc = cmd.ExecuteScalar().ToString();
        //Response.Write(cmd.ExecuteScalar().ToString());

        //-----------------------------------------------------

        //SqlConnection cn2 = new SqlConnection();

        //cn2.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=shubham;Integrated Security=True;Pooling=False";
        //SqlCommand cmd2 = new SqlCommand();
        //cmd2.Connection = cn2;
        //cmd2.CommandType = CommandType.Text;
        //cmd2.CommandText = "select PaymentModeId from PaymentMode Where PaymentModeName  =  '" + radRadioButtonList1.Text + "' ";

        //cn2.Open();
        ////String xc = cmd.ExecuteScalar().ToString();
        //Response.Write(cmd2.ExecuteScalar().ToString());


        //------------------------------------------------------


        SqlConnection cn = new SqlConnection();
       
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=shubham;Integrated Security=True;Pooling=False";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Users values(@LoginName,@Password,@EmailId,@Address,@City,@PaymentModeId)";

        cmdInsert.Parameters.AddWithValue("@LoginName", txtLoginName.Text);
        cmdInsert.Parameters.AddWithValue("@Password",txtPassword.Text);
        cmdInsert.Parameters.AddWithValue("@EmailId", txtEmailId.Text);
        cmdInsert.Parameters.AddWithValue("@Address", txtAddress.Text);
        cmdInsert.Parameters.AddWithValue("@City", DropDownList1.Text);
        cmdInsert.Parameters.AddWithValue("@PaymentModeId", radRadioButtonList1.Text);
        //cmdInsert.Parameters.AddWithValue("@City", cmd.ExecuteScalar().ToString());
        //cmdInsert.Parameters.AddWithValue("@PaymentModeId", cmd2.ExecuteScalar().ToString());
        cn.Open();
        cmdInsert.ExecuteNonQuery();
        cn.Close();


        //cn1.Close();

        //cn2.Close();




        Response.Write("Registerd Successfully");
        
    }

    public void hello()
    {

    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
 
    }