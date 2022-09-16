using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Globalization;
using System.Text.RegularExpressions;
using Members;
using System.Data;
using System.IO;
using System.Security.Cryptography;

public partial class Createuser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session to remember the present page
        //Session["previouspage"] = "Account/Createuser.aspx";
        //the user logged in can not register
        if (Request.Cookies["visitor"] != null)
        {
            UserTxt.Enabled = false;
            EmailTxt.Enabled = false;
            genderList.Enabled = false;
            PasswrdTxt.Enabled = false;
            ConfirPasswrdTxt.Enabled = false;
            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator5.Enabled = false;

        }

    }

    //get gender value
    string Gender;
    string Username;
    string Custemail;
    string Passwrd;
    string Userrole = "Customer";

  //get the chosen gender
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void genderTxt_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gender = genderList.SelectedValue;
        //Session["gender"] = Gender;
    }

    //register new user

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        //create a new user object
            Customers theUser = new Customers();
            Username = UserTxt.Text;
            Custemail = EmailTxt.Text;
            Gender = genderList.SelectedValue;
        //encrypt the password
            string plainpasswrd = PasswrdTxt.Text;          
            byte[] encrypted = Plusreduce.EncryptStringToBytes_Aes(plainpasswrd);
            Passwrd = Convert.ToBase64String(encrypted);
            //check if the user name exists in the database
            DataTable userTable = theUser.getUser(UserTxt.Text.Trim());
            //function added check if the email is registrated
            DataTable EmailTable = theUser.getUser(EmailTxt.Text.Trim());
            //if the user name is found in the database, the label shows a warning that the username is occupied
            if (userTable.Rows.Count > 0)
            {
                Label1.Visible = true;
                Label1.Text = "The Username is occupied.";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else if (EmailTable.Rows.Count > 0)
            {
                Label1.Visible = true;
                Label1.Text = "The Username is occupied.";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                //if the user name is available, insert the new user into database 
                theUser.insertCustomer(Custemail, Passwrd, Username, Gender, Userrole);
                if (Request.Cookies["visitor"] == null)
                {
                    Response.Cookies["visitor"].Value = Username;
                    Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["visitor"].Path = "/";
                }
                //registration successes, the profile page where the user can edit his profile is loaded
                Response.Redirect("/Registedusers/Myprofile.aspx");
            }
    }

    //when the text of UserTxt textbox changes, the program checks if the user name exists in the database
    protected void UserTxt_TextChanged(object sender, EventArgs e)
    {
        Label1.Visible = false;
        Customers theUser = new Customers();
        //check if user with the username exists in the database
        DataTable userTable = theUser.getUser(UserTxt.Text);
        if (userTable.Rows.Count > 0)
        {
            //shows a warning if the username is occupied
            Label1.Visible = true;
            Label1.Text = "The Username is occupied.";
            //define the text color of the label
            Label1.ForeColor = System.Drawing.Color.Green;
        }
    }

   
}