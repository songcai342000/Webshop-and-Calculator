using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Windows;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //the user comes back to the page when he has logged in
        Session["previouspage"] = "Default.aspx";
        
    }

}