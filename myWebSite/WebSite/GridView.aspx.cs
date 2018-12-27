using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView : System.Web.UI.Page
{
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



    //Fetching
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
    //---------------------------Reading Data from GRIDVIEW-------------------//
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtLoginName.Text = GridView1.SelectedRow.Cells[3].Text;
        txtEmailId.Text = GridView1.SelectedRow.Cells[4].Text;
        txtAddress.Text = GridView1.SelectedRow.Cells[5].Text;
        txtCityId.Text = GridView1.SelectedRow.Cells[6].Text;
        txtPaymentModeId.Text = GridView1.SelectedRow.Cells[7].Text;

    }

    //---------------------Insert Button-----------------//
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        DataRow drow = ds.Tables["Cust"].NewRow();
        drow["LoginName"] = txtLoginName.Text;
        drow["EmailId"] = txtEmailId.Text;
        drow["Address"] = txtAddress.Text;
        drow["CityId"] = txtCityId.Text;
        drow["PaymentMode"] = txtPaymentModeId.Text;


        ds.Tables["Cust"].Rows.Add(drow);

        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }

    //----------------------Update Button--------------------//
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        foreach (DataRow drow in ds.Tables["Cust"].Rows)
        {
            if (drow.RowState != DataRowState.Deleted)
                if (txtLoginName.Text == drow["LoginName"].ToString())
                {
                    drow["LoginName"] = txtLoginName.Text;
                    drow["EmailId"] = txtEmailId.Text;
                    drow["Address"] = txtAddress.Text;
                    drow["CityId"] = txtCityId.Text;
                    drow["PaymentMode"] = txtPaymentModeId.Text;

                    break;
                }
        }

        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }

    //-------------------Delete Button-------------------//
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        foreach (DataRow drow in ds.Tables["Cust"].Rows)
        {
            if (drow.RowState != DataRowState.Deleted)
                if (txtLoginName.Text == drow["LoginName"].ToString())
                {
                    drow.Delete();
                    break;
                }

        }

        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();

    }


    //------------------update data from dataset to database------------------//
    protected void Button1_Click(object sender, EventArgs e)
    {

        DataSet ds = (DataSet)Session["ds"];
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=pooja11;Integrated Security=True;Pooling=False";

        // updated data updation to main database
        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = cn;
        cmdUpdate.CommandType = CommandType.Text;
        cmdUpdate.CommandText = "update Customers set LoginName = @LoginName  ,EmailId =  @EmailId , Address = @Address , CityId = @CityId ,PaymentMode = @PaymentMode ";


        // insert data updation to main database
        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Customers values (@LoginName, @EmailId,@Address,@CityId,@PaymentMode) ";

        // Deleted data updation to main database
        SqlCommand cmdDelete = new SqlCommand();
        cmdDelete.Connection = cn;
        cmdDelete.CommandType = CommandType.Text;
        cmdDelete.CommandText = "delete from Customers where LoginName = @LoginName";


        //connection open
        cn.Open();

        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@LoginName", SourceColumn = "LoginName", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmailId", SourceColumn = "EmailId", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Address", SourceColumn = "Address", SourceVersion = DataRowVersion.Original });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@PaymentMode", SourceColumn = "PaymentMode", SourceVersion = DataRowVersion.Original });


        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@LoginName", SourceColumn = "LoginName", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmailId", SourceColumn = "EmailId", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Address", SourceColumn = "Address", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@PaymentMode", SourceColumn = "PaymentMode", SourceVersion = DataRowVersion.Current });


        cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@LoginName", SourceColumn = "LoginName", SourceVersion = DataRowVersion.Original });

        SqlDataAdapter da = new SqlDataAdapter();
        da.UpdateCommand = cmdUpdate;
        da.InsertCommand = cmdInsert;
        da.DeleteCommand = cmdDelete;
        da.Update(ds, "Cust");


        ds.AcceptChanges();
        //        ds.RejectChanges();  ---> does an UNDO. Goes back to original values and rowstate becomes Unchanged


        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();



    }

    //----------------------Row Editing through Event-----------------------//
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
            DataSet ds = (DataSet)Session["ds"];
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = ds.Tables["Cust"];
            GridView1.DataBind();
    }

    //--------------------------Row Cancelling through Event------------------------//
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }

    //--------------------------Row Updating through Event------------------------//
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        //update values in dataset
        TextBox txtLoginName = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
        TextBox txtEmailId = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];
        TextBox txtAddress = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
        TextBox txtCityId = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];
        TextBox txtPaymentModeId = (TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0];
        DataRow drow = ds.Tables["Cust"].Rows.Find(txtLoginName.Text);
        if (drow != null)
        {
            drow["LoginName"] = txtLoginName.Text;
            drow["EmailId"] = txtEmailId.Text;
            drow["Address"] = txtAddress.Text;
            drow["CityId"] = txtCityId.Text;
            drow["PaymentMode"] = txtPaymentModeId.Text;
        }
        //end of update in dataset
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();

    }

    //--------------------------Row Deleting through Event------------------------//
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        //DataRow drow = ds.Tables["Emps"].Rows.Find(txtEmpNo.Text);
        string strLoginName = GridView1.Rows[e.RowIndex].Cells[3].Text;
        DataRow drow = ds.Tables["Cust"].Rows.Find(strLoginName);
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();

    }

    //--------------------------Row Page-Indexing through Event------------------------//
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();
    }

    //--------------------------Row Sorting through Event------------------------//
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        //DataView dv = new DataView(ds.Tables["Emps"]);
        //dv.Sort = e.SortExpression;
        //GridView1.DataSource = dv;
        ds.Tables["Cust"].DefaultView.Sort = e.SortExpression;
        GridView1.DataSource = ds.Tables["Cust"];
        GridView1.DataBind();

    }
}