using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Members;
using System.Data;
using System.Text;

public partial class Recoverpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void SendBtn_Click(object sender, EventArgs e)
    {
        Customers theUser = new Customers();
        //update the lastUpdateTime by email
        theUser.updateTime(emailTxt.Text);
        //get the user name
        
        //get the username and last updatetime
        DataTable userUpdateTimeTb = theUser.getUserUpdateTime(emailTxt.Text);
        //if the email address exists, send the profile data to the plateform
        if (userUpdateTimeTb != null && userUpdateTimeTb.Rows.Count > 0)
        {
            //get the username and the last updatetime
            string plainText = userUpdateTimeTb.Rows[0][0].ToString() + userUpdateTimeTb.Rows[0][1].ToString();
            //encrypt the string 
            Byte[] encryptedUserUpdatetime = Plusreduce.EncryptStringToBytes_Aes(plainText);
            string encryptedUserUpddatetimeString = Convert.ToBase64String(encryptedUserUpdatetime);
            //create the url with query string containing usernmae and last updatetime
            string link = "http://localhost:51852/Registedusers/Resetpasswrd.aspx?70138=" + encryptedUserUpddatetimeString;
            string to = emailTxt.Text;
            string from = "songhelene@hotmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Reset your password";
            message.Body = "Click the following link to reset your password. " + link + " The link is valid for 72 hours.";
            SmtpClient client = new SmtpClient("smtp.bluecom.no");
            client.UseDefaultCredentials = true;
            //send a mail message according to sending state    
            try
            {
                client.Send(message);
                warning.Text = "The link to reset password has been sent to the email address.";
            }
            catch
            {
                warning.Text = "Sorry, something is wrong. Try later.";
            }
        }
        else
        {
            //shows the warning if the epost address doesn't exist in the database
            warning.Text = "Sorry, We can't find the email address.";
        }
    }
}

