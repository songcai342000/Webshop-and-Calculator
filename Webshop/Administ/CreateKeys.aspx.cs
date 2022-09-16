using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

public partial class Administ_CreateKeys : System.Web.UI.Page
{
    /// <summary>
    ///create encrypt key with AES 
    /// </summary>
    byte[] Key;
    byte[] IV;
    protected void Page_Load(object sender, EventArgs e)
    {
        //create the key
        using (Aes myAes = Aes.Create())
        {
            Key = myAes.Key;
            IV = myAes.IV;
        }
        //convert to string
        string MyKey = Convert.ToBase64String(Key);
        string MyIV = Convert.ToBase64String(IV);
        //store the strings to array
        String[] theKeys = {MyKey, MyIV};
        //save the keys to the txt file
        System.IO.File.WriteAllLines(@"C:\Users\Song Cai\Documents\Visual Studio 2015\WebSites\Keytext.txt", theKeys);
    }
}