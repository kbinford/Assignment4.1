using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//libraries required for this class
using System.Data; //general data
using System.Data.SqlClient; //sql server
using System.Configuration; //to get access to the web config file

/// <summary>
/// Summary description for Registration
/// This class takes a customer and vehicle object
/// extracts the properties from them
/// and writes them to the automart database
/// </summary>
public class Registrations
{
    Customer c;
    
    SqlConnection connect;

    public Registrations (Customer cust)
    {
        c = cust;
      
        //get the connection string from the web config file
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings  ["CommunityAssistConnectionString"].ConnectionString);
        //call the WriteToDatabase() method
        //it needs to be in a try catch because as the calling method
        //this is where the thrown method would be caught
        //we need to rethrow it so it makes it out
        //to the web form
        try
        {
            WriteToDatabase();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void WriteToDatabase()
    {
        //set up the sql strings for each table
        /*
        string sqlPerson = "Insert into person(LastName, FirstName)"
            + " Values(@lastName, @firstname)";
        string sqlCustomer = "Insert into Customer.RegisteredCustomer"
            + "(PersonKey, Email, CustomerPassword, CustomerPasscode, CustomerHashedPassword)"
            + " Values(Ident_current('Person'), @email, @password, @passcode, @hashed)";
        string sqlVehicle = "insert into Customer.Vehicle(personkey,LicenseNumber, Vehiclemake, VehicleYear)"
            + " Values(Ident_current('Person' ),@License, @make, @year)";

        */

        string sqlPerson = "Insert into person(PersonLastName, PersonFirstName, PersonUsername, PersonPlainPassword, Personpasskey,             PersonEntryDate, PersonUserPassword)"
            + " Values(@lastName, @firstname, @email, @password, @passcode, getdate(), @hashed)";

        
        string sqlPersonAddress = "insert into PersonAddress(Street, Apartment, State, City, Zip, PersonKey)"
                    + " Values(@street, @apartment, @state, @city, @zip, Ident_current('Person' ))";

        string sqlPersonContact = "insert into PersonContact(ContactInfo, PersonKey, ContactTypeKey)"
            + " Values(@phone, Ident_current('Person' ), 1)";

        
        //create a command for each sqlstring and provide values
        //for the parameters
        SqlCommand cmdPerson = new SqlCommand(sqlPerson, connect);
        cmdPerson.Parameters.AddWithValue("@LastName", c.LastName);
        cmdPerson.Parameters.AddWithValue("@FirstName", c.FirstName);
        cmdPerson.Parameters.AddWithValue("@email", c.email);
        cmdPerson.Parameters.AddWithValue("@password", c.password);
        cmdPerson.Parameters.AddWithValue("@Passcode", c.passcode);
        cmdPerson.Parameters.AddWithValue("@hashed", c.PasswordHash);

      

        SqlCommand cmdPersonAddress = new SqlCommand(sqlPersonAddress, connect);
        cmdPersonAddress.Parameters.AddWithValue("@street", c.street);
        cmdPersonAddress.Parameters.AddWithValue("@apartment", c.apartment);
        cmdPersonAddress.Parameters.AddWithValue("@state", c.state);
        cmdPersonAddress.Parameters.AddWithValue("@city", c.city);
        cmdPersonAddress.Parameters.AddWithValue("@zip", c.zip);





        SqlCommand cmdPersonContact = new SqlCommand(sqlPersonContact, connect);
        cmdPersonContact.Parameters.AddWithValue("@phone", c.phone);
        

        //create a transaction object
        SqlTransaction tran = null;



        //open the connection
        connect.Open();
        //start the transaction
        tran = connect.BeginTransaction();

        //try the inserts, if all are successful
        //commit the transaction
        try
        {
            //assign all the commands to the same transaction
            cmdPerson.Transaction = tran;
            cmdPersonAddress.Transaction = tran;
            cmdPersonContact.Transaction = tran;

            cmdPerson.ExecuteNonQuery();
            cmdPersonAddress.ExecuteNonQuery();
            cmdPersonContact.ExecuteNonQuery();

            tran.Commit();
        }
        catch (Exception ex)
        {
            //if there are any errors
            //roll back the transaction 
            //and throw the error
            tran.Rollback();
            throw ex;
        }
        finally //no matter what
        {
            connect.Close();
        }



    }
}