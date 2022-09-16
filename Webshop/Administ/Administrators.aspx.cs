using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using Members;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
using System.Data.Common;
using System.Globalization;
using System.Threading;



public partial class Administrators : System.Web.UI.Page
{
    Button newBtn;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if the user is "song", the page is loaded, otherwise the Default page is loaded
        if (Request.Cookies["visitor"] != null && Request.Cookies["visitor"].Value == "song")
        {

        }
        else
        {
            //the original value of each item is set as 0
            Response.Redirect("/Default.aspx");
        }
        //create a new Button to create an excel file    
        newBtn = new Button();
        newBtn.Text = "Create Excel File";
        newBtn.Visible = false;
        //add a click event to the button
        newBtn.Click += new EventHandler(this.Btn_Clicked);
        controlPanel.Controls.Add(newBtn);
        
    }

    //create new administrator
      protected void Button1_Click(object sender, EventArgs e)
      {
          //Roles.AddUserToRole(TextBox1.Text, "administrator");
      }

    //create the final report table
    DataTable newTable;
    protected void reportTb(DataTable reportTb)
    {
        //create a list to store product price
        List<string> priceList = new List<string>();
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            //get the product name of each item
            Goods theGoods = new Goods();
            DataTable goodsTable = theGoods.getGoodsById(Convert.ToInt32(reportTb.Columns[i].ColumnName.Substring(4)));
            if (goodsTable != null && goodsTable.Rows.Count != 0)
            {
                //put the price in price list
                priceList.Add(goodsTable.Rows[0]["Price"].ToString());
            }
        }
        //create a list to store the sum of each column, the beginning number is 0
        List<int> goodsOrder = new List<int>();
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            goodsOrder.Add(0);
        }
        //add the value of each cell to the correspondent value in the list 
        foreach (DataRow dr in reportTb.Rows)
        {
            for (int i = 0; i < reportTb.Columns.Count; i++)
            {
                goodsOrder[i] = goodsOrder[i] + Convert.ToInt32(dr[i]);
            }
        }
        //show the total sale number 
        int totalSalesNumber = 0;
        for (int i = 0; i < goodsOrder.Count; i++)
        {
            totalSalesNumber += goodsOrder[i];
        }
        //create a list to store the sale voulume of each item
        List<double> saleVolumeList = new List<double>();
        //calculate the value of each cell and store the value in saleVolumeList
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            //string test = priceList[i];
            saleVolumeList.Add(goodsOrder[i] * Convert.ToDouble(priceList[i].Substring(0, priceList[i].Length - 1)));
        }
        //calculate the total sale volume
        double totalSalesVolume = 0;
        for (int i = 0; i < saleVolumeList.Count; i++)
        {
            totalSalesVolume += saleVolumeList[i];
        }
        //create a new datatable
        newTable = new DataTable();
        //create the first datacolumn 
        DataColumn th0 = new DataColumn();
        th0.ColumnName = "Saled Items";
        th0.DataType = System.Type.GetType("System.String");
        //add the column to the table
        newTable.Columns.Add(th0);
        //create the other datacolumns
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            DataColumn th = new DataColumn();
            Goods goodItem = new Goods();
            int productId = Convert.ToInt32(reportTb.Columns[i].ToString().Substring(4));
            DataTable getProdutNam = goodItem.getGoodsById(productId);
            th.DataType = System.Type.GetType("System.String");
            th.ColumnName = getProdutNam.Rows[0]["Goodsname"].ToString();
            //add the column to the table
            newTable.Columns.Add(th);
        }
        //create a new row to the table
        DataRow saleAmntRow = newTable.NewRow();
        //create the first cell which explains that the row reprents the sale amount
        saleAmntRow[0] = "Sale amount";
        //create the other cells 
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            saleAmntRow[i+1] = goodsOrder[i];
        }
        //add the row to the table
        newTable.Rows.Add(saleAmntRow);
        //create another row
        DataRow saleVolRow = newTable.NewRow();
        //create the first column reporting that the total sale volume of each product item
        saleVolRow[0] = "Sale volume";
        //create the other datacolumns
        for (int i = 0; i < reportTb.Columns.Count; i++)
        {
            saleVolRow[i + 1] = saleVolumeList[i].ToString() + " ml";
        }
        //add the row to the table
        newTable.Rows.Add(saleVolRow);
        //create a row to report the total sale volume in the period
        DataRow totalSaleVol = newTable.NewRow();
        //create the columns reporting the total sale volume in the period
        totalSaleVol[0] = "Total sale volume";
        totalSaleVol[1] = totalSalesVolume.ToString() + " ml";
        //create other columns
        if (reportTb.Columns.Count > 2)
        {
            for (int i = 2; i < reportTb.Columns.Count - 1; i++)
            {
                totalSaleVol[i] = "";
            }
        }
        //add the row to the table
        newTable.Rows.Add(totalSaleVol);
        int count = reportTb.Columns.Count;
        Response.Write(count.ToString());
        //bind the table to a Gridview
        GridView reportGV = new GridView();
        reportGV.DataSource = newTable;
        reportGV.DataBind();
        controlPanel.Controls.Add(reportGV);
    }

    //create excel 
    public static void CreateExcel(DataTable db, string excelPath)
    {
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        //delete the existing excel file
        if (File.Exists(excelPath))
        {
            File.Delete(excelPath);
        }
        try
        {
            //create the schema
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 0; i <= db.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= db.Columns.Count - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = db.Rows[i].ItemArray[j].ToString();
                }
            }
            //save the file
            xlWorkBook.SaveAs(excelPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
        }
        catch(Exception excp)
        {
        }
       
    }
   
    //release office objects
    private static void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch
        {
            obj = null;
        }
        finally
        {
            GC.Collect();
        }
    }

    //get the report of chosen period
    protected void getRepBtn_Click(object sender, EventArgs e)
    {
        //get todays sale report
        if (ReporPeriodDlist.SelectedIndex == 0)
        {
            dailySales();
        }
        else
        {
            //get the sales of the chosen period
            salesCertainPeriod();
        }
        newBtn.Visible = true;
    }

    //create a path where you want to save the excel file
    protected string createExlPath()
    {
        //define the path to save the excel file
        string excelPath = Server.MapPath("/Reports/Salevolume-") + calendarUserCtrl.FromTime.ToString().Replace(":", "") + "-" + calendarUserCtrl.ToTime.ToString().Replace(":", "") + ".xls";
        return excelPath;
    }

    //event handle for exporting the report to an excel file
    protected void Btn_Clicked(Object sender, EventArgs e)
    {        
        Button Btn = (Button)sender;
        string excelPath = createExlPath();
        Orders theSales = new Orders();
        //change to the database culture
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //get the datatable 
        DataTable orderTable = theSales.getSalesCertainPeriod(calendarUserCtrl.FromTime, calendarUserCtrl.ToTime);
        //get the report
        createTable(orderTable);
        //save the newtable as an excel file
        CreateExcel(newTable, excelPath);
    }

//create daily report
protected void dailySales()
{
    Orders theOrder = new Orders();
        //get today date
        //string TodayDate = DateTime.Now.ToString().Substring(0, 10);
        DateTime TodayDate = DateTime.Now;
        //change to the database culture
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        DataTable orderTable = theOrder.getSalesToday(TodayDate);
    //get the report
    createTable(orderTable);
}

    //create sale report for a certain period
    protected void salesCertainPeriod()
    {
        Orders theSales = new Orders();
        //change to the database culture
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //get the datatable with smalldatetime 
        DataTable orderTable = theSales.getSalesCertainPeriod(calendarUserCtrl.FromTime, calendarUserCtrl.ToTime);
        //test
        int ros = orderTable.Rows.Count;
        //get the report
        createTable(orderTable);
    }

    //create report
    protected void createTable(DataTable orderTable)
    {
        //if the orders searched exist in the database
        if (orderTable != null && orderTable.Rows.Count > 0)
        {
            //delete the columns which are not in interest
            orderTable.Columns.Remove("Id");
            orderTable.Columns.Remove("Username");
            orderTable.Columns.Remove("Ordertime");
            orderTable.Columns.Remove("Shippingsta");
            orderTable.Columns.Remove("Complainment");
            orderTable.Columns.Remove("Resolution");
            //create a new arraylist to store data
            ArrayList collist = new ArrayList();
            //put the column names of the columns in which there are no sale records into the arraylist
            for (int i = 0; i < orderTable.Columns.Count; i++)
            {
                if (orderTable.Rows[0][i] == null || orderTable.Rows[0][i].ToString() == "0")
                {
                    collist.Add(orderTable.Columns[i].ColumnName);
                }
            }
            //remove the columns with the column names found in the arraylist collist
            foreach (string i in collist)
            {
                orderTable.Columns.Remove(i);
            }
            //test
            //int test = orderTable.Columns.Count;
            //create the raport table automatically
            reportTb(orderTable);
        }
        else
        {
            //pop up a warning box, if there is no sale record in the chosen period
            ClientScript.RegisterClientScriptBlock(this.GetType(),
           "PeriodSaleScript", "alert('There is no any sale in this period')", true);
        }
}

//choose reports of different periods
protected void ReporPeriodDlist_SelectedIndexChanged1(object sender, EventArgs e)
{   
    //if the period report is chosen, the calendar usercontrol becomes visible
    if (ReporPeriodDlist.SelectedIndex == 1)
    {
        //show the calendar usercontrol to chose time
        calendarUserCtrl.Visible = true;
    }  
    //the calendar usercontrol is not visible
    else
    {
       calendarUserCtrl.Visible = false;
    }    
}   

}



