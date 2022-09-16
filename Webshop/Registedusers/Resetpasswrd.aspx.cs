using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Members;
using System.Text;

public partial class Resetpasswrd : System.Web.UI.Page
{
    string Username;
    Customers theUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        //requires login
        if (Request.QueryString["70138"] == null || Request.QueryString["70138"] == "")
        {
            Response.Redirect("/Default.aspx");
        }
        //get the query string
        string identity = Request.QueryString["70138"].ToString();
        //replace the "+" in the crypted query string
        string replacedString = identity.Replace(" ", "+");
        Byte[] identityCharArray = Convert.FromBase64String(replacedString);
        //decrypt the query string
        string decryptedString = Plusreduce.DecryptStringFromBytes_Aes(identityCharArray);
        //get the username 
        Username = decryptedString.Substring(0, decryptedString.Length - 19);
        //get the time information in the query string
        string Updatetime = decryptedString.Substring(decryptedString.Length - 19);
        //check if it is less than 3 days
        if (Convert.ToDateTime(Updatetime) > DateTime.Now.AddDays(-3))
        {
            
        }
        //if it is older than 3 days, the updating is dynied
        else
        {
            saveBtn.Enabled = false;
            warning.Text = "Sorry, something is wrong. Try later.";
        }
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {
        theUser = new Customers();
        //encryp the new password
        string plainpasswrd = repeatTxt.Text;
        byte[] encrypted = Plusreduce.EncryptStringToBytes_Aes(plainpasswrd);
        string Passwrd = Convert.ToBase64String(encrypted);
        //update the password
        theUser.updatePasswrd(Username, Passwrd);
        Response.Redirect("/Account/Login.aspx");
    }
}
