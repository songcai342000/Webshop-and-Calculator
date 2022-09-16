<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewState="true" CodeFile="Registgoods.aspx.cs" Inherits="Registgoods" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID = "MainContent" runat="server">
   
<script type="text/javascript">
    function test()
    {
        return confirm("You are going to delete the item. Will you continue?");
    }
</script>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" ></asp:ScriptManagerProxy>
    <section id="updategoodform">
        <br/><br/><br/><br/>
    <table class="table">
        <caption style="font-weight:bold">Update Goods</caption>
      <tr><td>Goods Name<br/>
          <asp:TextBox ID="gnameTxt" runat="server" CssClass="form-control"></asp:TextBox></td> 
               <td>ID number<br /><asp:TextBox ID="gidTxt" runat="server" CssClass="form-control" OnTextChanged="gidTxt_TextChanged" AutoPostBack="true"></asp:TextBox></td>
               <td>Price<br/><asp:TextBox ID="gpriceTxt" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
               <tr><td>Quantity<br/><asp:TextBox ID="gquantityTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
                   <td>Add Quantity<br/><asp:TextBox ID="gaddquantityTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
               <td>Size<br/><asp:TextBox ID="gsizeTxt" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
               <tr><td>Weight<br/><asp:TextBox ID="gweightTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
                <td>Type<br/><asp:DropdownList ID="gtypeList" runat="server" CssClass="form-control">
                   <asp:ListItem Value="Skincare" Text="Skin Care"></asp:ListItem>
                                      <asp:ListItem Value="Haircare" Text="Hair Care"></asp:ListItem>
                   <asp:ListItem Value="Perfume" Text="Perfume"></asp:ListItem>
                   <asp:ListItem Value="Makeup" Text="Make Up"></asp:ListItem>
                                </asp:DropdownList></td>
               <td>Vendor<br/><asp:TextBox ID="gvendorTxt" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox></td></tr>
               <tr><td>Pictureurl<br/><asp:TextBox ID="gpictureTxt" runat="server" CssClass="form-control"></asp:TextBox></td><td></td><td></td></tr>
           <tr><td><asp:Button ID="gsaveBtn" runat="server" Text="Update Goods" OnClick="gsaveBtn_Click" CssClass="btn btn-default"></asp:Button></td><td><asp:Button ID="gdeleteBtn" runat="server" Text="Delete Goods" OnClick="gdeleteBtn_Click" OnClientClick="if (! test()) return false;" CssClass="btn btn-default"></asp:Button></td><td></td></tr></table>
      </section>         
      

      <section id="registvendorform">
          <br/><br/>
    <table class="table"><caption style="font-weight:bold">Register Vendor</caption>
           <tr><td>VendorID<br/>
               <asp:TextBox ID="vendorID" runat="server" CssClass="form-control" OnTextChanged="vendorID_TextChanged1" AutoPostBack="true"></asp:TextBox></td>
               <td>Company<br/><asp:TextBox ID="companyTxt" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="companyRequired" runat="server" ControlToValidate="companyTxt" ErrorMessage="This field can not be empty" CssClass="text-danger" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator></td>
               <td>Address<br/><asp:TextBox ID="addressTxt" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="addressRequired" runat="server" ControlToValidate="addressTxt" ErrorMessage="This field can not be empty" CssClass="text-danger" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator></td></tr>
               <tr><td>Telephone<br/><asp:TextBox ID="telephoneTxt" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="telephoneRequired" runat="server" ControlToValidate="telephoneTxt" ErrorMessage="This field can not be empty" CssClass="text-danger" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator></td>
               <td>Email<br/><asp:TextBox ID="emailTxt" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="emailTxt" ErrorMessage="Email address is required" CssClass="text-danger" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator></td>
               <td>Contact Person 1<br/><asp:TextBox ID="contact1Txt" runat="server" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="contactperson1Required" runat="server" ControlToValidate="contact1Txt" ErrorMessage="Contact person is required" CssClass="text-danger" ForeColor="Red" Enabled="false"></asp:RequiredFieldValidator></td></tr>
           <tr><td>Contact Person 2<br/><asp:TextBox ID="contact2Txt" runat="server" CssClass="form-control"></asp:TextBox></td><td></td><td></td></tr>
          <tr><td><asp:Button runat="server" ID="registervendorBtn" Text="Register Vendor" OnClick="registervendorBtn_Click" CssClass="btn btn-default"/></td><td><asp:Button runat="server" id="delvendor" Text="Delete Vendor" cssclass="btn btn-default" OnClick="delvendor_Click" OnClientClick="if (!test()) return false;"/></td><td></td></tr>
        </table>
      </section>     
        
    <section id="registnewgoodform" runat="server">
        <br/><br/>               
       <table class="table"><caption style="font-weight:bold">Register New Goods</caption>
           <tr><td>ID<br/><asp:TextBox ID="goodsidTxt" runat="server" CssClass="form-control" Enabled="false"/></td>
               <td>Goods Name<br/><asp:TextBox ID="goodsTxt" runat="server" CssClass="form-control"></asp:TextBox> </td>
               <td>Price<br/><asp:TextBox ID="priceTxt" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
               <tr><td>Quantity<br/><asp:TextBox ID="quantityTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
               <td>Size<br/><asp:TextBox ID="sizeTxt" runat="server" CssClass="form-control"></asp:TextBox></td>
              <td>Weight<br/><asp:TextBox ID="weightTxt" runat="server" CssClass="form-control"></asp:TextBox></td></tr>
              <tr> <td>Type<br/><asp:DropdownList ID="typeList" runat="server" CssClass="form-control">
                  <asp:ListItem Value="Skincare" Text="Skin Care"></asp:ListItem>
                  <asp:ListItem Value="Haircare" Text="Hair Care"></asp:ListItem>
                  <asp:ListItem Value="Perfume" Text="Perfume"></asp:ListItem>
                  <asp:ListItem Value="Make up" Text="Make up"></asp:ListItem>
                                </asp:DropdownList></td>
               <td>Vendor<br/><asp:DropdownList ID="vendorList" runat="server" CssClass="form-control"></asp:DropdownList></td>
               <td>Pictureurl<br/><asp:TextBox ID="pictureTxt" runat="server" CssClass="form-control"></asp:TextBox></td><td></td></tr>
        <tr><td><asp:Button ID="registernewgoodBtn" runat="server" Text="Register Goods" OnClick="registernewgoodBtn_Click" CssClass="btn btn-default" /></td><td></td><td></td></tr>
    </table>
</section>
</asp:Content>

