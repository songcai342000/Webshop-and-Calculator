using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;

public partial class Confirmcontactinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["visitor"] == null || Session["visitor"].ToString() == "")
        {
            Response.Redirect("/Login.aspx");
        }
        //get the contact information


    }

    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        Customers theUser = new Customers();
        string Custname = nameTxt.Text;
        string Telephone = telephoneTxt.Text;
        string Address = billingTxt.Text;
        string Email = emailTxt.Text;
        theUser.updateContactInfor(Custname, Telephone, Address, Email);
        
    }

}