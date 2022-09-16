using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Members;
using System.Data;
using System.Text;


public partial class Registgoods : System.Web.UI.Page
{
    string Ogvendor;
    string Ngvendor;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if the user is song, the page is loaded. otherwise Default page is loaded
        if (Request.Cookies["visitor"] != null && Request.Cookies["visitor"].Value == "song")
        {
            /*StringBuilder sbj = new StringBuilder("<script type='text/javascript'>");
            sbj = sbj.Append("function confirmvendordel() ");
            sbj = sbj.Append("{ ");
            sbj = sbj.Append("var con = confirm('Are you sure to delete the item?'); ");
            sbj = sbj.Append("if (con == true) { document.getElementById('hiddenvendor').InnerHTML = 'get'; }");
            sbj = sbj.Append(" }");
            sbj = sbj.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(vendorPanel, this.vendorPanel.GetType(), "confirm", sbj.ToString(), false);*/
            //string hiddenvalue = this.Request.Form["hiddenTxt"].ToString(); 

            //if (ll.InnerHtml == "welcome to Norway")
            //this is only for test
            if (!IsPostBack)
            {
                Vendors theVendor = new Vendors();
                DataTable vendorTable = theVendor.getAllVendors();
                vendorList.DataSource = vendorTable;
                vendorList.DataTextField = "Vendname";
                vendorList.DataValueField = "Vendname";
                vendorList.DataBind();
                //delvendor.Attributes.Add("onclick", "confirmvendordel()");
                //gdeleteBtn.Attributes.Add("onclick", "confirmvendordel()");
            }
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
       
    }

    protected void gsaveBtn_Click(object sender, EventArgs e)
    {
        string Goodsname = gnameTxt.Text;
        string Size = gsizeTxt.Text;
        string Weight = gweightTxt.Text;
        string Price = gpriceTxt.Text;
        string Picture = gpictureTxt.Text;
        string Type = gtypeList.SelectedValue;
        string Vendname = gvendorTxt.Text;
        int ID = 0;
        //get Id
        if (gidTxt.Text != null && gidTxt.Text != "")
        {
            ID = Convert.ToInt32(gidTxt.Text);
        }
        Goods theGoods = new Goods();
        DataTable theTable = theGoods.getGoodsQuantity(ID);
        int oldQuantity = 0;
        //get the old quantity
        if (gquantityTxt.Text != null && gquantityTxt.Text != "")
        {
            oldQuantity = Convert.ToInt32(gquantityTxt.Text);
        }
        int gaddedQuantity = 0;
        //get the input quantity 
        if (gaddquantityTxt.Text != null && gaddquantityTxt.Text != "")
        {
            gaddedQuantity = Convert.ToInt32(gaddquantityTxt.Text);
        }
        //calculate and update the quantity
        int Quantity = gaddedQuantity + oldQuantity;
        if (ID != 0)
        {
            theGoods.updateGoods(Goodsname, Price, Quantity, Size, Weight, Type, Vendname, Picture, ID);
        }
        /* gaddquantityTxt.Text = "";
         gidTxt.Text = "";
         gnameTxt.Text = "";
         gpictureTxt.Text = "";
         gpriceTxt.Text = "";
         gquantityTxt.Text = "";
         gsizeTxt.Text = "";
         gweightTxt.Text = "";*/
            //get and show the data of the product
            DataTable updatedTable = theGoods.getGoodsFullInforById(Convert.ToInt32(gidTxt.Text));
        if (theTable != null && theTable.Rows.Count == 1)
        {
            gnameTxt.Text = updatedTable.Rows[0]["Goodsname"].ToString();
            gpriceTxt.Text = updatedTable.Rows[0]["Price"].ToString();
            gsizeTxt.Text = updatedTable.Rows[0]["Size"].ToString();
            gquantityTxt.Text = updatedTable.Rows[0]["Quantity"].ToString();
            gweightTxt.Text = updatedTable.Rows[0]["Weight"].ToString();
            gpictureTxt.Text = updatedTable.Rows[0]["Picture"].ToString();
            gvendorTxt.Text = updatedTable.Rows[0]["Vendname"].ToString();
            gtypeList.SelectedValue = updatedTable.Rows[0]["Type"].ToString();
            gaddquantityTxt.Text = "";
        }
    }

    protected void gidTxt_TextChanged(object sender, EventArgs e)
     {
         if (gidTxt.Text != null && gidTxt.Text != "")
         {
            //get and show data of a product by id
            Goods theGoods = new Goods();
             DataTable theTable = theGoods.getGoodsFullInforById(Convert.ToInt32(gidTxt.Text));
             if (theTable != null && theTable.Rows.Count == 1)
             {
                 gnameTxt.Text = theTable.Rows[0]["Goodsname"].ToString();
                 gpriceTxt.Text = theTable.Rows[0]["Price"].ToString();
                 gsizeTxt.Text = theTable.Rows[0]["Size"].ToString();
                 gquantityTxt.Text = theTable.Rows[0]["Quantity"].ToString();
                 gweightTxt.Text = theTable.Rows[0]["Weight"].ToString();
                 gpictureTxt.Text = theTable.Rows[0]["Picture"].ToString();
                 gvendorTxt.Text = theTable.Rows[0]["Vendname"].ToString();
                 gtypeList.SelectedValue = theTable.Rows[0]["Type"].ToString();
             }
             //if there is no product with the given id, clean the textboxes
             else
             {
                 gnameTxt.Text = "";
                 gpriceTxt.Text = "";
                 gsizeTxt.Text = "";
                 gquantityTxt.Text = "";
                 gweightTxt.Text = "";
                 gpictureTxt.Text = "";
                 gvendorTxt.Text = "";
                 gtypeList.SelectedValue = "";
             }
         }
     }

    //if the user confirm to delete in the confirmation pop-up box
     protected void gdeleteBtn_Click(object sender, EventArgs e)
     {
         Goods theGoods = new Goods();
         if (gidTxt.Text != "" && gidTxt.Text != null)
         {
             theGoods.deleteGoodsById(Convert.ToInt32(gidTxt.Text));
             gidTxt.Text = "";
             gnameTxt.Text = "";
             gsizeTxt.Text = "";
             gtypeList.Text = "";
             gweightTxt.Text = "";
             gpictureTxt.Text = "";
             gpriceTxt.Text = "";
             gvendorTxt.Text = "";
         }
         //write js codes with code-behind
         /*StringBuilder sbj = new StringBuilder("<script type='text/javascript'>");
         sbj = sbj.Append("alert('yes')");
         sbj = sbj.Append("</script>");
         ScriptManager.RegisterClientScriptBlock(vendorPanel, this.vendorPanel.GetType(), "alert", sbj.ToString(), false);*/
        //string hiddenvalue = this.Request.Form["hiddenTxt"].ToString();
    }

    protected void registernewgoodBtn_Click(object sender, EventArgs e)
    {
        string Goodsname = goodsTxt.Text;
        string Price = priceTxt.Text + " $";
        int Quantity = Convert.ToInt16(quantityTxt.Text);
        string Size = sizeTxt.Text + " ml";
        string Weight = weightTxt.Text;
        string Type = typeList.SelectedValue;
        string Vendname = vendorList.SelectedValue;
        string Picture = pictureTxt.Text;
        //create a new product object
        Goods newGoods = new Goods(Goodsname, Price, Quantity, Size, Weight, Type, Vendname, Picture);
        //insert the product data into database, and clean the textboxes after inserting
        if (newGoods != null)
        {
            newGoods.insertGoods();
            goodsTxt.Text = "";
            priceTxt.Text = "";
            quantityTxt.Text = "";
            sizeTxt.Text = "";
            weightTxt.Text = "";
            typeList.Text = "";
            pictureTxt.Text = "";
        }
    }

    protected void registervendorBtn_Click(object sender, EventArgs e)
    {
        //enable the field validator
        companyRequired.Enabled = true;
        addressRequired.Enabled = true;
        telephoneRequired.Enabled = true;
        emailRequired.Enabled = true;
        contactperson1Required.Enabled = true;
        //regist the new vendor
        string Vendname = companyTxt.Text;
        string Vendadrs = addressTxt.Text;
        string Vendtelephone = telephoneTxt.Text;
        string Vendemail = emailTxt.Text;
        string Contactperson1 = contact1Txt.Text;
        string Contactperson2 = contact2Txt.Text;
        Vendors theVendor = new Vendors(Vendname, Vendadrs, Vendtelephone, Vendemail, Contactperson1, Contactperson2);
        theVendor.insertVendor();
        //clean the textboxes after updating
        companyTxt.Text = "";
        addressTxt.Text = "";
        telephoneTxt.Text = "";
        emailTxt.Text = "";
        contact1Txt.Text = "";
        contact2Txt.Text = "";
    }

    protected void vendorID_TextChanged1(object sender, EventArgs e)
    {
        //get vendor data by vendor id
        if (vendorID.Text != null && vendorID.Text != "")
        {
            Vendors theVendor = new Vendors();
            DataTable theTabel = theVendor.getVendor(Convert.ToInt32(vendorID.Text));
            if (theTabel != null && theTabel.Rows.Count > 0)
            {
                companyTxt.Text = theTabel.Rows[0]["Vendname"].ToString();
                addressTxt.Text = theTabel.Rows[0]["Vendadrs"].ToString();
                telephoneTxt.Text = theTabel.Rows[0]["Vendtelephone"].ToString();
                emailTxt.Text = theTabel.Rows[0]["Vendemail"].ToString();
                contact1Txt.Text = theTabel.Rows[0]["Contactperson1"].ToString();
                contact2Txt.Text = theTabel.Rows[0]["Contactperson2"].ToString();
            }
            //clean the textboxes if there is no vendor with the given id
            else
            {
                companyTxt.Text = "";
                addressTxt.Text = "";
                telephoneTxt.Text = "";
                emailTxt.Text = "";
                contact1Txt.Text = "";
                contact2Txt.Text = "";
            }
        }
    }

    protected void delvendor_Click(object sender, EventArgs e)
    {
        if (vendorID.Text != null && vendorID.Text != "")
        {
            Vendors thevendor = new Vendors();
            try
            {
                //delete the vendor
                thevendor.deleteVendor(Convert.ToInt32(vendorID.Text));
                //clean the textboxes
                vendorID.Text = "";
                companyTxt.Text = "";
                telephoneTxt.Text = "";
                addressTxt.Text = "";
                contact1Txt.Text = "";
                contact2Txt.Text = "";
                emailTxt.Text = "";
            }
            catch
            { }

        }
    }
}