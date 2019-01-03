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
        if(!IsPostBack)
        {
            DataSet ds = GetDs();
            Session["ds"] = ds;
            GridView1.DataSource = ds.Tables["garam"];
            GridView1.DataBind();

        }
    }

    

    private DataSet GetDs()
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=manmode;Integrated Security=True;Pooling=False";

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText =  "Select * from Users";

        cn.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataSet ds = new DataSet();
        da.Fill(ds, "garam");

        DataColumn[] arrCols = new DataColumn[1];
        arrCols[0] = ds.Tables["garam"].Columns["UserName"];
        ds.Tables["garam"].PrimaryKey = arrCols;


        cn.Close();
        return ds;
    }


    //---------------------------------------------------------------------
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        DataRow drow = ds.Tables["garam"].NewRow();

        TextBox UserName1 = (TextBox)GridView1.FooterRow.FindControl("txtFootUsername");
        TextBox Password1 = (TextBox)GridView1.FooterRow.FindControl("txtFootPassword");
        TextBox Address1 = (TextBox)GridView1.FooterRow.FindControl("txtFootAddress");
        TextBox MobNo1 = (TextBox)GridView1.FooterRow.FindControl("txtFootMob");
        DropDownList CityId1 = (DropDownList)GridView1.FooterRow.FindControl("DropFootCity");
        DropDownList PaymentId1 = (DropDownList)GridView1.FooterRow.FindControl("btnFootpayment");


        drow["UserName"] = UserName1.Text;
        drow["Password"] = Password1.Text;
        drow["Address"] = Address1.Text;
        drow["MobNo"] = MobNo1.Text;
        drow["CityId"] = CityId1.SelectedValue;
        drow["PaymentId"] = PaymentId1.SelectedValue;


        ds.Tables["garam"].Rows.Add(drow);

        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();
    }

    //----------------------------------------------------------------------------------------------------






    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];


        Label UserName1 = (Label)GridView1.Rows[e.RowIndex].FindControl("lblUserName");
        TextBox Password1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtPassword");
        TextBox Address1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtAddress");
        TextBox MobNo1 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtMob");
        DropDownList CityId1 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("DropCity");
        DropDownList PaymentId1 = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("btnpayment");

        DataRow drow = ds.Tables["garam"].Rows.Find(UserName1.Text);
        if (drow != null)
        {
          //  drow["UserName"] = UserName.Text;
            drow["Password"] = Password1.Text;
            drow["Address"] = Address1.Text;
            drow["MobNo"] = MobNo1.Text;
            drow["CityId"] = CityId1.SelectedValue;
            drow["PaymentId"] = PaymentId1.SelectedValue;
        }
        //end of update in dataset
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       DataSet ds = (DataSet)Session["ds"];
        Label lblUserName = (Label)GridView1.Rows[e.RowIndex].FindControl("lblUserName");
        DataRow drow = ds.Tables["garam"].Rows.Find(lblUserName.Text);
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        GridView1.EditIndex = -1;
        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();
    }

    protected void btnUpdateAll_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=manmode;Integrated Security=True;Pooling=False";
        cn.Open();
        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = cn;
        cmdUpdate.CommandType = CommandType.Text;
        cmdUpdate.CommandText = "update Users set  Password = @Password, Address = @Address, MobNo = @MobNo , CityId = @CityId , PaymentId = @PaymentId where UserName = @UserName";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Users values(@UserName,@Password,@Address,@MobNo, @CityId ,@PaymentId)";

        SqlCommand cmdDelete = new SqlCommand();
        cmdDelete.Connection = cn;
        cmdDelete.CommandType = CommandType.Text;
        cmdDelete.CommandText = "delete from Users where UserName=@UserName";

        // cn.Open();

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@UserName";
        p.SourceColumn = "UserName";
        p.SourceVersion = DataRowVersion.Current;

        cmdUpdate.Parameters.Add(p);

        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Password", SourceColumn = "Password", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Address", SourceColumn = "Address", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@MobNo", SourceColumn = "MobNo", SourceVersion = DataRowVersion.Original });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@PaymentId", SourceColumn = "PaymentId", SourceVersion = DataRowVersion.Original });


        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@UserName", SourceColumn = "UserName", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Password", SourceColumn = "Password", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Address", SourceColumn = "Address", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@MobNo", SourceColumn = "MobNo", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@CityId", SourceColumn = "CityId", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@PaymentId", SourceColumn = "PaymentId", SourceVersion = DataRowVersion.Current });



        cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@UserName", SourceColumn = "UserName", SourceVersion = DataRowVersion.Original });


        SqlDataAdapter da = new SqlDataAdapter();
        da.UpdateCommand = cmdUpdate;
        da.InsertCommand = cmdInsert;
        da.DeleteCommand = cmdDelete;

        //da.ContinueUpdateOnError = true;

        da.Update(ds, "garam");

        Response.Write("ok");
       // ds.AcceptChanges();
        //        ds.RejectChanges();  ---> does an UNDO. Goes back to original values and rowstate becomes Unchanged

        GridView1.DataSource = ds.Tables["garam"];
        GridView1.DataBind();
    }
}