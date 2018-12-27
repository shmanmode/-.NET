using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default6 : System.Web.UI.Page
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


    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item  || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataSet ds = (DataSet)Session["ds"];

            Label lblDeptNo = (Label)e.Item.FindControl("lblDeptNo");
            ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo=" + lblDeptNo.Text;
            GridView dg = (GridView)e.Item.FindControl("GridView1");
            dg.DataSource = ds.Tables["Emps"];

            dg.DataBind();
        }
    }
}