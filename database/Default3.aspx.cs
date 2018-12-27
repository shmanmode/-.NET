using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            DataSet ds = GetDs();
            Session["ds"] = ds;
            //GridView1.DataSource = ds.Tables[0];
            GridView1.DataSource = ds.Tables["Emps"];
            GridView1.DataBind();
        }

    }
    private DataSet GetDs()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Employees";

        cn.Open();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataSet ds = new DataSet();
        da.Fill(ds, "Emps");

        DataColumn[] arrCols = new DataColumn[1];
        arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
        ds.Tables["Emps"].PrimaryKey = arrCols;


        cmd.CommandText = "select * from Departments";
        da.Fill(ds, "Deps");

        ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);

        //ds.Tables["Deps"].Columns["DeptName"].Unique = true;

        cn.Close();

        return ds;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtEmpNo.Text = GridView1.SelectedRow.Cells[3].Text;
        txtName.Text = GridView1.SelectedRow.Cells[4].Text;
        txtBasic.Text = GridView1.SelectedRow.Cells[5].Text;
        txtDeptNo.Text = GridView1.SelectedRow.Cells[6].Text;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //update the dataset
        DataSet ds = (DataSet)Session["ds"];
        foreach (DataRow drow in ds.Tables["Emps"].Rows)
        {
            if (drow.RowState != DataRowState.Deleted)
                if (txtEmpNo.Text == drow["EmpNo"].ToString())
                {
                    drow["Name"] = txtName.Text;
                    drow["Basic"] = txtBasic.Text;
                    drow["DeptNo"] = txtDeptNo.Text;
                    break;
                }
        }

        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        foreach (DataRow drow in ds.Tables["Emps"].Rows)
        {
            if(drow.RowState !=  DataRowState.Deleted)
                if (txtEmpNo.Text == drow["EmpNo"].ToString())
                {
                    drow.Delete();
                    break;
                }

        }

        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        DataRow drow = ds.Tables["Emps"].NewRow();
        drow["EmpNo"] = txtEmpNo.Text;
        drow["Name"] = txtName.Text;
        drow["Basic"] = txtBasic.Text;
        drow["DeptNo"] = txtDeptNo.Text;


        ds.Tables["Emps"].Rows.Add(drow);

        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }
}