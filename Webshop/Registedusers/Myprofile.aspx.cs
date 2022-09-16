using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;
using System.Data;
using System.Web.Security;

public partial class Myprofile : System.Web.UI.Page
{

    string Username;
    string Gender;
    string Billingadrs;
    string Custemail;
    string Telephone;
    string Custname;
    string Passwrd;
    string Sign;
    DataTable updatedTable;
    DataTable theTable;
    Customers theUser;
    string currentUsername;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        //requires login
        if (Request.Cookies["visitor"] == null)
        {
            Response.Redirect("/Account/Login.aspx");
        }
        //get the new profile data
        theUser = new Customers();
        Username = Request.Cookies["visitor"].Value;
        theTable = theUser.getProfil(Username);
        /*nameTxt.Text = theTable.Rows[0]["Custname"].ToString();
        genderList.SelectedValue = theTable.Rows[0]["Gender"].ToString();
        billingTxt.Text = theTable.Rows[0]["Billingadrs"].ToString();
        usernameTxt.Text = theTable.Rows[0]["Username"].ToString();
        emailTxt.Text = theTable.Rows[0]["Custemail"].ToString();
        telephoneTxt.Text = theTable.Rows[0]["Telephone"].ToString();*/

        Gender = genderList.SelectedValue;
        Billingadrs = billingTxt.Text;
        Custemail = emailTxt.Text;
        Custname = nameTxt.Text;
        Username = usernameTxt.Text;
        Telephone = telephoneTxt.Text;
        DataTable userTable = theUser.getProfil(Username);
        currentUsername = Request.Cookies["visitor"].Value.Trim();
        //update the profile
        if (Username.Trim() != currentUsername)
        {
            if (userTable == null && currentUsername != "")
            {
                    theUser.updateProfil(Custname, Billingadrs, Telephone, Custemail, Username, Gender, DateTime.Now.ToString(), currentUsername);
            }
        }
        else if (userTable.Rows.Count == 1)
        {
            theUser.updateProfil(Custname, Billingadrs, Telephone, Custemail, Username, Gender, DateTime.Now.ToString(), currentUsername);
        }
        //get the updated user data, show the updated table after save click
        updatedTable = theUser.getProfil(Username);
        //show the data before updated
        if (theTable.Rows.Count == 1)
        {
            nameTxt.Text = theTable.Rows[0]["Custname"].ToString();
            usernameTxt.Text = theTable.Rows[0]["Username"].ToString();
            genderList.SelectedValue = theTable.Rows[0]["Gender"].ToString();
            telephoneTxt.Text = theTable.Rows[0]["Telephone"].ToString();
            billingTxt.Text = theTable.Rows[0]["Billingadrs"].ToString();
            emailTxt.Text = theTable.Rows[0]["Custemail"].ToString();
            pointsTxt.Text = (theTable.Rows[0]["Points"].ToString());
            theUser.updateProfil(nameTxt.Text, billingTxt.Text, telephoneTxt.Text, emailTxt.Text, usernameTxt.Text, genderList.SelectedValue, DateTime.Now.ToString(), usernameTxt.Text);
        }
        
    }

    /// <summary>
    /// delete the profile
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        //delete the customer
        Customers theUser = new Customers();
        try
        {
            theUser.deleteCustomer(Username);
            nameTxt.Text = "";
            telephoneTxt.Text = "";
            genderList.SelectedValue = "";
            repeaterpassword.Text = "";
            usernameTxt.Text = "";
            billingTxt.Text = "";
            emailTxt.Text = "";
            pointsTxt.Text = "";
            if (Request.Cookies["visitor"] != null)
            {
                Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(-1);
            }
            LinkButton Account = (LinkButton)Master.FindControl("ctl00$ctl13$accountBtn");
            Account.Text = "Account";
        }
        catch
        { }
    }


    //get gender data 
    protected void genderList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Gender = genderList.SelectedValue.ToString();

    }

    //check if the username is occupied
    protected void usernameTxt_TextChanged1(object sender, EventArgs e)
    {
        Username = usernameTxt.Text;
        Label1.Visible = false;
        Customers theUser = new Customers();
        DataTable userTable = theUser.getUser(Username.Trim());
        if (userTable.Rows.Count > 0)
        {
            Label1.Visible = true;
            Label1.Text = "The Username is occupied.";
            Label1.ForeColor = System.Drawing.Color.Green;
            saveBtn.Enabled = false;

        }
    }

    /// <summary>
    /// save the profile data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void saveBtn_Click1(object sender, EventArgs e)
    {
        //update profile

        if (updatedTable != null && updatedTable.Rows.Count == 1)
        {
            nameTxt.Text = updatedTable.Rows[0]["Custname"].ToString();
            usernameTxt.Text = updatedTable.Rows[0]["Username"].ToString();
            genderList.SelectedValue = updatedTable.Rows[0]["Gender"].ToString();
            telephoneTxt.Text = updatedTable.Rows[0]["Telephone"].ToString();
            billingTxt.Text = updatedTable.Rows[0]["Billingadrs"].ToString();
            emailTxt.Text = updatedTable.Rows[0]["Custemail"].ToString();
            pointsTxt.Text = (updatedTable.Rows[0]["Points"].ToString());
            DataTable userTable = theUser.getUser(usernameTxt.Text.Trim());
            if (usernameTxt.Text.Trim() != Request.Cookies["visitor"].Value)
            {
                if (userTable.Rows.Count > 0)
                {
                    Label1.Visible = true;
                    Label1.Text = "The Username is occupied.";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    saveBtn.Enabled = false;
                }
                else
                {
                    theUser.updateProfil(nameTxt.Text, billingTxt.Text, telephoneTxt.Text, emailTxt.Text, usernameTxt.Text, genderList.SelectedValue, DateTime.Now.ToString(), usernameTxt.Text);
                    Response.Cookies["visitor"].Value = usernameTxt.Text.Trim();
                    Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["visitor"].Path = "/";
                }
            }
            else if (userTable.Rows.Count == 1)
            {
                theUser.updateProfil(nameTxt.Text, billingTxt.Text, telephoneTxt.Text, emailTxt.Text, Username, genderList.SelectedValue, DateTime.Now.ToString(), Request.Cookies["visitor"].Value);
            }
        }
        //theUser.updateProfil(Custname, Billingadrs, Telephone, Custemail, Username, Gender, DateTime.Now.ToString(), currentUsername);
        updatedTable = theUser.getProfil(Username);
        Response.Cookies["visitor"].Value = usernameTxt.Text.Trim();
        Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(1);
        Response.Cookies["visitor"].Path = "/";
        if (nameTxt.Text != null || nameTxt.Text != "")
        {
            namerequired.Enabled = false;
        }
        if (billingTxt.Text != null || billingTxt.Text != "")
        {
            billingrequired.Enabled = false;
        }
        if (telephoneTxt.Text != null || telephoneTxt.Text != "")
        {
            telephonerequired.Enabled = false;
        }
        Response.Cookies["visitor"].Value = Username;
    }

    protected void savenewpassBtn_Click(object sender, EventArgs e)
    {

    }

    //update the data fields
    protected void nameTxt_TextChanged(object sender, EventArgs e)
    {
        Custname = nameTxt.Text;
    }

    protected void telephoneTxt_TextChanged(object sender, EventArgs e)
    {
        Telephone = telephoneTxt.Text;
    }

    protected void billingTxt_TextChanged(object sender, EventArgs e)
    {
        Billingadrs = billingTxt.Text;
    }

    protected void emailTxt_TextChanged(object sender, EventArgs e)
    {
        Custemail = emailTxt.Text;
    }
}