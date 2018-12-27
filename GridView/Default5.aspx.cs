using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default5 : System.Web.UI.Page
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

    protected DataTable GetDeps()
    {
        DataSet ds = (DataSet)Session["ds"];
        return ds.Tables["Deps"];
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
        //TextBox txtEmpNo = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
        //TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
        //TextBox txtBasic = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
        //TextBox txtDeptNo = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];

        Label lblEmpNo = (Label)GridView1.Rows[e.RowIndex].FindControl("lblEmpNo");
        TextBox txtName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtName");
        TextBox txtBasic = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBasic");
        DropDownList ddlDepts = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlDepts");


        DataRow drow = ds.Tables["Emps"].Rows.Find(lblEmpNo.Text);
        if (drow != null)
        {
            drow["Name"] = txtName.Text;
            drow["Basic"] = txtBasic.Text;
            drow["DeptNo"] = ddlDepts.SelectedValue;
        }
        //end of update in dataset
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        Label lblEmpNo =(Label) GridView1.Rows[e.RowIndex].FindControl("lblEmpNo");
        DataRow drow = ds.Tables["Emps"].Rows.Find( lblEmpNo.Text );
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        DataRow drow = ds.Tables["Emps"].NewRow();

        TextBox txtEmpNo = (TextBox)GridView1.FooterRow.FindControl("txtEmpNo");
        TextBox txtName = (TextBox)GridView1.FooterRow.FindControl("txtName");
        TextBox txtBasic = (TextBox)GridView1.FooterRow.FindControl("txtBasic");
        DropDownList ddlDepts = (DropDownList)GridView1.FooterRow.FindControl("ddlDepts");


        drow["EmpNo"] = txtEmpNo.Text;
        drow["Name"] = txtName.Text;
        drow["Basic"] = txtBasic.Text;
        drow["DeptNo"] = ddlDepts.SelectedValue;


        ds.Tables["Emps"].Rows.Add(drow);

        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }
}