using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees;select * from Departments";

            cn.Open();
            SqlDataReader drEmps = cmd.ExecuteReader();

            //while (drEmps.Read())
            //{
            //    ListBox1.Items.Add(new ListItem(drEmps["Name"].ToString(), drEmps["EmpNo"].ToString()));
            //}
            ListBox1.DataSource = drEmps;
            ListBox1.DataTextField = "Name";
            ListBox1.DataValueField = "EmpNo";
            ListBox1.DataBind();



            drEmps.NextResult();
            //while (drEmps.Read())
            //{
            //    ListBox2.Items.Add(new ListItem(drEmps["DeptName"].ToString(), drEmps["DeptNo"].ToString()));
            //}
            ListBox2.DataSource = drEmps;
            ListBox2.DataTextField = "DeptName";
            ListBox2.DataValueField = "DeptNo";
            ListBox2.DataBind();

            drEmps.Close();
            cn.Close();

        }
    }
}