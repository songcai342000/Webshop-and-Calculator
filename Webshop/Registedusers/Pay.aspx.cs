using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;

public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //test
        //updateShippingStatus();
    }

    //update the shipping status in the database
    protected void updateShippingStatus()
    {
        Orders theOrder = new Orders();
        string Shippingsta = "Paid";
        //theOrder.updateShipping(Shippingsta, Convert.ToInt32(Session["orderid"].ToString()));
        //test
        theOrder.updateShipping(Shippingsta, 2);
    }
}