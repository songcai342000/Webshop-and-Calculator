using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;
using System.Data;
using System.Collections;
using System.Text;


public partial class Counter : System.Web.UI.Page
{
    int Orderid;
    decimal totalPrice;
    string item;
    string Custname;
    string Username;
    string Telephone;
    String Billingadrs;
    string Custemail;
    DataTable theTable;
    DataTable updatedTable;
    Customers theUser;
    protected void Page_Load(object sender, EventArgs e)
    {
        //requires login
        if (Request.Cookies["visitor"] == null)
        {
            Response.Redirect("/Account/Login.aspx");
        }
        Goods orderedGoods = new Goods();
        //if there is a order
        if (Session["orderid"] != null)
        {
            //create the header of html table of the shopping summary
            item = "<table class='table'><tr><td>Name</td>"  +
                "<td>Size</td>" +
                "<td>Weight</td>" +
                "<td>Price</td><td>Quantity</td> <tr/>";
            Orderid = Convert.ToInt32(Session["orderid"].ToString());
            //get order items by orderid
            Orders theOrder = new Orders();
            DataTable theTable = theOrder.getOrderByID(Orderid);
            ArrayList collist = new ArrayList();
            //put the names of the columns in which there is no order in list
            for (int i = 0; i < theTable.Columns.Count; i++)
            {
                if (theTable.Rows[0][i] == null || theTable.Rows[0][i].ToString() == "0")
                {
                    collist.Add(theTable.Columns[i].ColumnName);
                }
            }
            //remove the columns from the datatable
            foreach (string i in collist)
            {
                theTable.Columns.Remove(i);
            }
            //create the content of the html table according to the datatable
            for (int j = 0; j < theTable.Columns.Count; j++)
            {
                string Itemnumber = theTable.Columns[j].ColumnName;
                int goodsId = Convert.ToInt32(Itemnumber.Substring(4, Itemnumber.Length - 4));
                DataTable goodsTable = orderedGoods.getGoodsById(goodsId);
                if (goodsTable != null)
                {
                    item = item + "<tr><td>" + goodsTable.Rows[0]["Goodsname"].ToString() + "</td><td>" + goodsTable.Rows[0]["Size"].ToString() + " ml</td><td>" + goodsTable.Rows[0]["Weight"].ToString() + " g</td><td>" + goodsTable.Rows[0]["Price"].ToString() + " $</td><td>" + theTable.Rows[0][j].ToString() + "</td></tr>";
                    //string Pricestring = goodsTable.Rows[0]["Price"].ToString();
                    // totalPrice = totalPrice + (Convert.ToInt32(Pricestring.Substring(0, Pricestring.Length - 1)))*(Convert.ToInt32(theTable.Rows[0][j]));
                    decimal priceValue = Convert.ToDecimal(goodsTable.Rows[0]["Price"].ToString());
                     totalPrice += priceValue*(Convert.ToInt32(theTable.Rows[0][j]));
                }
            }
            string totalprice = "<tr><td>Total price: " + totalPrice.ToString() + "$" + "<td></td><td></td><td></td><td></td></tr></table>";
            item = item + totalprice;
            literal1.Text = item;
        }
       
        //the contact information of the user
        Username = Request.Cookies["visitor"].Value;
        theUser = new Customers();
        theTable = theUser.getProfil(Username);
        Billingadrs = billingTxt.Text;
        Custname = nameTxt.Text;
        Telephone = telephoneTxt.Text;
        Custemail = emailTxt.Text;
        theUser.updateContactInfor(Custname, Telephone, Billingadrs, Custemail);
        //update the contact information of the user
        updatedTable = theUser.getProfil(Username);
        //show the old contact information of the user
        if (theTable.Rows.Count > 0)
        {
            nameTxt.Text = theTable.Rows[0]["Custname"].ToString();
            telephoneTxt.Text = theTable.Rows[0]["Telephone"].ToString();
            billingTxt.Text = theTable.Rows[0]["Billingadrs"].ToString();
            emailTxt.Text = theTable.Rows[0]["Custemail"].ToString();
            theUser.updateContactInfor(nameTxt.Text, telephoneTxt.Text, billingTxt.Text, emailTxt.Text);
        }
    }

    /// <summary>
    /// confirm contact information of the user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void confirm_Click(object sender, EventArgs e)
    {
        if (updatedTable.Rows.Count > 0)
        {
            nameTxt.Text = updatedTable.Rows[0]["Custname"].ToString();
            telephoneTxt.Text = updatedTable.Rows[0]["Telephone"].ToString();
            billingTxt.Text = updatedTable.Rows[0]["Billingadrs"].ToString();
            emailTxt.Text = updatedTable.Rows[0]["Custemail"].ToString();
            Custname = nameTxt.Text;
            Telephone = telephoneTxt.Text;
            Billingadrs = billingTxt.Text;
            Custemail = emailTxt.Text;
            try
            {
                theUser.updateContactInfor(Custname, Telephone, Billingadrs, Custemail);
                Response.Redirect("/Registedusers/Pay.aspx");
            }
            catch
            { }
        }
    }

    /// <summary>
    /// return to the page where the user chose the last item
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void return_Click(object sender, EventArgs e)
    {
        if (Session["previouspage"].ToString().Contains("Sproducts") || Session["previouspage"].ToString().Contains("Cproducts") || Session["previouspage"].ToString().Contains("Hproducts") || Session["previouspage"].ToString().Contains("Pproducts"))
        {
            Response.Redirect("/" + Session["previouspage"].ToString());
        }
        else if (Session["previouspage"].ToString() == "Products.aspx")
        {
            Response.Redirect("/Products.aspx");
        }
        else
        {
            Response.Redirect("/Default.aspx");

        }
    }
    protected void paypal_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void visa_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void master_CheckedChanged(object sender, EventArgs e)
    {

    }
}