using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = GetDs();
            Session["ds"] = ds;
            DataList1.DataSource = ds.Tables["Deps"];
            DataList1.DataBind();



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


    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        DataList1.EditItemIndex = e.Item.ItemIndex;
        DataList1.DataSource = ds.Tables["Deps"];
        DataList1.DataBind();
    }

    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        DataList1.EditItemIndex = -1;
        DataList1.DataSource = ds.Tables["Deps"];
        DataList1.DataBind();

    }

    protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
    {

    }

    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        DataList1.EditItemIndex = -1;
        DataList1.DataSource = ds.Tables["Deps"];
        DataList1.DataBind();
    }
}