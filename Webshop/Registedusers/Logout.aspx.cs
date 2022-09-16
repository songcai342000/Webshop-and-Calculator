using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registedusers_Logout : System.Web.UI.Page
{
    /// <summary>
    /// log out by expiring the cookie
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["visitor"] != null)
        {
            Response.Cookies["visitor"].Expires = DateTime.Now.AddDays(-1);
        }
        //remove the item number of the shopping cart
        Session["itemNumber"] = null;
        Response.Redirect("/Default.aspx");
    }
}