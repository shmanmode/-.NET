using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFService" in code, svc and config file together.
public class WCFService : IWCFService
{
    public bool CheckUser(string username, string password)
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = @"Data Source=(LocalDb)\MSSqlLocalDb;Initial Catalog=manmode;Integrated Security=True;Pooling=False";
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = cn;
        cmd.CommandType = CommandType.Text;
        cmd.commandText = " Select count(*) from Users Where UserName = '"+ Username+"' and Password = '"+password+"'";
        
        cn.open();
        String abc = Cmd.ExecuteScalar().ToString();
        if (abc == "1")
        {
        cn.close();
        return True;
        }
        else
        {
        cn.close()
        return false;
         }
        
        

    public void DoWork()
    {
    }



}
