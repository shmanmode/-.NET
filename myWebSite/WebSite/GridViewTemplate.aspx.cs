using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridViewTemplate : System.Web.UI.Page
{

    //on page load-----------------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = GetDs();
            Session["ds"] = ds;
            GridView1.DataSource = ds.Tables["Cust"];
            GridView1.DataBind();

        }
    }
    //-----------------------------------------------------------------------------





    //---------------------------for Fetching data from data database---------------------------------------//
    private DataSet GetDs()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=pooja11;Integrated Security=True;Pooling=False";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Customers";

        cn.Open();

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataSet ds = new DataSet();
        da.Fill(ds, "Cust");

        DataColumn[] arrCols = new DataColumn[1];
        arrCols[0] = ds.Tables["Cust"].Columns["LoginName"];
        ds.Tables["Cust"].PrimaryKey = arrCols;
        cn.Close();

        return ds;
    }
    //--------------------------------------------------------------------------------------------------------------//


   //-------------------Row Editing through Event---------------------------------//

     protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }
   

    //----------------Row Updating through Event----------------------------------//
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DataSet ds = (DataSet)Session["ds"];
       TextBox txtLoginName = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtLoginName");
        TextBox txtEmailId = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtEmailId");
        TextBox txtAddress = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");
        DropDownList txtCityId = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropCityId");
        DropDownList txtPaymentModeId = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropPaymentmode");


        DataRow drow = ds.Tables["Cust"].Rows.Find(txtLoginName.Text);
        if (drow != null)
        {
            drow["LoginName"] = txtLoginName.Text;
            drow["EmailId"] = txtEmailId.Text; 
            drow["Address"] = txtAddress.Text;
            drow["CityId"] = txtCityId.SelectedValue;
            drow["PaymentMode"] = txtPaymentModeId.SelectedValue;
        }
        //end of update in dataset
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();

    }
    //------------------------------Row Cancelling through Event---------------------------//
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }


    //----------------------------Row Deleting through Event----------------------------------//

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        Label lblLoginName = (Label)GridView1.Rows[e.RowIndex].FindControl("lblLoginName");
        DataRow drow = ds.Tables["Cust"].Rows.Find(lblLoginName.Text);
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }

    //------------------------Insert Button on Footer Side--------------------------//

    protected void btnInsert_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        DataRow drow = ds.Tables["Cust"].NewRow();

        TextBox txtLoginName = (TextBox)GridView1.FooterRow.FindControl("txtLoginName");
        TextBox txtEmailId = (TextBox)GridView1.FooterRow.FindControl("txtEmailId");
        TextBox txtAddress = (TextBox)GridView1.FooterRow.FindControl("txtAddress");
        DropDownList txtCityId = (DropDownList)GridView1.FooterRow.FindControl("DropCityId");
        DropDownList txtPaymentModeId = (DropDownList)GridView1.FooterRow.FindControl("DropPaymentmode");


        drow["LoginName"] = txtLoginName.Text;
        drow["EmailId"] = txtEmailId.Text;
        drow["Address"] = txtAddress.Text;
        drow["CityId"] = txtCityId.SelectedValue;
        drow["PaymentMode"] = txtPaymentModeId.SelectedValue;


        ds.Tables["Cust"].Rows.Add(drow);

        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }
}