using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        //cn.ConnectionString = @"Data Source=(LocalDb)\MsSqlLocalDb;Integrated Security=true;Initial Catalog=Vikram";
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        //cmdInsert.CommandText = "insert into Employees values(5,'Aditya', 40000, 30)";
        cmdInsert.CommandText = "insert into Employees values("  + txtEmpNo.Text + 
                                ",'" + txtName.Text + "'," +  txtBasic.Text + "," + txtDeptNo.Text + ")";
        cn.Open();
        cmdInsert.ExecuteNonQuery();
        //Response.Write(cmdInsert.CommandText );
        cn.Close();

        //Response.Write("ok");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        //cn.ConnectionString = @"Data Source=(LocalDb)\MsSqlLocalDb;Integrated Security=true;Initial Catalog=Vikram";
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

        cmdInsert.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
        cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
        cmdInsert.Parameters.AddWithValue("@Basic", txtBasic.Text);
        cmdInsert.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

        cn.Open();
        cmdInsert.ExecuteNonQuery();
        cn.Close();

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        //cn.ConnectionString = @"Data Source=(LocalDb)\MsSqlLocalDb;Integrated Security=true;Initial Catalog=Vikram";
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.StoredProcedure;
        cmdInsert.CommandText = "InsertEmployee";

        cmdInsert.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
        cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
        cmdInsert.Parameters.AddWithValue("@Basic", txtBasic.Text);
        cmdInsert.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

        cn.Open();
        cmdInsert.ExecuteNonQuery();
        cn.Close();

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select count(*) from Employees";
        //cmd.CommandText = "select * from Employees";
        cn.Open();
        Label5.Text = cmd.ExecuteScalar().ToString();
        cn.Close();
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Employees";

        cn.Open();
        SqlDataReader drEmps = cmd.ExecuteReader();

        while (drEmps.Read())
        {
            //DropDownList1.Items.Add(drEmps["Name"].ToString());
            ListBox1.Items.Add(new ListItem(drEmps["Name"].ToString(), drEmps["EmpNo"].ToString()));
        }
        drEmps.Close();
        cn.Close();

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Label6.Text = ListBox1.SelectedItem.Text;
        //Label7.Text = ListBox1.SelectedItem.Value;
        Label7.Text = ListBox1.SelectedValue;
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        ListBox1.SelectedValue = TextBox1.Text;
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Employees;select * from Departments";

        cn.Open();
        SqlDataReader drEmps = cmd.ExecuteReader();

        while (drEmps.Read())
        {
            ListBox1.Items.Add(new ListItem(drEmps["Name"].ToString(), drEmps["EmpNo"].ToString()));
        }
        drEmps.NextResult();
        while (drEmps.Read())
        {
            ListBox2.Items.Add(new ListItem(drEmps["DeptName"].ToString(), drEmps["DeptNo"].ToString()));
        }

        drEmps.Close();
        cn.Close();
    }
}