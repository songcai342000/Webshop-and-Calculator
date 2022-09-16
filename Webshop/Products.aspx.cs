using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Members;
using System.Collections;
using System.Globalization;
using System.Threading;

public partial class Products : System.Web.UI.Page
{
    //private variables;
    int ID;
    string Price;
    string Size;
    string Weight;
    int Item1;
    int Item2;
    int Item3;
    int Item4;
    int Item5;
    int Item6;
    int Item7;
    int Item8;
    int Item9;
    int Item10;
    int ProductID;
    string Shippingsta;
    string Ordernumber;
    DateTime Ordertime;
    string Username;
    string Complainment;
    string Resolution;
    DataTable skinTable;
    Literal message;
    int itemNumber;
    Orders theOrder;
    Literal shoppingItem;
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        //if the user is denied to reach the page and sent to the log in page, he is sent to the page automatically after the user has logged in
        Session["previouspage"] = "Products.aspx";

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Shippingsta = "Not paid";
        Ordertime = DateTime.Now;
        //change the datetime culture to fit the database setting
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //Ordernumber;
        Complainment = "";
        Resolution = "";
        Goods allGoods = new Goods();
        theOrder = new Orders();
        //get all the products of skin care from database
        decimal lowPrice = 10;
        skinTable = allGoods.getGoodsByPrice(lowPrice);
        //bind the data with repeater
        if (skinTable.Rows.Count > 0)
        {
            Repeater1.DataSource = skinTable;
            Repeater1.DataBind();
        }
        else
        {
            //use control Literal to create front end code, because the string is supposed to be short
            message = new Literal();
            message.Text = "Sorry, we can't find the items you are looking for.";
            message.Visible = true;
        }
        //itemNumber is the count of the items in the shopping cart
        if (Session["itemNumber"] != null)
        {
            itemNumber = Convert.ToInt32(Session["itemNumber"].ToString());
        }
        //define Session["orderid"] to transfer the orderid to another page 
        if (itemNumber == 0)
        {
            Session["orderid"] = null;
        }
        Orders order = new Orders();
        if (Session["orderid"] != null)
        {
            Item1 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 1).Rows[0][0].ToString());
            Item2 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 2).Rows[0][0].ToString());
            Item3 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 3).Rows[0][0].ToString());
            Item4 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 4).Rows[0][0].ToString());
            Item5 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 5).Rows[0][0].ToString());
            Item6 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 6).Rows[0][0].ToString());
            Item7 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 7).Rows[0][0].ToString());
            Item8 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 8).Rows[0][0].ToString());
            Item9 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 9).Rows[0][0].ToString());
            Item10 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 10).Rows[0][0].ToString());
        }
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //Get product ID
        int row = e.Item.ItemIndex;
        ProductID = Convert.ToInt16(skinTable.Rows[row][0]);
        //if the user is not logged in, the login page is loaded
        if (Request.Cookies["visitor"] == null)
        {
            Response.Redirect("/Account/Login.aspx");
        }
        else if (e.CommandName == "chooseitem")
        {
            //define a string to show the itemNumber
            string itemString = Convert.ToString(itemNumber);
            Username = Request.Cookies["visitor"].Value;
            Goods theGoods = new Goods();
            //the itemquantity in the shopping cart plus one the user choose one item
            itemNumber++;
            //remember the itemquantity
            Session["itemNumber"] = itemNumber.ToString();
            shoppingItem = (Literal)this.Master.FindControl("itemNumber");
            shoppingItem.Text = itemNumber.ToString();
            
            //update or insert the order
            //determine which product should be count
            if (itemNumber == 1)
            {
                if (ProductID == 1)
                {
                    Item1++;
                    //theOrder.insertTable(Item1);
                }
                else if (ProductID == 2)
                {
                    Item2++;
                }
                else if (ProductID == 3)
                {
                    Item3++;
                }
                else if (ProductID == 4)
                {
                    Item4++;
                }
                else if (ProductID == 5)
                {
                    Item5++;
                }
                else if (ProductID == 6)
                {
                    Item6++;
                }
                else if (ProductID == 7)
                {
                    Item7++;
                }
                else if (ProductID == 8)
                {
                    Item8++;
                }
                else if (ProductID == 9)
                {
                    Item9++;
                }
                else if (ProductID == 10)
                {
                    Item10++;
                }
                //create a new order
                Orders theOrder = new Orders(Username, Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9, Item10, Ordertime, Shippingsta, Complainment, Resolution);
                theOrder.insertTable();
                //get the orders of the user
                DataTable theTable = theOrder.getOrderIdByUsername(Username);
                //the last order record of the user is the present order
                ID = Convert.ToInt32(theTable.Rows[theTable.Rows.Count - 1]["ID"]);
                //save the orderid
                Session["orderid"] = ID;
            }
            //the number of the chosen product increases one in the order table in the database 
            if (itemNumber > 1 && ProductID == 1)
            {
                Item1++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem1(Item1, ID);
            }
            else if (itemNumber > 1 && ProductID == 2)
            {
                Item2++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem2(Item2, ID);
            }
            else if (itemNumber > 1 && ProductID == 3)
            {
                Item3++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem3(Item3, ID);
            }
            else if (itemNumber > 1 && ProductID == 4)
            {
                Item4++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem4(Item4, ID);
            }
            else if (itemNumber > 1 && ProductID == 5)
            {
                Item5++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem5(Item5, ID);
            }
            else if (itemNumber > 1 && ProductID == 6)
            {
                Item6++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem6(Item6, ID);
            }
            else if (itemNumber > 1 && ProductID == 7)
            {
                Item7++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem7(Item7, ID);
            }
            else if (itemNumber > 1 && ProductID == 8)
            {
                Item8++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem8(Item8, ID);
            }
            else if (itemNumber > 1 && ProductID == 9)
            {
                Item9++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem9(Item9, ID);
            }
            else if (itemNumber > 1 && ProductID == 10)
            {
                Item10++;
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem10(Item10, ID);
            }
        }
        //if the user chose to remove a product from shopping cart
        else if (e.CommandName == "removeitem" && Convert.ToInt32(Session["itemNumber"]) > 0)
        {
            Orders order = new Orders();
            if (Session["orderid"] != null)
            {
                Item1 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 1).Rows[0][0].ToString());
                Item2 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 2).Rows[0][0].ToString());
                Item3 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 3).Rows[0][0].ToString());
                Item4 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 4).Rows[0][0].ToString());
                Item5 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 5).Rows[0][0].ToString());
                Item6 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 6).Rows[0][0].ToString());
                Item7 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 7).Rows[0][0].ToString());
                Item8 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 8).Rows[0][0].ToString());
                Item9 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 9).Rows[0][0].ToString());
                Item10 = int.Parse(order.getItemByOrderId(int.Parse(Session["orderid"].ToString()), 10).Rows[0][0].ToString());
            }
            //define a string to show the itemNumber 
            itemNumber = Convert.ToInt32(Session["itemNumber"]);
            //save the itemNumber
            Session["itemNumber"] = itemNumber.ToString();
            //show the itemNumber on the master page
            shoppingItem = (Literal)this.Master.FindControl("itemNumber");
            shoppingItem.Text = itemNumber.ToString();
            //if the itemNumber becomes 0, the order is deleted from the database
            if (itemNumber == 0)
            {
                theOrder.deleteOrder(ID);
                Session["orderid"] = null;
            }
            //determine which item is removed and update the order data in the database
            else if (ProductID == 1 && Item1 > 0)
            {
                Item1--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem1(Item1, ID);
            }
            else if (ProductID == 2 && Item2 > 0)
            {
                Item2--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem2(Item2, ID);
            }
            else if (ProductID == 3 && Item3 > 0)
            {
                Item3--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem3(Item3, ID);
            }
            else if (ProductID == 4 && Item4 > 0)
            {
                Item4--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem4(Item4, ID);
            }
            else if (ProductID == 5 && Item5 > 0)
            {
                Item5--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem5(Item5, ID);
            }
            else if (ProductID == 6 && Item6 > 0)
            {
                Item6--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem6(Item6, ID);
            }
            else if (ProductID == 7 && Item7 > 0)
            {
                Item7--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem7(Item7, ID);
            }
            else if (ProductID == 8 && Item8 > 0)
            {
                Item8--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem8(Item8, ID);
            }
            else if (ProductID == 9 && Item9 > 0)
            {
                Item9--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem9(Item9, ID);
            }
            else if (ProductID == 10 && Item10 > 0)
            {
                Item10--;
                itemNumber--;
                Session["itemNumber"] = itemNumber.ToString();
                //show the itemNumber on the master page
                shoppingItem = (Literal)this.Master.FindControl("itemNumber");
                shoppingItem.Text = itemNumber.ToString();
                ID = Convert.ToInt32(Session["orderid"]);
                theOrder.updateOrderItem10(Item10, ID);
            }
        }
    }

   
}