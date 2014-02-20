using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ManageVehicle
/// </summary>
public class ManageVehicle
{

    SqlConnection connect;
	public ManageVehicle()
	{
		//
		// TODO: Add constructor logic here
		//
        
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["AutomartConnectionString"].ConnectionString);
	}

    public DataTable GetVehicle(int personkey)
    {
        string sql = "Select FirstName, LastName LicenseNumber, VehicleMake, VehicleYear FromCustomer.Vehicle inner join Person on person.PersonKey = Customer.Vehicle.PersonKey where personkey = @personkey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@personkey", personkey);
        SqlDataReader reader = null;
        DataTable table = new DataTable();
        connect.Open();
        reader = cmd.ExecuteReader();
        table.Load(reader);
        reader.Dispose();
        connect.Close();

        return table;



    }

}