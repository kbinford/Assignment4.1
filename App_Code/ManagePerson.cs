using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ManagePerson
/// this class' purpose would be to retrieve
/// and manage the customer class. There are
/// a lot of methods and features that should be
/// added, but I only did the one I need for the
/// example.
/// </summary>
public class ManagePerson
{

    Customer c;
    int id;
    SqlConnection connect;

    public ManagePerson(int customerID)
    {

        id = customerID;
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ConnectionString);
    }

    public Customer GetCustomer()
    {
        //same pattern. 
        //1. Create Sql String
        //2. Create command object
        //3. give values to any parameters
        //4. create a reader object
        //5. open the connection
        //6. Execute the reader
        //7. loop through the reader to get the data
        //8. Close reader
        //9. Close Connection
        //10. return the object containing the data


        Customer c = new Customer();
        string sql = "Select PersonLastName, PersonFirstName, PersonUsername "
            + "from Person  "
            //+ "Inner Join Customer.RegisteredCustomer rc "
           // + "on p.PersonKey=rc.PersonKey "
            + "Where PersonKey=@customerID";

        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@CustomerID", id);
        SqlDataReader reader;

        connect.Open();
        reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                c.LastName = reader["PersonLastName"].ToString();
                c.FirstName = reader["PersonFirstName"].ToString();
                c.email = reader["PersonUsername"].ToString();
            }
        }
        reader.Close();
        connect.Close();

        return c;
    }


}