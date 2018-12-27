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

    protected void Button4_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        DataRow drow = ds.Tables["Emps"].Rows.Find(txtEmpNo.Text);
        if (drow != null)
        {
            drow["Name"] = txtName.Text;
            drow["Basic"] = txtBasic.Text;
            drow["DeptNo"] = txtDeptNo.Text;
        }
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];
        DataRow drow = ds.Tables["Emps"].Rows.Find(txtEmpNo.Text);
        if (drow != null)
            drow.Delete();
        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = cn;
        cmdUpdate.CommandType = CommandType.Text;
        cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

        SqlCommand cmdDelete = new SqlCommand();
        cmdDelete.Connection = cn;
        cmdDelete.CommandType = CommandType.Text;
        cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

        cn.Open();

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@Name";
        p.SourceColumn = "Name";
        p.SourceVersion = DataRowVersion.Current;
        cmdUpdate.Parameters.Add(p);

        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

        cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


        SqlDataAdapter da = new SqlDataAdapter();
        da.UpdateCommand = cmdUpdate;
        da.InsertCommand = cmdInsert;
        da.DeleteCommand = cmdDelete;
        da.Update(ds, "Emps");



        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["ds"];

        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";

        SqlCommand cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = cn;
        cmdUpdate.CommandType = CommandType.Text;
        cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

        SqlCommand cmdInsert = new SqlCommand();
        cmdInsert.Connection = cn;
        cmdInsert.CommandType = CommandType.Text;
        cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

        SqlCommand cmdDelete = new SqlCommand();
        cmdDelete.Connection = cn;
        cmdDelete.CommandType = CommandType.Text;
        cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

        cn.Open();

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@Name";
        p.SourceColumn = "Name";
        p.SourceVersion = DataRowVersion.Current;
        cmdUpdate.Parameters.Add(p);

        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
        cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
        cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

        cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


        SqlDataAdapter da = new SqlDataAdapter();
        da.UpdateCommand = cmdUpdate;
        da.InsertCommand = cmdInsert;
        da.DeleteCommand = cmdDelete;

        //da.ContinueUpdateOnError = true;

        da.Update(ds, "Emps");


        ds.AcceptChanges();
//        ds.RejectChanges();  ---> does an UNDO. Goes back to original values and rowstate becomes Unchanged

        GridView1.DataSource = ds.Tables["Emps"];
        GridView1.DataBind();

    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=Vikram;Integrated Security=True";
        cn.Open();
        SqlTransaction t = cn.BeginTransaction();
        try
        {

            SqlCommand cmdInsert1 = new SqlCommand();
            cmdInsert1.Connection = cn;
            cmdInsert1.Transaction = t;

            cmdInsert1.CommandType = CommandType.Text;
            cmdInsert1.CommandText = "insert into Employees values(100,'new emp', 10000, 10)";

            SqlCommand cmdInsert2 = new SqlCommand();
            cmdInsert2.Connection = cn;
            cmdInsert2.Transaction = t;

            cmdInsert2.CommandType = CommandType.Text;
            cmdInsert2.CommandText = "insert into Employees values(1,'new emp', 10000, 10)";

            cmdInsert1.ExecuteNonQuery();
            cmdInsert2.ExecuteNonQuery();

            t.Commit();
            Response.Write("COMMIT");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            t.Rollback();
            Response.Write("ROLLBACK");
        }
        finally
        {
            cn.Close();
        }

    }
}