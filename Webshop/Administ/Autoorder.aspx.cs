using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;
using System.Data;
using System.Net.Mail;
using System.Timers;
using System.Threading;

public partial class Administ_Autoorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //set the timer
        SetTimer();
    }

    //create report for the products having too little amount in the store
    protected void shortageRep_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       
    }

    
    
    private void SetTimer()
    {
        //Create a timer with one hour interval.
        System.Timers.Timer aTimer = new System.Timers.Timer();
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 3600000;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    //order the products
    static DataTable theTable;
    static MailMessage orderMail;
    static SmtpClient theClient;
    private void OnTimedEvent(Object source, ElapsedEventArgs e)
    {

        //get the products which need supplement
         Goods theGoods = new Goods();
         theTable = theGoods.getSmallGoodsQuantity();
         //Supplements theSupplements = new Supplements();
         int ProductId;
         int Orderquantity;
         int confirm = 0;
         if (theTable.Rows.Count > 0)
         {
             //determine the productId of the products
             for (int i = 0; i < theTable.Rows.Count; i++)
             {
                //decide the order amounts of the products 
                 ProductId = Convert.ToInt32(theTable.Rows[i]["ID"].ToString());
                 if (ProductId == 1)
                 {
                     Orderquantity = 1000;
                 }
                 else if (ProductId == 2)
                 {
                     Orderquantity = 1050;
                 }
                 else if (ProductId == 3)
                 {
                     Orderquantity = 1050;
                 }
                 else if (ProductId == 4)
                 {
                     Orderquantity = 650;
                 }
                 else if (ProductId == 5)
                 {
                     Orderquantity = 900;
                 }
                 else if (ProductId == 6)
                 {
                     Orderquantity = 1000;
                 }
                 else if (ProductId == 7)
                 {
                     Orderquantity = 1200;
                 }
                 else if (ProductId == 8)
                 {
                     Orderquantity = 900;
                 }
                 else if (ProductId == 9)
                 {
                     Orderquantity = 700;
                 }
                 else
                 {
                     Orderquantity = 650;
                 } 

                //send the order to the vendors with email 
                string from = "songcai342000@gmail.com";
                //string to = theTable.Rows[i]["Vendemail"].ToString();
                string to = "songcai342000@yahoo.com";
                //create the mail message
                orderMail = new MailMessage(from, to);
               
        orderMail.Subject = "New Order from BlueberryNet:" + theTable.Rows[i]["Goodsname"] + " " + Orderquantity;
       orderMail.Body = "To " + theTable.Rows[i]["Vendname"].ToString() + ": \n We order " + Orderquantity + "sticks of " +
            theTable.Rows[i]["Goodsname"] + "Price: " + theTable.Rows[i]["Price"].ToString() + "Size: " +
            theTable.Rows[i]["Size"].ToString() + "Weight: " + theTable.Rows[i]["Weight"].ToString();
                theClient = new SmtpClient("smtp.bluecom.no");
                theClient.UseDefaultCredentials = true;
                try
                {
                    //send the email after 5 minutes
                    ThreadPool.QueueUserWorkItem(ThreadSendMail);
                    Thread.Sleep(300000);
                    //if the mail is sent successfully, confirm++
                    confirm = i + 1;
                }
                catch
                {
                    //warning.Text = "Sorry, something is wrong. Try later.";
                }
             //if the mail is sent successfully, save the order to the database
            if (confirm == i + 1)
            {
                string Price = theTable.Rows[i]["Price"].ToString();
                    //save the supplement information to database
                    ThreadPool.QueueUserWorkItem(ThreadSaveOrder);
                    Thread.Sleep(1000);
            }
        }
       }
    }

    // This thread processes mail sending
    static void ThreadSendMail(Object stateInfo)
    {
        //send the order to the vendor
        theClient.Send(orderMail);
    }

    // This thread process save the order information to database
    static void ThreadSaveOrder(Object stateInfo)
    {
        //save to database
        // theSupplements.insertSupplement(ProductId, Convert.ToInt32(theTable.Rows[i]["Vendname"].ToString()), Orderquantity, DateTime.Now.ToString(), ((Convert.ToDouble(Price.Substring(0, Price.Length - 2))) * Orderquantity).ToString(), "Not Paid", "Ordered");
    }
}