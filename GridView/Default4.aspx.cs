using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = GetDs();
            Session["ds"] = ds;
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

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        //update values in dataset
        TextBox txtEmpNo = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
        TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
        TextBox txtBasic = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
        TextBox txtDeptNo = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];
        DataRow drow = ds.Tables["Emps"].Rows.Find(txtEmpNo.Text);
        if (drow != null)
        {
            drow["Name"] = txtName.Text;
            drow["Basic"] = txtBasic.Text;
            drow["DeptNo"] = txtDeptNo.Text;
        }
        //end of update in dataset
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        //DataRow drow = ds.Tables["Emps"].Rows.Find(txtEmpNo.Text);
        string strEmpNo = GridView1.Rows[e.RowIndex].Cells[3].Text;
        DataRow drow = ds.Tables["Emps"].Rows.Find( strEmpNo   );
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        
        DataSet ds = (DataSet)Session["ds"];
        //DataView dv = new DataView(ds.Tables["Emps"]);
        //dv.Sort = e.SortExpression;
        //GridView1.DataSource = dv;
        ds.Tables["Emps"].DefaultView.Sort = e.SortExpression;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();



    }
}