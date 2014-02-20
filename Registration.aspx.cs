using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //hide the linkbutton
        if (!IsPostBack)
            LinkButton1.Visible = false;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        //get the passcode
        PasscodeGenerator pg = new PasscodeGenerator();
        int passcode = pg.GetPasscode();
        //initialize customer and vehicle

        Customer c = new Customer();

        Vehicle v = new Vehicle();
        //initialize PasswordHash
        PasswordHash ph = new PasswordHash();

        //Assign the values from the textboxes
        //to the classes
        c.LastName = txtLastName.Text;
        c.FirstName = txtFirstName.Text;
        c.email = txtEmail.Text;
        c.password = txtPassword.Text;
        c.passcode = passcode;
        //get the hashed password
        c.PasswordHash = ph.Hashit(txtPassword.Text, passcode.ToString());
        c.apartment = txtApt.Text;
        c.state = txtState.Text;
        c.street = txtStreet.Text;
        c.zip = txtZip.Text;
        c.city = txtCity.Text;
        c.phone = txtPhone.Text;






       // v.License = txtLicense.Text;
        //v.Make = txtMake.Text;
      //  v.Year = txtYear.Text;
        try
        {
            //try to write to the database
            Registrations r = new Registrations(c);
            lblResult.Text = "Thank you for registering";
            LinkButton1.Visible = true;
        }
        catch (Exception ex)
        {
            //if it fails show the error
            lblError.Text = ex.ToString();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
}
