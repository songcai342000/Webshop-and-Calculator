 <%@ Page Title="Administrator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Administrators.aspx.cs" Inherits="Administrators" %>
<%@ Register Src="~/Usercontrols/calendarUserCtrl.ascx" TagPrefix="uc1" TagName="calendarUserCtrl" %>

<asp:content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
 
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

   
 <h2></h2>
    
   
   
     <div class="row" >
    <div >
        <h3>
    Reports</h3> 
    <div>        
       

        &nbsp;<br />
        <br/>
      
        <asp:DropDownList ID="ReporPeriodDlist" runat="server" OnSelectedIndexChanged="ReporPeriodDlist_SelectedIndexChanged1" AutoPostBack="true">
            <asp:ListItem Value="Todays report">Todays report</asp:ListItem>
            <asp:ListItem Value="Period report">Period report</asp:ListItem>

        </asp:DropDownList>&nbsp;&nbsp;  <uc1:calendarUserCtrl runat="server" ID="calendarUserCtrl" Visible="false" />
        <br/>
        <asp:Button ID="getRepBtn" runat="server" Text="Get Report" OnClick="getRepBtn_Click" /> 
   
    </div>
        <div>
     <asp:Panel ID="controlPanel" runat="server">
     </asp:Panel>
        </div>
        
        
    </div>
    </div>
    <div class="row">
         <div style="visibility: hidden">
    <table>
       
        <tr> 
            <td>
                <a href="Updateshipping.aspx">Update Shipping State</a></td><td><a href="Updatecomplaiment.aspx">Update Complainment</a></td><td></td><td></td>
        </tr>
        
     </table>
    </div>
    <div  style="visibility: hidden">
        <p>
    Grant administrator right</p>
<p>
    Username:
</p>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Grant" OnClick="Button1_Click" />
        <br />
        <br />
        </div>
    
    </div>
</asp:content>
