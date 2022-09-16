using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using System.Security.Cryptography;
using Members;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Text;

public partial class Account_Login : Page
{
    string Username;
    string Passwrd;
    Customers theUser;
    string Decryptedstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            //the page is deactivated if the user has logged in
            if (Request.Cookies["visitor"] != null && Session["previouspage"] != null)
            {
                Response.Redirect("/" + Session["previouspage"].ToString());
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
        //check if there is user with the username and password in the database
        Username = UserName.Text;
            Passwrd = Password.Text;
            theUser = new Customers();
        //get user by username from database
            DataTable theTable = theUser.getUser(Username);
        if (theTable.Rows.Count == 1)
        {
            //decrypt the password of the user and check if it matches with the password typed in
            string encryptedString = theTable.Rows[0]["Passwrd"].ToString();
            encryptedString = encryptedString.Replace(" ", "+");
            byte[] encryptArray = Convert.FromBase64String(encryptedString);
            Decryptedstring = Plusreduce.DecryptStringFromBytes_Aes(encryptArray);

            //if the password matches, establish cookie for the user
            if (Decryptedstring == Passwrd)
            {
                Response.Cookies["visitor"].Value = Username.Trim();
                Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(1);
                Response.Cookies["visitor"].Path = "/";
                //if the user comes from another page on the website, the previous page is loaded after logging
                if (Session["previouspage"] != null)
                {
                    Response.Redirect("/" + Session["previouspage"].ToString());
                }
                //otherwise Default page is loaded
                else
                {
                    Response.Redirect("/Default.aspx");
                }
            }
            //if the password doesn't match, the Recoverpassword page is loaded
            else
            {
                Response.Redirect("/Account/Recoverpassword.aspx");

            }
        }
        //if the username doesn't exists in the database, the page Createuser is loaded
        else
        {
            Response.Redirect("/Account/Createuser.aspx");
        }
    }
 
}